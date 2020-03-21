using ETL.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Utility
{
    static class Global
    {
        public const string EXPRESSION_TYPE_REPLACE = "Expression";
        public const string EXPRESSION_TYPE_REGEX = "Regular Expression";
        public const string EXPRESSION_TYPE_MAP = "Map";

        private static List<Database> databases = new List<Database>();
        private static Expression expression = Expression.getInstance();
        public static List<SingleETL> etls = new List<SingleETL>();
        public static DataTable mapDt = new DataTable();
        public static List<JobETL> jobETLs = new List<JobETL>();

        static Global()
        {
            mapDt.Columns.Add("SectionName");
            mapDt.Columns.Add("FromValue");
            mapDt.Columns.Add("ToValue");

            DataRow maprow = mapDt.NewRow();
            maprow["SectionName"] = "Gender";
            maprow["FromValue"] = "Female";
            maprow["ToValue"] = 0;
            mapDt.Rows.Add(maprow);

            DataRow maprow2 = mapDt.NewRow();
            maprow2["SectionName"] = "Gender";
            maprow2["FromValue"] = "Male";
            maprow2["ToValue"] = 1;
            mapDt.Rows.Add(maprow2);
        }

        public static List<Database> Databases
        {
            get { return databases; }
            set { databases = value; }
        }

        public static Expression Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public static Database GetDatabaseByName(string databaseName)
        {
            foreach (Database database in databases)
            {
                if (database.databaseName == databaseName)
                {
                    return database;
                }
            }
            return null;
        }

        public static SourceTableOrQuery GetTableByNameAndDbName(string dbName, string tableName)
        {
            Database db = GetDatabaseByName(dbName);
            foreach(Table table in db.tables)
            {
                if(table.tableName == tableName)
                {
                    return table;
                }
            }
            foreach(JoinQuery query in db.queries)
            {
                if(query.queryName == tableName)
                {
                    return query;
                }
            }
            return null;
        }

        public static bool DatabaseAlreadyConnected(Database database)
        {
            return Helper.DatabaseExistsInListOfDatabases(databases, database);
        }

        public static bool EtlAlreadyExists(SingleETL etl)
        {
            return Helper.EtlExistsInListOfEtls(etls, etl);
        }

        public static bool EtlJobAlreadyExists(JobETL job)
        {
            return Helper.EtlJobExistsInListOfEtlJobs(jobETLs, job);
        }

        public static bool EtlJobNameAlreadyExists(string jobName)
        {
            foreach (JobETL job in jobETLs)
            {
                if (job.name == jobName)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<string> GetEtlsNames()
        {
            List<string> etlsNames = new List<string>();
            foreach (SingleETL etl in etls)
            {
                etlsNames.Add(etl.name);
            }
            return etlsNames;
        }

        public static List<SingleETL> GetEtlsFromNames(List<string> etlNames)
        {
            List<SingleETL> etlsToGet = new List<SingleETL>();
            foreach (string etlName in etlNames)
            {
                foreach (SingleETL existingEtl in etls)
                {
                    if (existingEtl.name == etlName)
                    {
                        etlsToGet.Add(existingEtl);
                    }
                }
            }
            return etlsToGet;
        }
    }
}
