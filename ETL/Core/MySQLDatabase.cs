using ETL.UI;
using ETL.Utility;
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

        public MySQLDatabase(string serverName, string username, string password, string databaseName, string schema = "") :
            base(serverName, username, password, databaseName, schema)
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
                Helper.Log(e.Message, "MySQL-Connect");
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
                Helper.Log(e.Message, "MySQL-Close");
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
                Helper.Log(e.Message, "MySQL-GetTables");
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
                tableOrQuery.dataTable.Clear();
                tableOrQuery.dataTable.RowChanged += new DataRowChangeEventHandler(Row_Added);
                da.Fill(tableOrQuery.dataTable);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "MySQL-SelectData");
                return false;
            }
        }

        public override DataTable TrySelect(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(query, this.connection);
            DataTable testDatatable = new DataTable();
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(testDatatable);
                return testDatatable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "MySQL-TrySelectData");
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
                dataTable.RowChanged += new DataRowChangeEventHandler(Row_Changed);
                dataTable.AcceptChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "MySQL-Insert");
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
            MySqlCommand command = new MySqlCommand(query, this.connection);
            try
            {
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "MySQL-SelectRowCount" + tableOrQueryName);
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
            return (obj is MySQLDatabase)
                && ((MySQLDatabase)obj).databaseName == this.databaseName
                 && ((MySQLDatabase)obj).username == this.username
                  && ((MySQLDatabase)obj).password == this.password
                   && ((MySQLDatabase)obj).serverName == this.serverName;
        }
    }
}
