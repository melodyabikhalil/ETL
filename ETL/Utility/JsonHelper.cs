using ETL.Core;
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

        public const string DATABASE_TYPE_MYSQL = "mysql";
        public const string DATABASE_TYPE_POSTGRES = "postgres";
        public const string DATABASE_TYPE_SQLSERVER = "sqlserver";
        public const string DATABASE_TYPE_ACCESS = "access";
        public const string DATABASE_TYPE_ODBC = "odbc";

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
            return success;
        }

        public static bool AppendObjectToJsonFile(string fileName, Object obj)
        {
            bool success = false;

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

        public static List<Database> GetDatabasesFromJsonFile()
        {
            List<Database> databases = new List<Database>();
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
                    case DATABASE_TYPE_MYSQL:
                        database = new MySQLDatabase(serverName, username, password, databaseName);
                        break;

                    case DATABASE_TYPE_POSTGRES:
                        database = new PostgreSQLDatabase(serverName, username, password, databaseName, port, schema);
                        break;

                    case DATABASE_TYPE_SQLSERVER:
                        database = new SQLServerDatabase(serverName, username, password, databaseName, schema);
                        break;

                    case DATABASE_TYPE_ACCESS:
                        database = new AccessDatabase(path);
                        break;

                    case DATABASE_TYPE_ODBC:
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
                databases.Add(database);
            }
            return databases;
        }
    }
}
