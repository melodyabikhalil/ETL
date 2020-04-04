using ETL.UI;
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
                Global.progressForm.UpdateForm(ProgressForm.LABEL_ETL, etl.name);
                bool selectDataSuccess = etl.FetchSourceData();
                if (selectDataSuccess)
                {
                    bool createDestinationDatatableSucess = etl.CreateDestinationDataTable();
                    if (createDestinationDatatableSucess)
                    {
                        bool insertInDestinationSuccess = etl.InsertDataToDestination();
                        if (!insertInDestinationSuccess)
                        {
                            Helper.ShowDatabaseErrorInProgressForm();
                        }
                    } 
                    else
                    {
                        Helper.ShowDatabaseErrorInProgressForm();
                    }
                }
                else
                {
                    Helper.ShowDatabaseErrorInProgressForm();
                }
            }
            Helper.ShowJobDone();
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

        public override bool Equals(Object obj)
        {
            return (obj is JobETL)
                && ((JobETL)obj).name == this.name;
        }
    }
}
