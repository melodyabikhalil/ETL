using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class JoinQuery
    {
        public string queryName { get; set; }
        public string query { get; set; }
        public Database database { get; set; }
        public DataTable dataTable { get; set; }

        public JoinQuery()
        {
            this.dataTable = new DataTable();
        }

        public JoinQuery(string queryName, string query, Database database)
        {
            this.database = database;
            this.query = query;
            this.queryName = queryName;

            this.dataTable = new DataTable();
        }
    }
}
