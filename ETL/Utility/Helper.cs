using ETL.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        public static List<string> SelectOneColumnFromDataTable(DataTable datatable, string columnName)
        {
            List<string> values = new List<string>();
            foreach (DataRow dataRow in datatable.Rows)
            {
                if (columnName != null)
                {
                    values.Add(dataRow.Field<string>(columnName));
                }
            }
            return values;
        }

        public static HashSet<string> ConvertListToSet(List<string> list)
        {
            HashSet<string> hashSet = new HashSet<string>(list);
            return hashSet;
        }

        public static List<string> GetColumnsFromTables(HashSet<string> tablesNames, Database database)
        {
            List<string> columns = new List<string>();
            List<string> columnsForTable = new List<string>();
            List<string> columnsNameWithTableName = new List<string>();
            foreach (string tableName in tablesNames)
            {
                if (tableName != null && tableName != "")
                {
                    columnsForTable = database.GetColumnsForTable(tableName);
                    columnsNameWithTableName = new List<string>();
                    foreach (string columnName in columnsForTable)
                    {
                        columnsNameWithTableName.Add(tableName + "." + columnName);
                    }
                    columns.AddRange(columnsNameWithTableName);
                }
            }
            return columns;
        }

        public static DataTable DuplicateDatatableColumnWithValues(DataTable datatable, string columnName, string newColumnName)
        {
            DataColumn dataColumn = new DataColumn(newColumnName, typeof(string));
            datatable.Columns.Add(dataColumn);
            foreach (DataRow row in datatable.Rows)
            {
                row[newColumnName] = row[columnName];
            }
            return datatable;
        }

        public static bool DatabaseExistsInListOfDatabases(List<Database> databases, Database database)
        {
            foreach (Database existingDatabase in databases)
            {
                if (database.Equals(existingDatabase))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool EtlExistsInListOfEtls(List<SingleETL> etls, SingleETL etl)
        {
            foreach (SingleETL existingEtls in etls)
            {
                if (etl.Equals(existingEtls))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
