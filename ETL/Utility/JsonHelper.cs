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
                string json = JsonConvert.SerializeObject(savedDatabases, Formatting.Indented,
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
            List<Database> databases = new List<Database>();
            try
            {
                string json = ReadAllFile(PATH_DATABASES);
                JArray jsonArray = JArray.Parse(json);
                int databasesNumber = jsonArray.Count;
                for (int i = 0; i < databasesNumber; ++i)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());
                    Database database = JsonToDatabase(data);
                    if (database == null)
                    {
                        continue;
                    }

                    database.Connect();
                    database.tablesNames = database.GetTablesNames();
                    database.Close();
                    database.CreateTablesList(database.tablesNames);
                    for (int j = 0; j < database.tablesNames.Count; ++j)
                    {
                        database.SetDatatableSchema(database.tablesNames[j]);
                    }
                    if (!databases.Contains(database))
                    {
                        databases.Add(database);
                    }
                }
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
            List<SingleETL> etls = new List<SingleETL>();
            try
            {
                string json = ReadAllFile(PATH_ETLS);
                JArray jsonArray = JArray.Parse(json);
                int etlsNumber = jsonArray.Count;
                SingleETL etl;
                for (int i = 0; i < etlsNumber; ++i)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());

                    etl = JsonToEtl(data);
                    if (etl == null)
                    {
                        return null;
                    }
                    if (!etls.Contains(etl))
                    {
                        etls.Add(etl);
                    }
                }
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
                string json = JsonConvert.SerializeObject(savedEtls, Formatting.Indented,
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
                string json = JsonConvert.SerializeObject(savedJobs, Formatting.Indented,
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
            List<JobETL> jobs = new List<JobETL>();
            try
            {
                string json = ReadAllFile(PATH_ETL_JOBS);
                JArray jsonArray = JArray.Parse(json);
                int jobsNumber = jsonArray.Count;
                JobETL job = new JobETL();
                for (int i = 0; i < jobsNumber; ++i)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());
                    string jobName = data.name;
                    job.name = jobName;

                    if (data.etls != null)
                    {
                        for (int j = 0; j < data.etls.Count; ++j)
                        {
                            dynamic etlData = JObject.Parse(data.etls[i].ToString());
                            SingleETL etl = JsonToEtl(etlData);
                            if (etl != null && !job.etls.Contains(etl))
                            {
                                job.etls.Add(etl);
                            }
                        }
                    }

                    if (!jobs.Contains(job))
                    {
                        jobs.Add(job);
                    }
                }
                return jobs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<JobETL>();
            }
        }

        public static Database JsonToDatabase(dynamic data)
        {
            try
            {
                string username = data.username;
                string password = data.password;
                string serverName = data.serverName;
                string databaseName = data.databaseName;
                string port = data.port;
                string schema = data.schema;
                string path = data.path;
                string connectionString = data.connectionString;
                string type = data.type;
                Database database;
                switch (type)
                {
                    case Database.DATABASE_TYPE_MYSQL:
                        database = new MySQLDatabase(serverName, username, password, databaseName);
                        break;

                    case Database.DATABASE_TYPE_POSTGRES:
                        database = new PostgreSQLDatabase(serverName, username, password, databaseName, port, schema);
                        break;

                    case Database.DATABASE_TYPE_SQLSERVER:
                        database = new SQLServerDatabase(serverName, username, password, databaseName, schema);
                        break;

                    case Database.DATABASE_TYPE_ACCESS:
                        database = new AccessDatabase(path);
                        break;

                    case Database.DATABASE_TYPE_ODBC:
                        database = new ODBCDatabase(connectionString);
                        break;

                    default:
                        database = new MySQLDatabase(serverName, username, password, databaseName);
                        break;
                }

                if (data.queries != null)
                {
                    for (int j = 0; j < data.queries.Count; ++j)
                    {
                        dynamic queryArray = JObject.Parse(data.queries[j].ToString());
                        JoinQuery joinQuery = JsonToJoinQuery(queryArray);
                        if (joinQuery == null)
                        {
                            continue;
                        }
                        joinQuery.database = database;
                        database.queries.Add(joinQuery);
                    }
                    database.SetQueriesNamesListFromQueriesList();
                }
                return database;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static SourceTableOrQuery JsonToSourceTableOrQuery(dynamic data)
        {
            string type = data.type;
            SourceTableOrQuery sourceTableOrQuery;
            switch (type)
            {
                case SourceTableOrQuery.TYPE_JOIN_QUERY:
                    sourceTableOrQuery = JsonToJoinQuery(data);
                    break;

                default:
                    sourceTableOrQuery = JsonToTable(data);
                    break;
            }
            return sourceTableOrQuery;
        }

        public static JoinQuery JsonToJoinQuery(dynamic data)
        {
            JoinQuery joinQuery = new JoinQuery();
            try
            {
                string queryName = data.queryName;
                string query = data.query;
                dynamic columnsData = data.columns;
                List<string> columns = new List<string>();
                for ( int i = 0; i < columnsData.Count; ++i)
                {
                    columns.Add((string)columnsData[i]);
                }
                if (columns.Count == 0)
                {
                    return null;
                }
                joinQuery.queryName = queryName;
                joinQuery.query = query;
                joinQuery.columns = columns;
                return joinQuery;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static Table JsonToTable(dynamic data)
        {
            Table table = new Table();
            try
            {
                string tableName = data.tableName;
                var columnsJson = JsonConvert.SerializeObject(data.columns);
                List<DataColumn> columns = (List<DataColumn>)JsonConvert.DeserializeObject(columnsJson.ToString(), typeof(List<DataColumn>));
                table.tableName = tableName;
                return table;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static SingleETL JsonToEtl(dynamic data)
        {
            SingleETL etl;
            try
            {
                string ETLName = data.name;

                dynamic sourceDatabaseData = JObject.Parse(data.srcDb.ToString());
                Database sourceDatabase = JsonToDatabase(sourceDatabaseData);

                dynamic destinationDatabaseData = JObject.Parse(data.destDb.ToString());
                Database destinationDatabase = JsonToDatabase(destinationDatabaseData);

                SourceTableOrQuery sourceTableOrQuery = JsonToSourceTableOrQuery(data.sourceTable);
                Table destinationTable = JsonToTable(data.destTable);

                var expressionDatatableJson = JsonConvert.SerializeObject(data.expressionDt);
                DataTable expressionDt = (DataTable)JsonConvert.DeserializeObject(expressionDatatableJson.ToString(), typeof(DataTable));

                if (destinationDatabase == null || sourceDatabase == null || sourceTableOrQuery == null || destinationTable == null || expressionDt == null)
                {
                    return null;
                }

                etl = new SingleETL(ETLName, sourceDatabase, destinationDatabase, sourceTableOrQuery, destinationTable, expressionDt);
                return etl;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
