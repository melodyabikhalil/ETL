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
                    Database database= JsonToDatabase(data);
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

        public static List<Core.ETL> GetETLsFromJsonFile()
        {
            List<Core.ETL> etls = new List<Core.ETL>();
            try
            {
                string json = ReadAllFile(PATH_ETLS);
                JArray jsonArray = JArray.Parse(json);
                int etlsNumber = jsonArray.Count;
                Core.ETL etl;
                for (int i = 0; i < etlsNumber; ++i)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());
                    string ETLName = data.ETLName;

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
                        continue;
                    }

                    etl = new Core.ETL(ETLName, sourceDatabase, destinationDatabase, sourceTableOrQuery, destinationTable, expressionDt);
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
                return new List<Core.ETL>();
            }
        }

        public static void SaveETL(Core.ETL etl, bool addIfNotExists)
        {
            List<Core.ETL> savedEtls = GetETLsFromJsonFile();
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
    }
}
