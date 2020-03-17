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
                return tablesNames;
            }
        }
        public override bool Select(string tableName, string query)
        {
            Table table = this.tables[this.GetTableIndexByName(tableName)];
            if (table == null)
            {
                return false;
            }
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            OleDbCommand selectCommand = new OleDbCommand(query, this.connection);
            dataAdapter.SelectCommand = selectCommand;

            try
            {
                dataAdapter.Fill(table.dataTable);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public override bool TrySelect(string query)
        {
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            OleDbCommand selectCommand = new OleDbCommand(query, this.connection);
            dataAdapter.SelectCommand = selectCommand;
            DataTable testDatatable = new DataTable();
            dataAdapter.SelectCommand = selectCommand;
            try
            {
                dataAdapter.Fill(testDatatable);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
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
                dataTable.AcceptChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public override bool SetDatatableSchema(string tableName)
        {
            string query = "SELECT * FROM " + tableName + " WHERE 1=0;";
            bool result = this.Select(tableName, query);
            if (result)
            {
                this.GetTable(tableName).columns = this.GetTable(tableName).dataTable.Columns.Cast<DataColumn>().ToList();
            }
            return result;
        }

        public override bool Equals(Object obj)
        {
            return (obj is AccessDatabase) && ((AccessDatabase)obj).path == this.path;
        }
    }
}
