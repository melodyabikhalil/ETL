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

        public static bool EtlAlreadyConnected(SingleETL etl)
        {
            return Helper.EtlExistsInListOfEtls(etls, etl);
        }
    }
}
