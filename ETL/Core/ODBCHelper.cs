using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    public class ODBCHelper
    {
        public static OdbcType MapCsharpTypeToODBCType(Type dataType)
        {
            OdbcType OdbcDbType = OdbcType.BigInt;

            if (dataType == Type.GetType("System.Int32"))
            {
                OdbcDbType = OdbcType.BigInt;
            }
            else if (dataType == Type.GetType("System.String"))
            {
                OdbcDbType = OdbcType.Text;
            }
            else if (dataType == Type.GetType("System.Boolean"))
            {
                OdbcDbType = OdbcType.Bit;
            }
            else if (dataType == Type.GetType("System.TimeSpan"))
            {
                OdbcDbType = OdbcType.Time;
            }
            else if (dataType == Type.GetType("System.Int16"))
            {
                OdbcDbType = OdbcType.Int;
            }
            else if (dataType == Type.GetType("System.Double"))
            {
                OdbcDbType = OdbcType.Double;
            }
            else if (dataType == Type.GetType("System.Char"))
            {
                OdbcDbType = OdbcType.VarChar;
            }
            else if (dataType == Type.GetType("System.DateTime"))
            {
                OdbcDbType = OdbcType.DateTime;
            }
            else if (dataType == Type.GetType("System.Decimal"))
            {
                OdbcDbType = OdbcType.Decimal;
            }
            else if (dataType == Type.GetType("System.Byte[]"))
            {
                OdbcDbType = OdbcType.VarBinary;
            }
            return OdbcDbType;
        }

        public static Dictionary<string, OdbcType> GetsColumnsWithTypes(DataColumnCollection columns)
        {
            Dictionary<string, OdbcType> columnsWithTypes = new Dictionary<string, OdbcType>();
            foreach (DataColumn col in columns)
            {
                OdbcType type = MapCsharpTypeToODBCType(col.DataType);
                columnsWithTypes.Add(col.ColumnName, type);
            }
            return columnsWithTypes;
        }

        public static string CreateFieldsString(List<string> fieldsList)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            foreach (string field in fieldsList)
            {
                sb.Append(field);
                sb.Append(",");
            }
            sb.Length--;
            sb.Append(")");
            return sb.ToString();

        }

        public static string CreateValuesString(List<string> fieldsList)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            foreach (string field in fieldsList)
            {
                sb.Append("?");
                sb.Append(",");
            }
            sb.Length--;
            sb.Append(")");
            return sb.ToString();

        }

        public static void SetParametersForInsertQuery(Dictionary<string, OdbcType> columnsWithTypes, OdbcDataAdapter dataAdapter)
        {
            int index = 0;
            foreach (KeyValuePair<string, OdbcType> column in columnsWithTypes)
            {
                dataAdapter.InsertCommand.Parameters.Add(new OdbcParameter(column.Key, column.Value));
                dataAdapter.InsertCommand.Parameters[index].Direction = ParameterDirection.Input;
                dataAdapter.InsertCommand.Parameters[index].SourceColumn = column.Key;
                index++;
            }
        }
    }
}
