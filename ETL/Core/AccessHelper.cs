using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class AccessHelper
    {
        public static OleDbType MapCsharpTypeToAccessType(Type dataType)
        {
            OleDbType olelDbType = OleDbType.BigInt;

            if (dataType == Type.GetType("System.Int32"))
            {
                olelDbType = OleDbType.BigInt;
            }
            else if (dataType == Type.GetType("System.String"))
            {
                olelDbType = OleDbType.VarChar;
            }
            else if (dataType == Type.GetType("System.Boolean"))
            {
                olelDbType = OleDbType.Boolean;
            }
            else if (dataType == Type.GetType("System.TimeSpan"))
            {
                olelDbType = OleDbType.DBTime;
            }
            else if (dataType == Type.GetType("System.Int16"))
            {
                olelDbType = OleDbType.SmallInt;
            }
            else if (dataType == Type.GetType("System.Double"))
            {
                olelDbType = OleDbType.Double;
            }
            else if (dataType == Type.GetType("System.Char"))
            {
                olelDbType = OleDbType.Char;
            }
            else if (dataType == Type.GetType("System.DateTime"))
            {
                olelDbType = OleDbType.DBTimeStamp;
            }
            else if (dataType == Type.GetType("System.Decimal"))
            {
                olelDbType = OleDbType.Decimal;
            }
            else if (dataType == Type.GetType("System.Byte[]"))
            {
                olelDbType = OleDbType.VarBinary;
            }
            return olelDbType;
        }

        public static Dictionary<string, OleDbType> GetsColumnsWithTypes(DataColumnCollection columns)
        {
            Dictionary<string, OleDbType> columnsWithTypes = new Dictionary<string, OleDbType>();
            foreach (DataColumn col in columns)
            {
                OleDbType type = MapCsharpTypeToAccessType(col.DataType);
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
                sb.Append("[");
                sb.Append(field);
                sb.Append("],");
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
                sb.Append("@");
                sb.Append(field);
                sb.Append(",");
            }
            sb.Length--;
            sb.Append(")");
            return sb.ToString();

        }

        public static void SetParametersForInsertQuery(Dictionary<string, OleDbType> columnsWithTypes, OleDbDataAdapter dataAdapter)
        {
            int index = 0;
            foreach (KeyValuePair<string, OleDbType> column in columnsWithTypes)
            {
                dataAdapter.InsertCommand.Parameters.Add(new OleDbParameter(column.Key, column.Value));
                dataAdapter.InsertCommand.Parameters[index].Direction = ParameterDirection.Input;
                dataAdapter.InsertCommand.Parameters[index].SourceColumn = column.Key;
                index++;
            }
        }
    }
}
