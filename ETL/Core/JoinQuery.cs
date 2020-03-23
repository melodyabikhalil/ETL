using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class JoinQuery: TableOrQuery
    {
        public string mainTableName { get; set; }
        public List<string> columnsToSelect { get; set; }
        public List<string> columns { get; set; }
        public Database database { get; set; }
        public DataTable queryDatatable { get; set; }

        public JoinQuery()
        {
            this.name = "";
            this.queryDatatable = new DataTable();
            this.dataTable = new DataTable();
            this.columns = new List<string>();
            this.columnsToSelect = new List<string>();
            this.type = TableOrQuery.TYPE_JOIN_QUERY;
        }

        public JoinQuery(string name, string query, Database database)
        {
            this.database = database;
            this.query = query;
            this.name = name;

            this.dataTable = new DataTable();
            this.queryDatatable = new DataTable();
            this.columns = new List<string>();
            this.columnsToSelect = new List<string>();
            this.type = TableOrQuery.TYPE_JOIN_QUERY;
        }

        public void CreateAndSetJoinQuery()
        {
            bool hasSchema = this.database.schema != "" && this.database.schema != null;
            string query = "SELECT ";
            foreach (string column in columnsToSelect)
            {
                query += column + ",";
            }
            query = query.Remove(query.Length - 1);
            if (hasSchema)
            {
                query += " \nFROM " + this.database.schema + ".\"" + mainTableName + "\"";
            }
            else
            {
                query += " \nFROM " + mainTableName;
            }
            foreach (DataRow datarow in queryDatatable.Rows)
            {
                string joinType = datarow.Field<string>("Join Type");
                string table1 = datarow.Field<string>("Table 1");
                string table2 = datarow.Field<string>("Table 2");
                string column1 = datarow.Field<string>("Column 1");
                string column2 = datarow.Field<string>("Column 2");
                if (joinType == null || table1 == null || table2 == null || column1 == null || column2 == null)
                {
                    continue;
                }
                if (hasSchema)
                {
                    table1 = this.database.schema + ".\"" + table1 + "\"";
                    table2 = this.database.schema + ".\"" + table2 + "\"";
                }
                query += " \n" + joinType + " " + table1 + " ON " + table1 + "." + column1 + "=" + table2 + "." + column2;
            }
            query += ";";
            this.query = query;
        }

        public void SetColumnsList(List<string> columns)
        {
            this.columns = columns;
        }

        public static void SetSelectedColumnsList(DataTable selectedColumnsDatatable, JoinQuery joinQuery)
        {
            joinQuery.columnsToSelect = new List<string>();
            joinQuery.columns = new List<string>();
            foreach (DataRow datarow in selectedColumnsDatatable.Rows)
            {
                bool isSelected = datarow.Field<bool>("Column1");
                string columnName = datarow.Field<string>("Column Name");
                string columnAlias = datarow.Field<string>("AS");
                if (isSelected)
                {
                    joinQuery.columns.Add(columnAlias);
                    if (columnName == columnAlias)
                    {
                        joinQuery.columnsToSelect.Add(columnName);
                    }
                    else
                    {
                        joinQuery.columnsToSelect.Add(columnName + " AS " + columnAlias);
                    }
                }
            }
        }

        public override List<string> GetColumnsNames()
        {
            return this.columns;
        }

        public override bool Equals(Object obj)
        {
            return (obj is JoinQuery)
                && ((JoinQuery)obj).name == this.name
                 && ((JoinQuery)obj).columns == this.columns
                 && ((JoinQuery)obj).query == this.query;
        }

        public override void SetName(string name)
        {
            this.name = name;
        }

        public override string GetName()
        {
            return this.name;
        }
    }
}
