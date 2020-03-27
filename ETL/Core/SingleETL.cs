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
        public TableOrQuery sourceTable { set; get; }
        public Table destTable { set; get; }
        public DataTable expressionDt { set; get; }
        public bool isDspaceDestination { get; set; }

        public SingleETL() { }

        public SingleETL(string name, Database srcDb, Database destDb, TableOrQuery sourceTable, Table destTable, DataTable expressionDt)
        {
            this.name = name;
            this.srcDb = srcDb;
            this.destDb = destDb;
            this.sourceTable = sourceTable;
            this.destTable = destTable;
            this.expressionDt = expressionDt;
            isDspaceDestination = false;
        }

        public override bool Equals(Object obj)
        {
            return (obj is SingleETL)
                && ((SingleETL)obj).name == this.name
                 && ((SingleETL)obj).destDb.databaseName == this.destDb.databaseName
                  && ((SingleETL)obj).srcDb.databaseName == this.srcDb.databaseName
                   && ((SingleETL)obj).sourceTable.GetName() == this.sourceTable.GetName()
                  && ((SingleETL)obj).destTable.GetName() == this.destTable.GetName();
        }
    }
}
