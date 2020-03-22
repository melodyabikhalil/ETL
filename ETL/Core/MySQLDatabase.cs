using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class MySQLDatabase: Database
    {
        private MySqlConnection connection { get; set; }

        public MySQLDatabase(string serverName, string username, string password, string databaseName) :
            base(serverName, username, password, databaseName)
        {
            this.type = Database.DATABASE_TYPE_MYSQL;
        }

        public override bool Connect()
        {
            string connectionString = String.Format(
                "server={0};" +
                "userid={1};" +
                "password={2};" +
                "database={3};",
                this.serverName, this.username, this.password, this.databaseName);
            try
            {
                this.connection = new MySqlConnection(connectionString);
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
            string query = "SHOW TABLES;";
            List<string> tablesNames = new List<string>();
            MySqlCommand command = new MySqlCommand(query, this.connection);

            try
            {
                MySqlDataReader reader = command.ExecuteReader();
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

            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd;
            cmd = new MySqlCommand(query, this.connection);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(tableOrQuery.dataTable);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(query, this.connection);
            DataTable testDatatable = new DataTable();
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(testDatatable);
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
            Dictionary<string, MySqlDbType> columnsWithTypes = MySQLHelper.GetsColumnsWithTypes(dataTable.Columns);
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd;
            List<string> fieldsList = table.GetColumnsNames();
            string fieldsString = MySQLHelper.CreateFieldsString(fieldsList);
            string valuesString = MySQLHelper.CreateValuesString(fieldsList);
            cmd = new MySqlCommand("INSERT INTO " + tableName + fieldsString + " VALUES" + valuesString, this.connection);
            da.InsertCommand = cmd;

            try
            {
                MySQLHelper.SetParametersForInsertQuery(columnsWithTypes, da);
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
            bool result = this.Select(tableName, TableOrQuery.TYPE_TABLE);
            if (result)
            {
                this.GetTable(tableName).columns = this.GetTable(tableName).dataTable.Columns.Cast<DataColumn>().ToList();
            }
            return result;
        }
        public override bool Equals(Object obj)
        {
            return (obj is MySQLDatabase)
                && ((MySQLDatabase)obj).databaseName == this.databaseName
                 && ((MySQLDatabase)obj).username == this.username
                  && ((MySQLDatabase)obj).password == this.password
                   && ((MySQLDatabase)obj).serverName == this.serverName;
        }
    }
}
