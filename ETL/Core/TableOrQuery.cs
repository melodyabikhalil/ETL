using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public abstract class TableOrQuery
    {
        public string type { get; set; }
        public string query { get; set; }
        public DataTable dataTable { get; set; }
        protected string name;

        public const string TYPE_TABLE = "table";
        public const string TYPE_JOIN_QUERY = "joinQuery";

        abstract public List<string> GetColumnsNames();
        abstract public void SetName(string name);
        abstract public string GetName();
    }
}
