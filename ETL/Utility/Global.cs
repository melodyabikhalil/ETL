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

        private static List<Database> databasesSource = new List<Database>();
        private static List<Database> databasesDestination = new List<Database>();
        private static Expression expression = Expression.getInstance();

        public static List<Database> DatabasesSource
        {
            get { return databasesSource; }
            set { databasesSource = value; }
        }

        public static List<Database> DatabasesDestination
        {
            get { return databasesDestination; }
            set { databasesDestination = value; }
        }

        public static Expression Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public static Database GetSourceDatabaseByName(string databaseName)
        {
            foreach (Database database in databasesSource)
            {
                if (database.databaseName == databaseName)
                {
                    return database;
                }
            }
            return null;
        }

        public static Database GetDestinationDatabaseByName(string databaseName)
        {
            foreach (Database database in databasesDestination)
            {
                if (database.databaseName == databaseName)
                {
                    return database;
                }
            }
            return null;
        }
    }
}
