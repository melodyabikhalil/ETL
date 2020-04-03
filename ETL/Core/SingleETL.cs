using ETL.Utility;
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

        public SingleETL() { }

        public SingleETL(string name, Database srcDb, Database destDb, TableOrQuery sourceTable, Table destTable, DataTable expressionDt)
        {
            this.name = name;
            this.srcDb = srcDb;
            this.destDb = destDb;
            this.sourceTable = sourceTable;
            this.destTable = destTable;
            this.expressionDt = expressionDt;
        }

        public bool FetchSourceData()
        {
            Database sourceDb = this.srcDb;
            TableOrQuery sourceTableOrQuery = this.sourceTable;

            sourceDb.Close();
            sourceDb.Connect();
            bool selectDataSuccess = sourceDb.Select(sourceTableOrQuery.GetName(), sourceTableOrQuery.type);
            sourceDb.Close();
            return selectDataSuccess;
        }

        public bool CreateDestinationDataTable()
        {
            Database sourceDb = this.srcDb;
            TableOrQuery sourceTableOrQuery = this.sourceTable;

            Database destinationDb = this.destDb;
            Table destinationTable = this.destTable;

            sourceTableOrQuery = sourceDb.GetTableOrQueryByName(sourceTableOrQuery.GetName());
            destinationTable = destinationDb.GetTable(destinationTable.GetName());
            sourceTableOrQuery.dataTable.TableName = sourceTableOrQuery.GetName();
            destinationTable.dataTable.TableName = destinationTable.GetName();
            bool createDestinationDatatableSucess = Expression.AddValuesToDatatableDestination(sourceTableOrQuery.dataTable, destinationTable.dataTable, this.expressionDt, Global.mapDt);
            return createDestinationDatatableSucess;
        }

        public bool InsertDataToDestination()
        {
            Database destinationDb = this.destDb;
            Table destinationTable = this.destTable;

            destinationDb.Close();
            destinationDb.Connect();
            bool insertInDestinationSuccess = destinationDb.Insert(destinationTable.GetName());
            destinationDb.Close();
            return insertInDestinationSuccess;
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
