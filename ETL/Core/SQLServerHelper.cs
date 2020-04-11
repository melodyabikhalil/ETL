using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class SQLServerHelper
    {
        public static SqlDbType MapCsharpTypeToSQLType(Type dataType)
        {
            SqlDbType sqlDbType = SqlDbType.Int;

            if (dataType == Type.GetType("System.Int32"))
            {
                sqlDbType = SqlDbType.BigInt;
            }
            else if (dataType == Type.GetType("System.String"))
            {
                sqlDbType = SqlDbType.Text;
            }
            else if (dataType == Type.GetType("System.Boolean"))
            {
                sqlDbType = SqlDbType.Bit;
            }
            else if (dataType == Type.GetType("System.TimeSpan"))
            {
                sqlDbType = SqlDbType.Time;
            }
            else if (dataType == Type.GetType("System.Int16"))
            {
                sqlDbType = SqlDbType.SmallInt;
            }
            else if (dataType == Type.GetType("System.Double"))
            {
                sqlDbType = SqlDbType.Float;
            }
            else if (dataType == Type.GetType("System.Char"))
            {
                sqlDbType = SqlDbType.Char;
            }
            else if (dataType == Type.GetType("System.DateTime"))
            {
                sqlDbType = SqlDbType.DateTime;
            }
            else if (dataType == Type.GetType("System.Decimal"))
            {
                sqlDbType = SqlDbType.Decimal;
            }
            else if (dataType == Type.GetType("System.Byte[]"))
            {
                sqlDbType = SqlDbType.VarBinary;
            }
            return sqlDbType;
        }

        public static Dictionary<string, SqlDbType> GetsColumnsWithTypes(DataColumnCollection columns)
        {
            Dictionary<string, SqlDbType> columnsWithTypes = new Dictionary<string, SqlDbType>();
            foreach (DataColumn col in columns)
            {
                SqlDbType type = MapCsharpTypeToSQLType(col.DataType);
                columnsWithTypes.Add(col.ColumnName, type);
            }
            return columnsWithTypes;
        }

        public static string GetValuesStringForInsertQuery(DataColumnCollection columns)
        {
            string values = "(";
            foreach (DataColumn col in columns)
            {
                values += "@" + col.ColumnName + ",";
            }

            values = values.Remove(values.Length - 1);
            values += ")";
            return values;
        }

        public static void SetParametersForInsertQuery(Dictionary<string, SqlDbType> columnsWithTypes, SqlCommand command, Table table)
        {
            foreach (KeyValuePair<string, SqlDbType> column in columnsWithTypes)
            {
                command.Parameters.Add("@" + column.Key, column.Value, table.GetColumnByName(column.Key).MaxLength, column.Key);
            }
        }
    }
}
