using ETL.Core;
using ETL.UI;
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
        public const string PATH_LOG_FOLDER = ".\\logs";
        public const string PATH_LOG_FILE = PATH_LOG_FOLDER + "\\logs.txt";

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

        public static bool EtlJobExistsInListOfEtlJobs(List<JobETL> jobs, JobETL job)
        {
            foreach (JobETL existingJob in jobs)
            {
                if (job.Equals(existingJob))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<string> ConvertDataColumnToList(DataTable datatable, string columnName)
        {
            List<string> list = new List<string>();
            try
            {
                list = datatable.Rows.OfType<DataRow>()
                    .Select(dr => dr.Field<string>(columnName)).ToList();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "ConvertDataColumnsToList");
                return new List<string>();
            }
        }

        public static List<string> GetColumnsNamesFromDatatable(DataTable datatable)
        {
            List<string> columnsNames = new List<string>();
            if (datatable == null)
            {
                return columnsNames;
            }
            foreach (DataColumn column in datatable.Columns)
            {
                columnsNames.Add(column.ColumnName);
            }
            return columnsNames;
        }

        public static void ShowDatabaseErrorInProgressForm()
        {
            Global.progressForm.UpdateForm(ProgressForm.ERROR, "");
        }

        public static void ShowJobDone()
        {
            Global.progressForm.UpdateForm(ProgressForm.DONE, "");
        }

        public static void Log(string message, string source)
        {
            string folderPath = PATH_LOG_FOLDER;
            string filePath = PATH_LOG_FILE;
            bool folderExists = true;
            bool fileExists = true;
            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                    if (!File.Exists(filePath))
                    {
                        try
                        {
                            File.Create(filePath);
                        }
                        catch
                        {
                            fileExists = false;
                        }
                    }
                }
                catch
                {
                    folderExists = false;
                }
            }
            if (!File.Exists(filePath))
            {
                try
                {
                    File.Create(filePath);
                }
                catch
                {
                    fileExists = false;
                }
            }

            if (folderExists && fileExists)
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(filePath, true))
                    {
                        string date = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                        string toWrite = date + " : [" + source + "] " + message;
                        file.WriteLine(toWrite);
                        file.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
