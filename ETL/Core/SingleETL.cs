using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class SingleETL
    {
        public string name { set; get; }
        public Database destDb { set; get; }
        public Database srcDb { set; get; }
        public SourceTableOrQuery sourceTable { set; get; }
        public Table destTable { set; get; }
        public DataTable expressionDt { set; get; }

        public SingleETL(string name, Database srcDb, Database destDb, SourceTableOrQuery sourceTable, Table destTable, DataTable expressionDt)
        {
            this.name = name;
            this.srcDb = srcDb;
            this.destDb = destDb;
            this.sourceTable = sourceTable;
            this.destTable = destTable;
            this.expressionDt = expressionDt;
        }

        public override bool Equals(Object obj)
        {
            return (obj is SingleETL)
                && ((SingleETL)obj).name == this.name
                 && ((SingleETL)obj).destDb == this.destDb
                  && ((SingleETL)obj).srcDb == this.srcDb
                   && ((SingleETL)obj).sourceTable == this.sourceTable
                  && ((SingleETL)obj).destTable == this.destTable
                  && ((SingleETL)obj).expressionDt == this.expressionDt;
        }
    }
}
