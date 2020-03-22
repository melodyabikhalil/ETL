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
        public static List<JobETL> jobETLs = new List<JobETL>();
        public static DataTable mapDt = expression.mapDt;
        
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

        public static TableOrQuery GetTableByNameAndDbName(string dbName, string tableName)
        {
            Database db = GetDatabaseByName(dbName);
            foreach(Table table in db.tables)
            {
                if(table.GetName() == tableName)
                {
                    return table;
                }
            }
            foreach(JoinQuery query in db.queries)
            {
                if(query.GetName() == tableName)
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

        public static JobETL GetJobByName(string jobName)
        {
            foreach (JobETL existingJob in jobETLs)
            {
                if (existingJob.name == jobName)
                {
                    return existingJob;
                }
            }
            return null;
        }
    }
}
