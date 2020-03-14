using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class JoinQuery
    {
        public string queryName { get; set; }
        public string query { get; set; }
        public Database database { get; set; }
        
        //public JoinQuery() { }

        public JoinQuery(string queryName, string query, Database database)
        {
            this.database = database;
            this.query = query;
            this.queryName = queryName;
        }
    }
}
