using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ETL.Core
{
    class Expression
    {
        public const string EXPRESSION_REPLACE = "Replace";
        public const string EXPRESSION_REGEX = "Reg";
        public const string EXPRESSION_MAP = "Map";

        public DataTable expressionDt;
        public DataTable mapDt;
        private static Expression instance;

        public static string Replace(string expression, DataRow row)
        {
            string result = expression;
            foreach (DataColumn col in row.Table.Columns)
            {
                result = result.Replace(col.ColumnName, row[col].ToString());
            }
            return result;
        }

        public static string Regexp(string expression, DataRow row, string regexColumnName)
        {
            Regex rg = new Regex(expression);
            Match match = rg.Match(row[regexColumnName].ToString());
            if (match.Success)
            {
                return match.Value;
            }
            return null;
        }

        public static string GetValue(DataRow expRow, DataRow row, DataColumn col, DataTable mapDt)
        {
            string value = "";
            string type = expRow["ExpressionType"].ToString();
            if (type == "Replace")
            {
                value = Replace(expRow["Expression"].ToString(), row);
            }
            if (type == "Reg")
            {
                value = Regexp(expRow["Expression"].ToString(), row, expRow["RegexpColumnName"].ToString());
            }
            if (type == "Map")
            {
                string sectionName = expRow["SectionName"].ToString();
                string fromValue = row[col.ColumnName].ToString();
                DataRow[] mapRows = mapDt.Select("SectionName = '" + sectionName + "' AND FromValue = '" + fromValue + "'");
                value = mapRows[0]["ToValue"].ToString();
            }
            return value;

        }

        public static void AddValuesToDatatableDestination(DataTable source, DataTable dest, DataTable expressionDt, DataTable mapDt)
        {
            foreach (DataRow row in source.Rows)
            {
                DataRow newRow = dest.NewRow();
                foreach (DataColumn col in dest.Columns)
                {
                    DataRow[] expRows = expressionDt.Select("TableNameDest = '" + dest.TableName + "' AND ColumnDest = '" + col.ColumnName + "'");
                    DataRow expRow = expRows[0];
                    string value = GetValue(expRow, row, col, mapDt);
                    newRow[col] = value;
                }
                dest.Rows.Add(newRow);
            }
        }

        private Expression()
        {
            //we have to construct the datatables expressionDt and mapDt
            this.expressionDt = new DataTable();
            this.mapDt = new DataTable();
            this.expressionDt.Columns.Add("TableNameDest");
            this.expressionDt.Columns.Add("ColumnDest");
            this.expressionDt.Columns.Add("ExpressionType");
            this.expressionDt.Columns.Add("RegexpColumnName");
            this.expressionDt.Columns.Add("Expression", Type.GetType("System.String"));
            this.expressionDt.Columns.Add("SectionName");
            this.mapDt.Columns.Add("SectionName");
            this.mapDt.Columns.Add("FromValue");
            this.mapDt.Columns.Add("ToValue");
        }

        public static Expression getInstance()
        {
            //lazy initialization
            if (instance == null)
            {
                instance = new Expression();
            }
            return instance;
        }
    }
}
