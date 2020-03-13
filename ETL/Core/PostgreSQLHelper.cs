using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class PostgreSQLHelper
    {
        public static NpgsqlDbType MapCsharpTypeToNpsglType(Type dataType)
        {
            //by default hatayta bigint
            NpgsqlDbType npgsqlDbType = NpgsqlDbType.Bigint;

            if (dataType == Type.GetType("System.Int32"))
            {
                npgsqlDbType = NpgsqlDbType.Bigint;
            }
            else if (dataType == Type.GetType("System.String"))
            {
                npgsqlDbType = NpgsqlDbType.Text;
            }
            else if (dataType == Type.GetType("System.Boolean"))
            {
                npgsqlDbType = NpgsqlDbType.Boolean;
            }
            else if (dataType == Type.GetType("System.TimeSpan"))
            {
                npgsqlDbType = NpgsqlDbType.Time;
            }
            else if (dataType == Type.GetType("System.Int16"))
            {
                npgsqlDbType = NpgsqlDbType.Smallint;
            }
            else if (dataType == Type.GetType("System.Double"))
            {
                npgsqlDbType = NpgsqlDbType.Double;
            }
            else if (dataType == Type.GetType("System.Char"))
            {
                npgsqlDbType = NpgsqlDbType.InternalChar;
            }
            else if (dataType == Type.GetType("System.DateTime"))
            {
                npgsqlDbType = NpgsqlDbType.Timestamp;
            }
            return npgsqlDbType;
        }

        public static Dictionary<string, NpgsqlDbType> GetsColumnsWithTypes(DataColumnCollection columns)
        {
            Dictionary<string, NpgsqlDbType> columnsWithTypes = new Dictionary<string, NpgsqlDbType>();
            foreach (DataColumn col in columns)
            {
                NpgsqlDbType type = MapCsharpTypeToNpsglType(col.DataType);
                columnsWithTypes.Add(col.ColumnName, type);
            }
            return columnsWithTypes;
        }

        public static string GetValuesStringForInsertQuery(DataColumnCollection columns)
        {
            string values = "(";
            foreach (DataColumn col in columns)
            {
                values += ":" + col.ColumnName + ",";
            }

            values = values.Remove(values.Length - 1);
            values += ")";
            return values;
        }

        public static void SetParametersForInsertQuery(Dictionary<string, NpgsqlDbType> columnsWithTypes, NpgsqlDataAdapter dataAdapter)
        {
            int index = 0;
            foreach (KeyValuePair<string, NpgsqlDbType> column in columnsWithTypes)
            {
                dataAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter(column.Key, column.Value));
                dataAdapter.InsertCommand.Parameters[index].Direction = ParameterDirection.Input;
                dataAdapter.InsertCommand.Parameters[index].SourceColumn = column.Key;
                index++;
            }
        }
    }
}
