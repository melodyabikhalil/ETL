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

        public JobETL()
        {
            etls = new List<SingleETL>();
        }

        public void Run()
        {
            // TODO: do the migration
            //foreach (SingleETL etl in etls)
            //{
            //    etl.srcDb.Select(etl.sourceTable.name, etl.sourceTable.query);
            //    //....
            //}
        }

        public override bool Equals(Object obj)
        {
            return (obj is JobETL)
                && ((JobETL)obj).name == this.name
                 && ((JobETL)obj).etls == this.etls;
        }
    }
}
