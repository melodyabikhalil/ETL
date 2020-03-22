using ETL.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Utility
{
    class JsonModels
    {
    }

    public partial class JsonDatabase
    {
        public string username { get; set; }
        public string password { get; set; }
        public string serverName { get; set; }
        public string databaseName { get; set; }
        public string path { get; set; }
        public string port { get; set; }
        public string schema { get; set; }
        public string connectionString { get; set; }

        public List<string> tablesNames { get; set; }
        public List<JsonJoinQuery> queries { get; set; }
        public string type { get; set; }
    }

    public partial class JsonTableOrQuery
    {
        public string type { get; set; }
        public string query { get; set; }
        protected string name { get; set; }
    }

    public partial class JsonTable: JsonTableOrQuery
    {
        public string type = TableOrQuery.TYPE_TABLE;
    }

    public partial class JsonJoinQuery: JsonTableOrQuery
    {
        public string type = TableOrQuery.TYPE_JOIN_QUERY;
    }

public partial class JsonSingleEtl
    {
        public string name { set; get; }
        public JsonDatabase destDb { set; get; }
        public JsonDatabase srcDb { set; get; }
        public JsonTableOrQuery sourceTable { set; get; }
        public Table destTable { set; get; }
        public DataTable expressionDt { set; get; }
    }
}
