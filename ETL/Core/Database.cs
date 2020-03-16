using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    abstract class Database
    {
        public string username { get; set; }
        public string password { get; set; }
        public string serverName { get; set; }
        public string databaseName { get; set; }
        public List<Table> tables { get; set; }
        public List<string> tablesNames { get; set; }
        public List<JoinQuery> queries { get; set; }
        public List<string> queriesNames { get; set; }

        public Database(string serverName, string username, string password, string databaseName)
        {
            this.serverName = serverName;
            this.username = username;
            this.password = password;
            this.databaseName = databaseName;
            this.tables = new List<Table>();
            this.queries = new List<JoinQuery>();
            this.queriesNames = new List<String>();
        }

        public int GetTableIndexByName(string tableName)
        {
            for (int i = 0; i < tables.Count; ++i)
            {
                if (tables[i].tableName == tableName)
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
                if (queries[i].queryName == queryName)
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
                table.tableName = tablesNames[i];
                this.tables.Add(table);
            }
        }

        public Table GetTable(string tableName)
        {
            foreach (Table table in tables)
            {
                if (table.tableName == tableName)
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
                if (query.queryName == queryName)
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
        abstract public bool Select(string tableName, string query);
        abstract public bool SetDatatableSchema(string tableName);

        //for later
        //abstract public void Update(DataTable dataTable);
        //abstract public void Delete(DataTable dataTable);
    }
}
