using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Utility
{
    static class Helper
    {
        public static DataTable ConvertListToDataTable(List<string> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add();

            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }
    }
}
