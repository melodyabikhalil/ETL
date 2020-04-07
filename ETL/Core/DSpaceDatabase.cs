using ETL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class DSpaceDatabase : Database
    {
        public string folderPath { get; set; }
        public List<string> columns { get; set; }
        public DataTable dspaceData { get; set; }

        public DSpaceDatabase() 
            : base(null, null, null, null, null)
        {
            this.type = Database.DATABASE_TYPE_DSPACE;
            this.columns = new List<string>();
            this.SetColumns();
        }

        public void SetColumns()
        {
            List<DSpaceMetadataField> dSpaceMetadataFields = DSpaceHelper.GetMetadataFields();
            foreach (DSpaceMetadataField dSpaceMetadataField in dSpaceMetadataFields)
            {
                columns.Add(dSpaceMetadataField.name);
            }
            columns.Add("path");

            dspaceData = new DataTable();
            dspaceData.TableName = "Dspace table";
            foreach (string field in columns)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = field;
                column.DataType = typeof(string);
                dspaceData.Columns.Add(column);
            }
        }

        public override bool Insert(string tableName)
        {
            DSpaceHelper.CreateItemsRepository(dspaceData, folderPath);
            return true;
        }

        public override bool Close()
        {
            return true;
        }

        public override bool Connect()
        {
            return true;
        }

        public override List<string> GetTablesNames()
        {
            return new List<string>();
        }

        public override bool Select(string tableOrQueryName, string type)
        {
            return true;
        }

        public override bool SetDatatableSchema(string tableName)
        {
            return true;
        }

        public override DataTable TrySelect(string query)
        {
            return new DataTable();
        }

        public override int SelectRowCount(string tableOrQueryName, string type)
        {
            try
            {
                int rows = this.dspaceData.Rows.Count;
                return rows;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "DSpace-SelectRowCount");
                return 0;
            }
        }
    }
}
