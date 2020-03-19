using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public abstract class SourceTableOrQuery
    {
        public string Type { get; set; }

        public const string TYPE_TABLE = "table";
        public const string TYPE_JOIN_QUERY = "joinQuery";

        abstract public List<string> GetColumnsNames();
    }
}
