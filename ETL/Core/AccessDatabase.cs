using ETL.UI;
using ETL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class AccessDatabase : Database
    {
        private OleDbConnection connection { get; set; }
        public string path { get; set; }

        public AccessDatabase(string path, string serverName = null, string username = null, string password = null, string databaseName = null) :
            base(serverName, username, password, databaseName)
        {
            this.path = path;
            if (databaseName == null)
            {
                int indexOfLastBackslash = this.path.LastIndexOf("\\");
                int indexOfExtension = this.path.LastIndexOf(".");
                this.databaseName = this.path.Substring(indexOfLastBackslash + 1, indexOfExtension - indexOfLastBackslash - 1);
            }
            this.type = Database.DATABASE_TYPE_ACCESS;
        }

        public override bool Connect()
        {
            string connectionString = String.Format(
                "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source={0};",
                this.path);
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
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
            string query = "SELECT MSysObjects.Name AS table_name FROM MSysObjects WHERE(((Left([Name], 1)) <> \"~\") AND((Left([Name], 4)) <> \"MSys\")  AND((MSysObjects.Type)In(1, 4, 6)) AND((MSysObjects.Flags) = 0)) order by MSysObjects.Name ";
            List<string> tablesNames = new List<string>();
            OleDbCommand command = new OleDbCommand(query, this.connection);

            try
            {
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tablesNames.Add(reader.GetString(0));
                }
                return tablesNames;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message);
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

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            OleDbCommand selectCommand = new OleDbCommand(query, this.connection);
            dataAdapter.SelectCommand = selectCommand;

            try
            {
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
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            OleDbCommand selectCommand = new OleDbCommand(query, this.connection);
            dataAdapter.SelectCommand = selectCommand;
            DataTable testDatatable = new DataTable();
            dataAdapter.SelectCommand = selectCommand;
            try
            {
                dataAdapter.Fill(testDatatable);
                return testDatatable;
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
            Dictionary<string, OleDbType> columnsWithTypes = AccessHelper.GetsColumnsWithTypes(dataTable.Columns);
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cmd;
            List<string> fieldsList = table.GetColumnsNames();
            string fieldsString = AccessHelper.CreateFieldsString(fieldsList);
            string valuesString = AccessHelper.CreateValuesString(fieldsList);
            cmd = new OleDbCommand("INSERT INTO " + tableName + fieldsString + " VALUES" + valuesString, this.connection);
            da.InsertCommand = cmd;

            try
            {
                AccessHelper.SetParametersForInsertQuery(columnsWithTypes, da);
                da.Update(dataTable);
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
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            OleDbCommand selectCommand = new OleDbCommand(query, this.connection);
            dataAdapter.SelectCommand = selectCommand;
            try
            {
                dataAdapter.Fill(table.dataTable);
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
            OleDbCommand command = new OleDbCommand(query, this.connection);
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
            return (obj is AccessDatabase) && ((AccessDatabase)obj).path == this.path;
        }
    }
}
