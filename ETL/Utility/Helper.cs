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

        // JSON Helper

        public const string JSON_DATABASE_IS_SOURCE = "isSource";
        public const string JSON_DATABASE_SERVER_NAME = "serverName";
        public const string JSON_DATABASE_TYPE = "type";
        public const string JSON_DATABASE_USERNAME = "username";
        public const string JSON_DATABASE_PASSWORD = "password";
        public const string JSON_DATABASE_SCHEMA = "schema";
        public const string JSON_DATABASE_DATABASE_NAME = "databaseName";
        public const string JSON_DATABASE_PATH = "path";
        public const string JSON_DATABASE_PORT = "port";
        public const string JSON_DATABASE_TABLES = "tables";
        public const string JSON_DATABASE_QUERIES = "queries";
        public const string JSON_DATABASE_QUERIES_NAME = "name";
        public const string JSON_DATABASE_QUERIES_QUERY = "query";

        public static dynamic GetJsonArrayFromFile(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                return array;
            }
        }
    }
}
