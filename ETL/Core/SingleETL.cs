using ETL.UI;
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
            this.isDspaceDestination = false;
        }

        public bool FetchSourceData()
        {
            Global.progressForm.UpdateForm(ProgressForm.LABEL_ACTION, "Fetching source data...");

            Database sourceDb = this.srcDb;
            TableOrQuery sourceTableOrQuery = this.sourceTable;

            sourceDb.Close();
            sourceDb.Connect();
            int count = sourceDb.SelectRowCount(sourceTableOrQuery.GetName(), sourceTableOrQuery.type);
            Global.ProgressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, "0");
            Global.ProgressForm.UpdateForm(ProgressForm.PROGRESSBAR_MAXIMUM, count.ToString());
            bool selectDataSuccess = sourceDb.Select(sourceTableOrQuery.GetName(), sourceTableOrQuery.type);
            sourceDb.Close();
            return selectDataSuccess;
        }

        public bool CreateDestinationDataTable()
        {
            Global.progressForm.UpdateForm(ProgressForm.LABEL_ACTION, "Creating destination table...");
            Global.ProgressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, "0");

            //Source database & table setup
            Database sourceDb = this.srcDb;
            TableOrQuery sourceTableOrQuery = this.sourceTable;
            sourceTableOrQuery = sourceDb.GetTableOrQueryByName(sourceTableOrQuery.GetName());
            sourceTableOrQuery.dataTable.TableName = sourceTableOrQuery.GetName();

            //Destination database & table setup
            Database destinationDb = this.destDb;
            DataTable destinationDt;
            if (!this.isDspaceDestination)
            {
                Table destinationTable = destinationDb.GetTable(this.destTable.GetName());
                destinationTable.dataTable.TableName = destinationTable.GetName();
                destinationDt = destinationTable.dataTable;
            }
            else
            {
                destinationDt = ((DSpaceDatabase)destinationDb).dspaceData;
            }

            bool createDestinationDatatableSucess = Expression.AddValuesToDatatableDestination(sourceTableOrQuery.dataTable, destinationDt, this.expressionDt, Global.mapDt);
            return createDestinationDatatableSucess;
        }

        public bool InsertDataToDestination()
        {
            Global.progressForm.UpdateForm(ProgressForm.LABEL_ACTION, "Inserting data into destination table...");
            Database destinationDb = this.destDb;
            Table destinationTable = new Table();
            string destinationTableName = "";
            if (!this.isDspaceDestination)
            {
                destinationTable = this.destTable;
                destinationTable = destinationDb.GetTable(destinationTable.GetName());
                destinationTable.dataTable.TableName = destinationTable.GetName();
                destinationTableName = destinationTable.GetName();
            }
            
            Global.progressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, "0");
            Global.progressForm.UpdateForm(ProgressForm.PROGRESSBAR_MAXIMUM, destinationTable.dataTable.Rows.Count.ToString());
            destinationDb.Close();
            destinationDb.Connect();
            bool insertInDestinationSuccess = destinationDb.Insert(destinationTableName);
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
