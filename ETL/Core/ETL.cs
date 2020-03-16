using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class ETL
    {
        public string ETLName { set; get; }
        public Database destDb { set; get; }
        public Database srcDb { set; get; }
        public SourceTableOrQuery sourceTable { set; get; }
        public Table destTable { set; get; }
        public DataTable expressionDt { set; get; }

        public ETL(string name, Database srcDb, Database destDb, SourceTableOrQuery sourceTable, Table destTable, DataTable expressionDt)
        {
            this.ETLName = name;
            this.srcDb = srcDb;
            this.destDb = destDb;
            this.sourceTable = sourceTable;
            this.destTable = destTable;
            this.expressionDt = expressionDt;
        }
    }
}
