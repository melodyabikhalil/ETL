using ETL.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Utility
{
    public static class JsonModels
    {
        public static List<JsonDatabase> MapFromListDatabaseToListJsonDatabase(List<Database> databases)
        {
            List<JsonDatabase> jsonDatabases = new List<JsonDatabase>();
            foreach (Database database in databases)
            {
                jsonDatabases.Add(MapFromDatabaseToJsonDatabase(database));
            }
            return jsonDatabases;
        }

        public static JsonDatabase MapFromDatabaseToJsonDatabase(Database database)
        {
            string type = database.type;
            string username = database.username;
            string password = database.password;
            string serverName = database.serverName;
            string databaseName = database.databaseName;

            JsonDatabase jsonDatabase = new JsonDatabase();
            jsonDatabase.type = type;
            jsonDatabase.username = username;
            jsonDatabase.password = password;
            jsonDatabase.databaseName = databaseName;
            jsonDatabase.serverName = serverName;

            jsonDatabase.queries = MapFromListJoinQueriesToListJsonJoinQueries(database.queries);

            switch (type)
            {
                case Database.DATABASE_TYPE_POSTGRES:
                    jsonDatabase.port = ((PostgreSQLDatabase)database).port;
                    jsonDatabase.schema = ((PostgreSQLDatabase)database).schema;
                    break;

                case Database.DATABASE_TYPE_SQLSERVER:
                    jsonDatabase.schema = ((SQLServerDatabase)database).schema;
                    break;

                case Database.DATABASE_TYPE_ACCESS:
                    jsonDatabase.path = ((AccessDatabase)database).path;
                    break;

                case Database.DATABASE_TYPE_ODBC:
                    jsonDatabase.connectionString = ((ODBCDatabase)database).connectionString;
                    break;
            }
            return jsonDatabase;
        }

        public static List<Database> MapFromListJsonDatabaseToListDatabase(List<JsonDatabase> jsonDatabases)
        {
            List<Database> databases = new List<Database>();
            foreach (JsonDatabase jsonDatabase in jsonDatabases)
            {
                databases.Add(MapFromJsonDatabaseToDatabase(jsonDatabase));
            }
            return databases;
        }

        public static Database MapFromJsonDatabaseToDatabase(JsonDatabase jsonDatabase)
        {
            string type = jsonDatabase.type;
            string username = jsonDatabase.username;
            string password = jsonDatabase.password;
            string serverName = jsonDatabase.serverName;
            string databaseName = jsonDatabase.databaseName;
            string port = jsonDatabase.port;
            string schema = jsonDatabase.schema;
            string path = jsonDatabase.path;
            string connectionString = jsonDatabase.connectionString;

            Database database;
            switch (type)
            {
                case Database.DATABASE_TYPE_MYSQL:
                    database = new MySQLDatabase(serverName, username, password, databaseName, schema);
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
                    database = new MySQLDatabase(serverName, username, password, databaseName, schema);
                    break;
            }
            database.Connect();
            database.tablesNames = database.GetTablesNames();
            database.Close();
            database.CreateTablesList(database.tablesNames);
            for (int j = 0; j < database.tablesNames.Count; ++j)
            {
                database.Connect();
                database.SetDatatableSchema(database.tablesNames[j]);
                database.Close();
            }
            database.queries = MapFromListJsonJoinQueriesToListJoinQueries(jsonDatabase.queries);
            database.SetQueriesNamesListFromQueriesList();
            return database;
        }

        public static List<JsonJoinQuery> MapFromListJoinQueriesToListJsonJoinQueries(List<JoinQuery> joinQueries)
        {
            List<JsonJoinQuery> jsonJoinQueries = new List<JsonJoinQuery>();
            foreach (JoinQuery joinQuery in joinQueries)
            {
                jsonJoinQueries.Add(MapFromJoinQueryToJsonJoinQuery(joinQuery));
            }
            return jsonJoinQueries;
        }

        public static JsonJoinQuery MapFromJoinQueryToJsonJoinQuery(JoinQuery joinQuery)
        {
            JsonJoinQuery jsonJoinQuery = new JsonJoinQuery();
            jsonJoinQuery.name = joinQuery.GetName();
            jsonJoinQuery.query = joinQuery.query;
            jsonJoinQuery.type = TableOrQuery.TYPE_JOIN_QUERY;
            jsonJoinQuery.columns = joinQuery.columns;
            return jsonJoinQuery;
        }

        public static List<JoinQuery> MapFromListJsonJoinQueriesToListJoinQueries(List<JsonJoinQuery> jsonJoinQueries)
        {
            List<JoinQuery> joinQueries = new List<JoinQuery>();
            foreach (JsonJoinQuery jsonJoinQuery in jsonJoinQueries)
            {
                joinQueries.Add(MapFromJsonJoinQueryToJoinQuery(jsonJoinQuery));
            }
            return joinQueries;
        }

        public static JoinQuery MapFromJsonJoinQueryToJoinQuery(JsonJoinQuery jsonJoinQuery)
        {
            JoinQuery joinQuery = new JoinQuery();
            joinQuery.SetName(jsonJoinQuery.name);
            joinQuery.query = jsonJoinQuery.query;
            joinQuery.type = TableOrQuery.TYPE_JOIN_QUERY;
            joinQuery.columns = jsonJoinQuery.columns;
            return joinQuery;
        }

        public static JsonSingleEtl MapFromSingleEtlToJsonSingleEtl(SingleETL etl)
        {
            JsonSingleEtl jsonEtl = new JsonSingleEtl();
            jsonEtl.name = etl.name;
            jsonEtl.destDb = MapFromDatabaseToJsonDatabase(etl.destDb);
            jsonEtl.srcDb = MapFromDatabaseToJsonDatabase(etl.srcDb);
            jsonEtl.destTable = MapFromTableToJsonTable(etl.destTable);
            jsonEtl.sourceTable = MapFromTableOrQueryToJsonTableOrQuery(etl.sourceTable);
            jsonEtl.expressionDt = etl.expressionDt;
            jsonEtl.isDspaceDestination = etl.isDspaceDestination;
            jsonEtl.dspacePath = etl.dspacePath;
            return jsonEtl;
        }

        public static SingleETL MapFromJSonSingleEtlToSingleEtl(JsonSingleEtl jsonEtl)
        {
            SingleETL etl = new SingleETL();
            etl.name = jsonEtl.name;
            etl.destDb = MapFromJsonDatabaseToDatabase(jsonEtl.destDb);
            etl.srcDb = MapFromJsonDatabaseToDatabase(jsonEtl.srcDb);
            etl.destTable = MapFromJsonTableToTable(jsonEtl.destTable);
            etl.sourceTable = MapFromJsonTableOrQueryToTableOrQuery(jsonEtl.sourceTable);
            etl.expressionDt = jsonEtl.expressionDt;
            etl.isDspaceDestination = jsonEtl.isDspaceDestination;
            etl.dspacePath = jsonEtl.dspacePath;
            return etl;
        }

        public static JsonTable MapFromTableToJsonTable(Table table)
        {
            JsonTable jsonTable = new JsonTable();
            jsonTable.name = table.GetName();
            jsonTable.query = table.query;
            jsonTable.type = TableOrQuery.TYPE_TABLE;
            return jsonTable;
        }

        public static Table MapFromJsonTableToTable(JsonTable jsonTable)
        {
            Table table = new Table();
            table.SetName(jsonTable.name);
            table.query = jsonTable.query;
            table.type = TableOrQuery.TYPE_TABLE;
            return table;
        }

        public static JsonTableOrQuery MapFromTableOrQueryToJsonTableOrQuery(TableOrQuery tableOrQuery)
        {
            JsonTableOrQuery jsonTableOrQuery = new JsonTableOrQuery();
            jsonTableOrQuery.name = tableOrQuery.GetName();
            jsonTableOrQuery.query = tableOrQuery.query;
            jsonTableOrQuery.type = tableOrQuery.type;
            return jsonTableOrQuery;
        }

        public static TableOrQuery MapFromJsonTableOrQueryToTableOrQuery(JsonTableOrQuery jsonTableOrQuery)
        {
            TableOrQuery tableOrQuery;
            string type = jsonTableOrQuery.type;
            switch(type)
            {
                case TableOrQuery.TYPE_JOIN_QUERY:
                    tableOrQuery = new JoinQuery();
                    break;

                default:
                    tableOrQuery = new Table();
                    break;
            }
            tableOrQuery.SetName(jsonTableOrQuery.name);
            tableOrQuery.query = jsonTableOrQuery.query;
            tableOrQuery.type = jsonTableOrQuery.type;
            return tableOrQuery;
        }

        public static List<JsonSingleEtl> MapFromListSingleETLToJsonSingleEtl(List<SingleETL> etls)
        {
            List<JsonSingleEtl> jsonEtls = new List<JsonSingleEtl>();
            foreach (SingleETL etl in etls)
            {
                jsonEtls.Add(MapFromSingleEtlToJsonSingleEtl(etl));
            }
            return jsonEtls;
        }

        public static List<SingleETL> MapFromListJsonsSingleETLToSingleEtl(List<JsonSingleEtl> jsonSingleEtls)
        {
            List<SingleETL> jsonEtls = new List<SingleETL>();
            foreach (JsonSingleEtl jsonEtl in jsonSingleEtls)
            {
                jsonEtls.Add(MapFromJSonSingleEtlToSingleEtl(jsonEtl));
            }
            return jsonEtls;
        }

        public static JsonJobEtl MapFromJobEtlToJsonJobEtl(JobETL job)
        {
            JsonJobEtl jsonJob = new JsonJobEtl();
            jsonJob.name = job.name;
            jsonJob.etls = MapFromListSingleETLToJsonSingleEtl(job.etls);
            return jsonJob;
        }

        public static List<JsonJobEtl> MapFromListJobEtlToListJsonJobEtl(List<JobETL> jobs)
        {
            List<JsonJobEtl> jsonJobs = new List<JsonJobEtl>();
            foreach (JobETL job in jobs)
            {
                jsonJobs.Add(MapFromJobEtlToJsonJobEtl(job));
            }
            return jsonJobs;
        }

        public static JobETL MapFromJsonJobEtlToJobEtl(JsonJobEtl jsonJob)
        {
            JobETL job = new JobETL();
            job.name = jsonJob.name;
            job.etls = MapFromListJsonsSingleETLToSingleEtl(jsonJob.etls);
            return job;
        }

        public static List<JobETL> MapFromListJsonJobEtlToListJobEtl(List<JsonJobEtl> jsonJobs)
        {
            List<JobETL> jobs = new List<JobETL>();
            foreach (JsonJobEtl jsonJob in jsonJobs)
            {
                jobs.Add(MapFromJsonJobEtlToJobEtl(jsonJob));
            }
            return jobs;
        }
    } 

    public partial class JsonDatabase
    {
        public string username { get; set; }
        public string password { get; set; }
        public string serverName { get; set; }
        public string databaseName { get; set; }
        public string path { get; set; }
        public string port { get; set; }
        public string schema { get; set; }
        public string connectionString { get; set; }

        public List<JsonJoinQuery> queries { get; set; }
        public string type { get; set; }
    }

    public partial class JsonTableOrQuery
    {
        public string type { get; set; }
        public string query { get; set; }
        public string name { get; set; }
    }

    public partial class JsonTable: JsonTableOrQuery
    {
    }

    public partial class JsonJoinQuery: JsonTableOrQuery
    {
        public List<string> columns { get; set; }
    }

    public partial class JsonSingleEtl
    {
        public string name { set; get; }
        public JsonDatabase destDb { set; get; }
        public JsonDatabase srcDb { set; get; }
        public JsonTableOrQuery sourceTable { set; get; }
        public JsonTable destTable { set; get; }
        public DataTable expressionDt { set; get; }
        public bool isDspaceDestination { set; get; }
        public string dspacePath { get; set; }
    }

    public partial class JsonJobEtl
    {
        public string name { get; set; }
        public List<JsonSingleEtl> etls { get; set; }
    }
}
