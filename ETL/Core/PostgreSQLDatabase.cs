using ETL.UI;
using ETL.Utility;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class PostgreSQLDatabase : Database
    {
        private NpgsqlConnection connection { get; set; }
        public string port { get; set; }

        public PostgreSQLDatabase(string serverName, string username, string password, string databaseName, string port, string schema = "") :
            base(serverName, username, password, databaseName, schema)
        {
            this.port = port;
            this.type = Database.DATABASE_TYPE_POSTGRES;
        }

        public override bool Connect()
        {
            string connectionString = String.Format(
                "Server={0};" +
                "Port={1};" +
                "User Id={2};" +
                "Password={3};" +
                "Database={4};",
                 this.serverName, this.port, this.username, this.password, this.databaseName);
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                this.connection = connection;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "Postgres-Connect");
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
                Helper.Log(e.Message, "Postgres-Close");
                return false;
            }
        }

        public override List<string> GetTablesNames()
        {
            string query = "SELECT table_name FROM information_schema.tables AND table_type = 'BASE TABLE';";
            if (this.schema != "")
            {
                query = "SELECT table_name FROM information_schema.tables WHERE table_schema = '" + this.schema + "' AND table_type = 'BASE TABLE';";
            }
            List<string> tablesNames = new List<string>();
            NpgsqlCommand command = new NpgsqlCommand(query, this.connection);
            try
            {
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tablesNames.Add(reader.GetString(0));
                }
                return tablesNames;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "Postgres-GetTables");
                return tablesNames;
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
                query = "SELECT * FROM " + this.schema + ".\"" + tableOrQueryName + "\";";
            }
            NpgsqlCommand command = new NpgsqlCommand(query, this.connection);

            try
            {
                command.Prepare();
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);

                tableOrQuery.dataTable.Clear();
                tableOrQuery.dataTable.RowChanged += new DataRowChangeEventHandler(Row_Added);
                dataAdapter.Fill(tableOrQuery.dataTable);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "Postgres-SelectData");
                return false;
            }
        }

        public override DataTable TrySelect(string query)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, this.connection);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
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
                Helper.Log(e.Message, "Postgres-TrySelectData");
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
            Dictionary<string, NpgsqlDbType> columnsWithTypes = PostgreSQLHelper.GetsColumnsWithTypes(dataTable.Columns);
            string values = PostgreSQLHelper.GetValuesStringForInsertQuery(dataTable.Columns);


            string selectQuery = "SELECT * FROM \"" + tableName + "\"";
            string insertQuery = "INSERT INTO \"" + tableName + "\"" + fields + " values " + values;
            if (this.schema != "")
            {
                selectQuery = "SELECT * FROM " + this.schema + ".\"" + tableName + "\"";
                insertQuery = "INSERT INTO " + this.schema + ".\"" + tableName + "\"" + fields + " values " + values;
            }

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectQuery, connection);
                dataAdapter.InsertCommand = new NpgsqlCommand(insertQuery, connection);
                PostgreSQLHelper.SetParametersForInsertQuery(columnsWithTypes, dataAdapter);

                dataAdapter.Update(dataTable);
                dataTable.RowChanged += new DataRowChangeEventHandler(Row_Changed);
                dataTable.AcceptChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "Postgres-Insert");
                return false;
            }
        }

        public override bool SetDatatableSchema(string tableName)
        {
            Table table = GetTable(tableName);
            string tableInQuery = tableName;
            if (this.schema != "")
            {
                tableInQuery = this.schema + ".\"" + tableName + "\"";
            }
            string query = "SELECT * FROM " + tableInQuery + " WHERE 1=0;";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connection);

            try
            {
                command.Prepare();
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);

                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);
                table.dataTable = dataSet.Tables[0];
                this.GetTable(tableName).columns = table.dataTable.Columns.Cast<DataColumn>().ToList();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "Postgres-SetDatatableSchema-"+tableName);
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
            try
            {
                int startIndex = query.IndexOf("SELECT") + 7;
                int endIndex = query.IndexOf("FROM") - 1;

                query = query.Remove(startIndex, endIndex - startIndex);
                query = query.Insert(startIndex, "count(1)");

                if (type == TableOrQuery.TYPE_TABLE && this.schema != "" && this.schema != null)
                {
                    query = "SELECT count(1) FROM " + this.schema + ".\"" + tableOrQueryName + "\";";
                }
                NpgsqlCommand command = new NpgsqlCommand(query, this.connection);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "Postgres-SelectRowCount-"+tableOrQueryName);
                return 0;
            }
        }
        protected void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action != DataRowAction.Commit)
            {
                Global.progressForm.UpdateForm(ProgressForm.PROGRESSBAR_MAXIMUM, e.Row.Table.Rows.Count.ToString());
                int RowIndex = e.Row.Table.Rows.IndexOf(e.Row);
                RowIndex++;
                Global.ProgressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, RowIndex.ToString());
            }
        }

        protected void Row_Added(object sender, DataRowChangeEventArgs e)
        {
            int RowIndex = e.Row.Table.Rows.IndexOf(e.Row);
            RowIndex++;
            Global.ProgressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, RowIndex.ToString());
        }

        public override bool Equals(Object obj)
        {
            return (obj is PostgreSQLDatabase)
                && ((PostgreSQLDatabase)obj).databaseName == this.databaseName
                 && ((PostgreSQLDatabase)obj).username == this.username
                  && ((PostgreSQLDatabase)obj).password == this.password
                   && ((PostgreSQLDatabase)obj).serverName == this.serverName
                  && ((PostgreSQLDatabase)obj).port == this.port;
        }
    }
}
