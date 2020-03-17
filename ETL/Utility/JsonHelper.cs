using ETL.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        public static void SaveDatabase(Database database, string type)
        {
            List<Database> savedDatabases = GetDatabasesFromJsonFile();
            if (!Helper.DatabaseExistsInListOfDatabases(savedDatabases, database))
            {
                JObject databaseObject = JObject.FromObject(database);
                databaseObject.Add("type", type);

                JArray databasesJsonArray = new JArray();

                string databasesJson = ReadAllFile(PATH_DATABASES);
                if (databasesJson != "" && databasesJson != null)
                {
                    databasesJsonArray = JArray.Parse(databasesJson);
                }

                databasesJsonArray.Add(databaseObject);

                File.WriteAllText(PATH_DATABASES, string.Empty);
                File.WriteAllText(PATH_DATABASES, databasesJsonArray.ToString());
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
                            continue;
                    }

                    if (data.queries != null)
                    {
                        for (int j = 0; j < data.queries.Count; ++j)
                        {
                            dynamic queryArray = JObject.Parse(data.queries[j].ToString());
                            string queryName = queryArray.queryName;
                            string query = queryArray.query;
                            JoinQuery joinQuery = new JoinQuery();
                            joinQuery.queryName = queryName;
                            joinQuery.query = query;
                            joinQuery.database = database;
                            database.queries.Add(joinQuery);
                        }
                        database.SetQueriesNamesListFromQueriesList();
                    }

                    database.Connect();
                    database.tablesNames = database.GetTablesNames();
                    database.Close();
                    database.CreateTablesList(database.tablesNames);
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
    }
}
