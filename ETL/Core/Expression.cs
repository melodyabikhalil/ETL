using ETL.UI;
using ETL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class Expression
    {
        public const string EXPRESSION_REPLACE = "Replace";
        public const string EXPRESSION_REGEX = "Reg";
        public const string EXPRESSION_MAP = "Map";

        public DataTable expressionDt;
        public DataTable mapDt;
        private static Expression instance;

        public void SetExpressionDt(DataTable expressionDt)
        {
            this.expressionDt = expressionDt;
        }

        public void SetMapDt(DataTable mapDt)
        {
            this.mapDt = mapDt;
        }

        public static string Replace(string expression, DataRow row)
        {
            string result = expression.ToLower();
            foreach (DataColumn col in row.Table.Columns)
            {
                result = result.Replace("[" + col.ColumnName.ToLower() + "]", row[col].ToString());
            }
            return result;
        }

        public static string Regexp(string expression, DataRow row, string text)
        {
            Regex rg = new Regex(expression);
            Match match = rg.Match(text);
            if (match.Success)
            {
                return match.Value;
            }
            return null;
        }

        public static string GetValue(DataRow expRow, DataRow row, DataTable mapDt)
        {
            string value = "";
            string type = expRow["ExpressionType"].ToString();
            if (type == "Replace")
            {
                value = Replace(expRow["Expression"].ToString(), row);
            }
            if (type == "Reg")
            {
                string replacedText = Replace(expRow["Expression"].ToString(), row);
                value = Regexp(expRow["RegularExpression"].ToString(), row, replacedText);
            }
            if (type == "Map")
            {
                string sectionName = expRow["MappingName"].ToString();
                string fromValue = row[expRow["MapColumnName"].ToString()].ToString().Trim();
                string query = "MappingName = '" + sectionName + "' AND FromValue = '" + fromValue + "'";
                DataRow[] mapRows = mapDt.Select(query);
                value = mapRows[0]["ToValue"].ToString();
            }
            return value;

        }

        public static bool AddValuesToDatatableDestination(DataTable source, DataTable dest, DataTable expressionDt, DataTable mapDt)
        {
            try
            {
                dest.Clear();
                Global.progressForm.UpdateForm(ProgressForm.PROGRESSBAR_MAXIMUM, source.Rows.Count.ToString());
                int rowIndex = 0;
                foreach (DataRow row in source.Rows)
                {
                    ++rowIndex;
                    Global.progressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, rowIndex.ToString());

                    DataRow newRow = dest.NewRow();
                    foreach (DataColumn col in dest.Columns)
                    {
                        DataRow[] expRows = expressionDt.Select("TableNameDest = '" + dest.TableName + "' AND ColumnDest = '" + col.ColumnName + "'");
                        if (expRows.Length > 0)
                        {
                            DataRow expRow = expRows[0];
                            if (expRow["ColumnDest"].ToString() != col.ColumnName.ToString())
                            {
                                continue;
                            }
                            if (col.DataType == Type.GetType("System.Int32"))
                            {
                                Int32.TryParse(GetValue(expRow, row, mapDt), out int value);
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.DateTime"))
                            {
                                DateTime.TryParse(GetValue(expRow, row, mapDt), out DateTime value);
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.String"))
                            {
                                string value = GetValue(expRow, row, mapDt).ToString() ;
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.Int16"))
                            {
                                Int16.TryParse(GetValue(expRow, row, mapDt), out short value);
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.Boolean"))
                            {
                                Boolean.TryParse(GetValue(expRow, row, mapDt), out bool value);
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.TimeSpan"))
                            {
                                TimeSpan.TryParse(GetValue(expRow, row, mapDt), out TimeSpan value);
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.Double"))
                            {
                                Double.TryParse(GetValue(expRow, row, mapDt), out double value);
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.Decimal"))
                            {
                                Decimal.TryParse(GetValue(expRow, row, mapDt), out decimal value);
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.Char"))
                            {
                                Char.TryParse(GetValue(expRow, row, mapDt), out char value);
                                newRow[col] = value;
                            }
                            else if (col.DataType == Type.GetType("System.Byte[]"))
                            {
                                byte[] value;
                                value = Encoding.Default.GetBytes(GetValue(expRow, row, mapDt)).ToArray();
                                newRow[col] = value;
                            }
                            else
                            {
                                string value = GetValue(expRow, row, mapDt).ToString();
                                newRow[col] = value;
                            }
                        }
                    }
                    dest.Rows.Add(newRow);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "CreateDestinationTable");
                return false;
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
            this.expressionDt.Columns.Add("MapColumnName");
            this.expressionDt.Columns.Add("Expression", Type.GetType("System.String"));
            this.expressionDt.Columns.Add("RegularExpression", Type.GetType("System.String"));
            this.expressionDt.Columns.Add("MappingName");
            this.mapDt.Columns.Add("MappingName");
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
