using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class JoinQuery: SourceTableOrQuery
    {
        public string queryName { get; set; }
        public string query { get; set; }
        public Database database { get; set; }
        public List<DataColumn> columns { get; set; }

        //public JoinQuery() { }

        public JoinQuery(string queryName, string query, Database database)
        {
            this.database = database;
            this.query = query;
            this.queryName = queryName;
        }

        public override List<string> GetColumnsNames()
        {
            List<string> columnsNames = new List<string>();
            for (int i = 0; i < columns.Count; ++i)
            {
                columnsNames.Add(columns[i].ColumnName);
            }
            return columnsNames;
        }
    }
}
