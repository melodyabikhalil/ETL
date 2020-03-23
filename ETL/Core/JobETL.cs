using ETL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class JobETL
    {
        public string name { get; set; }
        public List<SingleETL> etls { get; set; }
        public List<SingleETL> errorEtls { get; set; }

        public JobETL()
        {
            etls = new List<SingleETL>();
            errorEtls = new List<SingleETL>();
        }

        public void Run()
        {
            foreach (SingleETL etl in etls)
            {
                Database sourceDb = etl.srcDb;
                TableOrQuery sourceTableOrQuery = etl.sourceTable;

                Database destinationDb = etl.destDb;
                Table destinationTable = etl.destTable;

                sourceDb.Close();
                sourceDb.Connect();
                bool selectDataSuccess = sourceDb.Select(sourceTableOrQuery.GetName(), sourceTableOrQuery.type);
                sourceDb.Close();
                if (selectDataSuccess)
                {
                    sourceTableOrQuery = sourceDb.GetTableOrQueryByName(sourceTableOrQuery.GetName());
                    destinationTable = destinationDb.GetTable(destinationTable.GetName());
                    sourceTableOrQuery.dataTable.TableName = sourceTableOrQuery.GetName();
                    destinationTable.dataTable.TableName = destinationTable.GetName();
                    bool createDestinationDatatableSucess = Expression.AddValuesToDatatableDestination(sourceTableOrQuery.dataTable, destinationTable.dataTable, etl.expressionDt, Global.mapDt);
                    if (createDestinationDatatableSucess)
                    {
                        destinationDb.Close();
                        destinationDb.Connect();
                        bool insertInDestinationSuccess = destinationDb.Insert(destinationTable.GetName());
                        destinationDb.Close();
                        if (insertInDestinationSuccess)
                        {
                            LogError(etl);
                        }
                    }
                }
            }
        }

        public void ReplaceEtlInJob(SingleETL etl)
        {
            foreach (SingleETL existingEtl in etls)
            {
                if (etl.Equals(existingEtl))
                {
                    existingEtl.expressionDt = etl.expressionDt;
                    return;
                }
            }
        }

        public void LogError(SingleETL etl)
        {
            this.errorEtls.Add(etl);
            Console.WriteLine("Error in etl named: " + etl.name + " has failed");
        }

        public override bool Equals(Object obj)
        {
            return (obj is JobETL)
                && ((JobETL)obj).name == this.name;
        }
    }
}
