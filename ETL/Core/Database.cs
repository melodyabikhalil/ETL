using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public abstract class Database
    {
        public string username { get; set; }
        public string password { get; set; }
        public string serverName { get; set; }
        public string databaseName { get; set; }
        public List<Table> tables { get; set; }
        public List<string> tablesNames { get; set; }
        public List<JoinQuery> queries { get; set; }
        public List<string> queriesNames { get; set; }
        public string type { get; set; }
        public string schema { get; set; }

        public const string DATABASE_TYPE_MYSQL = "MySQL";
        public const string DATABASE_TYPE_POSTGRES = "PostgreSQL";
        public const string DATABASE_TYPE_SQLSERVER = "SQL Server";
        public const string DATABASE_TYPE_ACCESS = "MS Access";
        public const string DATABASE_TYPE_ODBC = "ODBC";
        public const string DATABASE_TYPE_DSPACE = "DSpace";

        public Database(string serverName, string username, string password, string databaseName, string schema = "")
        {
            this.serverName = serverName;
            this.username = username;
            this.password = password;
            this.databaseName = databaseName;
            this.schema = schema;
            this.tables = new List<Table>();
            this.queries = new List<JoinQuery>();
            this.tablesNames = new List<string>();
            this.queriesNames = new List<string>();
        }

        public int GetTableIndexByName(string tableName)
        {
            for (int i = 0; i < tables.Count; ++i)
            {
                if (tables[i].GetName() == tableName)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetQueryIndexByName(string queryName)
        {
            for (int i = 0; i < queries.Count; ++i)
            {
                if (queries[i].GetName() == queryName)
                {
                    return i;
                }
            }
            return -1;
        }

        public void CreateTablesList(List<string> tablesNames)
        {
            Table table;
            for (int i = 0; i < tablesNames.Count; ++i)
            {
                table = new Table();
                table.SetName(tablesNames[i]);
                this.tables.Add(table);
            }
        }

        public Table GetTable(string tableName)
        {
            foreach (Table table in tables)
            {
                if (table.GetName() == tableName)
                {
                    return table;
                }
            }
            return null;
        }

        public JoinQuery GetQuery(string queryName)
        {
            foreach (JoinQuery query in queries)
            {
                if (query.GetName() == queryName)
                {
                    return query;
                }
            }
            return null;
        }

        public List<string> GetColumnsForTable(string tableName)
        {
            List<string> columns = new List<string>();
            this.Connect();
            bool gotTableSchema = this.SetDatatableSchema(tableName);
            this.Close();
            if (!gotTableSchema)
            {
                return columns;
            }
            Table table = this.GetTable(tableName);
            columns = table.GetColumnsNames();
            return columns;
        }

        public List<string> GetQueriesNames()
        {
            List<string> queriesNames = new List<string>();
            foreach (JoinQuery joinQuery in this.queries)
            {
                queriesNames.Add(joinQuery.GetName());
            }
            return queriesNames;
        }

        public void SetQueriesNamesListFromQueriesList()
        {
            this.queriesNames = new List<string>();
            foreach (JoinQuery joinQuery in queries)
            {
                queriesNames.Add(joinQuery.GetName());
            }
        }

        public TableOrQuery GetTableOrQueryByName(string tableOrQueryName)
        {
            foreach (Table table in tables)
            {
                if (table.GetName() == tableOrQueryName)
                {
                    return table;
                }
            }
            foreach (JoinQuery query in queries)
            {
                if (query.GetName() == tableOrQueryName)
                {
                    return query;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return String.Format("Database name:{0}, Username:{1}, Password:{2}, Server name:{3}", this.databaseName, this.username, this.password, this.serverName);
        }

        abstract public List<string> GetTablesNames();
        abstract public bool Connect();
        abstract public bool Close();
        abstract public bool Insert(string tableName);
        abstract public bool Select(string tableOrQueryName, string type);
        abstract public bool SetDatatableSchema(string tableName);
        abstract public DataTable TrySelect(string query);
        abstract public int SelectRowCount(string tableOrQueryName, string type);

        //for later
        //abstract public void Update(DataTable dataTable);
        //abstract public void Delete(DataTable dataTable);
    }
}
