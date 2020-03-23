using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class ODBCDatabase : Database
    {
        private OdbcConnection connection { get; set; }

        public string connectionString { get; set; }

        public ODBCDatabase(string connectionString, string serverName = null, string username = null, string password = null, string databaseName = null) :
            base(serverName, username, password, databaseName)
        {
            this.connectionString = connectionString;
            this.type = Database.DATABASE_TYPE_ODBC;
        }

        public override bool Connect()
        {
            try
            {
                OdbcConnection connection = new OdbcConnection(this.connectionString);
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
            string query = "SELECT table_name FROM all_tables;";
            List<string> tablesNames = new List<string>();
            OdbcCommand command = new OdbcCommand(query, this.connection);
            try
            {
                OdbcDataReader reader = command.ExecuteReader();
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

            OdbcCommand command = new OdbcCommand(query, this.connection);

            try
            {
                command.Prepare();
                OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);
                tableOrQuery.dataTable.Clear();
                tableOrQuery.dataTable = dataSet.Tables[0];
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
            OdbcCommand command = new OdbcCommand(query, this.connection);
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);
            DataSet dataSet = new DataSet();
            try
            {
                dataAdapter.Fill(dataSet);
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
            Dictionary<string, OdbcType> columnsWithTypes = ODBCHelper.GetsColumnsWithTypes(dataTable.Columns);
            OdbcDataAdapter da = new OdbcDataAdapter();
            OdbcCommand cmd;
            List<string> fieldsList = table.GetColumnsNames();
            string fieldsString = ODBCHelper.CreateFieldsString(fieldsList);
            string valuesString = ODBCHelper.CreateValuesString(fieldsList);
            cmd = new OdbcCommand("INSERT INTO " + tableName + " " + fieldsString + " VALUES " + valuesString, this.connection);
            da.InsertCommand = cmd;

            try
            {
                ODBCHelper.SetParametersForInsertQuery(columnsWithTypes, da);
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
            string query = "select * from " + tableName + " where 1=0;";
            Table table = GetTable(tableName);
            OdbcCommand command = new OdbcCommand(query, this.connection);

            try
            {
                command.Prepare();
                OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);
                table.dataTable = dataSet.Tables[0];
                this.GetTable(tableName).columns = table.dataTable.Columns.Cast<DataColumn>().ToList();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            return (obj is ODBCDatabase)
                && ((ODBCDatabase)obj).connectionString == this.connectionString;
        }
    }
}
