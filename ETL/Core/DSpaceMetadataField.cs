using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class DSpaceMetadataField
    {
        public string qualifier { get; set; }
        public string element { get; set; }
        public string name { get; set; }

        public DSpaceMetadataField(string element, string qualifier = null)
        {
            this.qualifier = qualifier;
            this.element = element;
            this.name = this.element;
            if (this.qualifier != null && this.qualifier != "")
            {
                this.name = this.qualifier + "." + this.element;
            }
        }
    }
}
