using ETL.UI;
using ETL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class SQLServerDatabase : Database
    {
        private SqlConnection connection { get; set; }

        public SQLServerDatabase(string serverName, string username, string password, string databaseName, string schema = "") :
            base(serverName, username, password, databaseName, schema)
        {
            this.type = Database.DATABASE_TYPE_SQLSERVER;
        }

        public override bool Connect()
        {
            string connectionString = String.Format(
                "Data Source={0};" +
                "Initial Catalog={1};" +
                "User ID={2};" +
                "Password={3};",
                 this.serverName, this.databaseName, this.username, this.password);
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                this.connection = connection;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return false;
            }
        }
        public override bool Close()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return false;
            }
        }

        public override List<string> GetTablesNames()
        {
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME ASC;";
            List<string> tablesNames = new List<string>();

            try
            {
                SqlCommand command = new SqlCommand(query, this.connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tablesNames.Add(reader.GetString(0));
                }
                reader.Close();
                List<string> viewsNames = this.GetViewsNames();
                List<string> names = tablesNames.Concat(viewsNames).ToList();
                return names;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return tablesNames;
            }
        }

        public List<string> GetViewsNames()
        {
            string query = "SELECT name FROM sys.views ORDER BY name ASC;";
            List<string> viewsNames = new List<string>();

            try
            {
                SqlCommand command = new SqlCommand(query, this.connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    viewsNames.Add(reader.GetString(0));
                }
                return viewsNames;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return viewsNames;
            }
        }

        public override bool Select(string tableOrQueryName, string type)
        {
            TableOrQuery tableOrQuery;
            if (type == TableOrQuery.TYPE_TABLE)
            {
                tableOrQuery = this.tables[this.GetTableIndexByName(tableOrQueryName)];
            }
            else
            {
                tableOrQuery = this.queries[this.GetQueryIndexByName(tableOrQueryName)];
            }

            if (tableOrQuery == null)
            {
                return false;
            }
            string query = tableOrQuery.query;
            if (type == TableOrQuery.TYPE_TABLE && this.schema != "" && this.schema != null)
            {
                query = "SELECT * FROM " + this.schema + "." + tableOrQueryName +";";
            }
            SqlCommand command = new SqlCommand(query, this.connection);

            try
            {
                command.Prepare();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                tableOrQuery.dataTable.Clear();
                tableOrQuery.dataTable.RowChanged += new DataRowChangeEventHandler(Row_Added);
                dataAdapter.Fill(tableOrQuery.dataTable);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return false;
            }
        }

        public override DataTable TrySelect(string query)
        {
            SqlCommand command = new SqlCommand(query, this.connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            try
            {
                dataAdapter.Fill(dataSet);
                DataTable datatable = dataSet.Tables[0];
                return datatable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return null;
            }
        }

        public override bool Insert(string tableName)
        {
            Table table = this.tables[this.GetTableIndexByName(tableName)];
            if (table == null)
            {
                return false;
            }
            DataTable dataTable = table.dataTable;
            if (dataTable == null)
            {
                return false;
            }

            List<string> fieldsNames = table.GetColumnsNames();
            string fields = "(" + string.Join(",", fieldsNames.Select(x => string.Format("\"{0}\"", x))) + ")";
            Dictionary<string, SqlDbType> columnsWithTypes = SQLServerHelper.GetsColumnsWithTypes(dataTable.Columns);
            string values = SQLServerHelper.GetValuesStringForInsertQuery(dataTable.Columns);

            string tableNameInQuery = tableName;
            if (this.schema != "")
            {
                tableNameInQuery = "[" + this.schema + "].[" + tableName + "]";
            }
            string insertQuery = "INSERT INTO " + tableName + fields + " values " + values;

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(insertQuery, this.connection);
                SQLServerHelper.SetParametersForInsertQuery(columnsWithTypes, command, table);
                dataAdapter.InsertCommand = command;

                dataAdapter.Update(dataTable);
                dataTable.RowChanged += new DataRowChangeEventHandler(Row_Changed);
                dataTable.AcceptChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return false;
            }
        }

        public override bool SetDatatableSchema(string tableName)
        {
            string query = "SELECT * FROM " + tableName + " WHERE 1=0;";
            Table table = GetTable(tableName);
            SqlCommand command = new SqlCommand(query, this.connection);

            try
            {
                command.Prepare();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);
                table.dataTable = dataSet.Tables[0];
                this.GetTable(tableName).columns = table.dataTable.Columns.Cast<DataColumn>().ToList();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return false;
            }
        }

        public override int SelectRowCount(string tableOrQueryName, string type)
        {
            TableOrQuery tableOrQuery;
            if (type == TableOrQuery.TYPE_TABLE)
            {
                tableOrQuery = this.tables[this.GetTableIndexByName(tableOrQueryName)];
            }
            else
            {
                tableOrQuery = this.queries[this.GetQueryIndexByName(tableOrQueryName)];
            }

            if (tableOrQuery == null)
            {
                return 0;
            }

            string query = tableOrQuery.query;
            int startIndex = query.IndexOf("SELECT") + 7;
            int endIndex = query.IndexOf(" FROM");

            query = query.Remove(startIndex, endIndex - startIndex);
            query = query.Insert(startIndex, "count(1)");
            SqlCommand command = new SqlCommand(query, this.connection);
            try
            {
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
                return 0;
            }
        }

        protected void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            Global.progressForm.UpdateForm(ProgressForm.PROGRESSBAR_MAXIMUM, e.Row.Table.Rows.Count.ToString());
            int RowIndex = e.Row.Table.Rows.IndexOf(e.Row);
            RowIndex++;
            Global.ProgressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, RowIndex.ToString());
        }

        protected void Row_Added(object sender, DataRowChangeEventArgs e)
        {
            int RowIndex = e.Row.Table.Rows.IndexOf(e.Row);
            RowIndex++;
            Global.ProgressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, RowIndex.ToString());
        }

        public override bool Equals(Object obj)
        {
            return (obj is SQLServerDatabase)
                && ((SQLServerDatabase)obj).databaseName == this.databaseName
                 && ((SQLServerDatabase)obj).username == this.username
                  && ((SQLServerDatabase)obj).password == this.password
                   && ((SQLServerDatabase)obj).serverName == this.serverName;
        }
    }
}
