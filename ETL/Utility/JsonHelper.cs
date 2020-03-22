 using ETL.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Utility
{
    public static class JsonHelper
    {
        public const string PATH_FOLDER_CONFIG = ".\\config";
        public const string PATH_DATABASES = PATH_FOLDER_CONFIG + "\\databases.json";
        public const string PATH_ETLS = PATH_FOLDER_CONFIG + "\\etls.json";
        public const string PATH_ETL_JOBS = PATH_FOLDER_CONFIG + "\\jobs.json";
        public const string PATH_MAP_DT = PATH_FOLDER_CONFIG + "\\mappingDt.json";

        public static bool CreateJsonFolder()
        {
            bool success = false;
            string path = PATH_FOLDER_CONFIG;
            if (Directory.Exists(path))
            {
                success = true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(path);
                    success = true;
                }
                catch
                {
                    success = false;
                }
            }

            if (success && !File.Exists(PATH_DATABASES))
            {
                File.Create(PATH_DATABASES);
            }

            return success;
        }

        public static string ReadAllFile(string path)
        {
            string text = "";
            try
            {
                text = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return text;
        }

        public static void SaveDatabase(Database database, bool addIfNotExists)
        {
            List<Database> savedDatabases = GetDatabasesFromJsonFile();
            bool databaseAlreadySaved = Helper.DatabaseExistsInListOfDatabases(savedDatabases, database);

            if (databaseAlreadySaved)
            {
                savedDatabases.Remove(database);
            }
                
            if (databaseAlreadySaved  || (!databaseAlreadySaved && addIfNotExists))
            {
                savedDatabases.Add(database);
                List<JsonDatabase> jsonDatabases = JsonModels.MapFromListDatabaseToListJsonDatabase(savedDatabases);
                string json = JsonConvert.SerializeObject(jsonDatabases, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                File.WriteAllText(PATH_DATABASES, string.Empty);
                File.WriteAllText(PATH_DATABASES, json);
            }
        }

        public static List<Database> GetDatabasesFromJsonFile()
        {
            try
            {
                string json = ReadAllFile(PATH_DATABASES);
                List<JsonDatabase> jsonDatabases = JsonConvert.DeserializeObject<List<JsonDatabase>>(json);
                List<Database> databases = JsonModels.MapFromListJsonDatabaseToListDatabase(jsonDatabases);
                return databases;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Database>();
            }
        }

        public static List<SingleETL> GetETLsFromJsonFile()
        {
            try
            {
                string json = ReadAllFile(PATH_ETLS);
                List<JsonSingleEtl> jsonEtls = JsonConvert.DeserializeObject<List<JsonSingleEtl>>(json);
                List<SingleETL> etls = JsonModels.MapFromListJsonsSingleETLToSingleEtl(jsonEtls);
                return etls;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<SingleETL>();
            }
        }

        public static DataTable GetMapDtFromJsonFile()
        {
            try
            {
                string json = ReadAllFile(PATH_MAP_DT);
                DataTable mapDt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                if(mapDt == null ||mapDt.Rows.Count == 0)
                {
                    mapDt = new DataTable();
                    mapDt.Columns.Add("Section Name");
                    mapDt.Columns.Add("From Value");
                    mapDt.Columns.Add("To Value");
                }
                return mapDt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new DataTable();
            }
        }

        public static void RemoveETL(SingleETL etl)
        {
            List<SingleETL> savedEtls = GetETLsFromJsonFile();
            savedEtls.Remove(etl);
            string json = JsonConvert.SerializeObject(savedEtls, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            File.WriteAllText(PATH_ETLS, string.Empty);
            File.WriteAllText(PATH_ETLS, json);

        }
        public static void SaveETL(SingleETL etl, bool addIfNotExists)
        {
            List<SingleETL> savedEtls = GetETLsFromJsonFile();
            bool etlAlreadySaved = Helper.EtlExistsInListOfEtls(savedEtls, etl);

            if (etlAlreadySaved)
            {
                savedEtls.Remove(etl);
            }

            if (etlAlreadySaved || (!etlAlreadySaved && addIfNotExists))
            {
                savedEtls.Add(etl);
                List<JsonSingleEtl> jsonEtls = JsonModels.MapFromListSingleETLToJsonSingleEtl(savedEtls);
                string json = JsonConvert.SerializeObject(jsonEtls, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                File.WriteAllText(PATH_ETLS, string.Empty);
                File.WriteAllText(PATH_ETLS, json);
            }
        }

        public static void SaveEtlJob(JobETL job, bool addIfNotExists)
        {
            List<JobETL> savedJobs = GetETLJobsFromJsonFile();
            bool jobAlreadySaved = Helper.EtlJobExistsInListOfEtlJobs(savedJobs, job);

            if (jobAlreadySaved)
            {
                savedJobs.Remove(job);
            }

            if (jobAlreadySaved || (!jobAlreadySaved && addIfNotExists))
            {
                savedJobs.Add(job);
                List<JsonJobEtl> jsonJobs = JsonModels.MapFromListJobEtlToListJsonJobEtl(savedJobs);
                string json = JsonConvert.SerializeObject(jsonJobs, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
              
                File.WriteAllText(PATH_ETL_JOBS, string.Empty);
                File.WriteAllText(PATH_ETL_JOBS, json);
            }
        }

        public static void SaveMapDt(DataTable mapDt)
        {
            string json = JsonConvert.SerializeObject(mapDt, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            File.WriteAllText(PATH_MAP_DT, string.Empty);
            File.WriteAllText(PATH_MAP_DT, json);
        }

        public static List<JobETL> GetETLJobsFromJsonFile()
        {
            try
            {
                string json = ReadAllFile(PATH_ETL_JOBS);
                List<JsonJobEtl> jsonJobs = JsonConvert.DeserializeObject<List<JsonJobEtl>>(json);
                List<JobETL> jobs = JsonModels.MapFromListJsonJobEtlToListJobEtl(jsonJobs);
                return jobs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<JobETL>();
            }
        }
    }
}
