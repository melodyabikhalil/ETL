using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    class MySQLHelper
    {
        public static MySqlDbType MapCsharpTypeToMySQLType(Type dataType)
        {
            //by default hatayta bigint
            MySqlDbType mysqlDbType = MySqlDbType.Int32;

            if (dataType == Type.GetType("System.Int32"))
            {
                mysqlDbType = MySqlDbType.Int32;
            }
            else if (dataType == Type.GetType("System.String"))
            {
                mysqlDbType = MySqlDbType.Text;
            }
            else if (dataType == Type.GetType("System.Boolean"))
            {
                mysqlDbType = MySqlDbType.Bit;
            }
            else if (dataType == Type.GetType("System.TimeSpan"))
            {
                mysqlDbType = MySqlDbType.Time;
            }
            else if (dataType == Type.GetType("System.Int16"))
            {
                mysqlDbType = MySqlDbType.Int16;
            }
            else if (dataType == Type.GetType("System.Double"))
            {
                mysqlDbType = MySqlDbType.Double;
            }
            else if (dataType == Type.GetType("System.Char"))
            {
                mysqlDbType = MySqlDbType.VarChar;
            }
            else if (dataType == Type.GetType("System.DateTime"))
            {
                mysqlDbType = MySqlDbType.Timestamp;
            }
            return mysqlDbType;
        }
        public static Dictionary<string, MySqlDbType> GetsColumnsWithTypes(DataColumnCollection columns)
        {
            Dictionary<string, MySqlDbType> columnsWithTypes = new Dictionary<string, MySqlDbType>();
            foreach (DataColumn col in columns)
            {
                MySqlDbType type = MapCsharpTypeToMySQLType(col.DataType);
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
                sb.Append("@");
                sb.Append(field);
                sb.Append(",");
            }
            sb.Length--;
            sb.Append(")");
            return sb.ToString();

        }
        public static void SetParametersForInsertQuery(Dictionary<string, MySqlDbType> columnsWithTypes, MySqlDataAdapter dataAdapter)
        {
            int index = 0;
            foreach (KeyValuePair<string, MySqlDbType> column in columnsWithTypes)
            {
                dataAdapter.InsertCommand.Parameters.Add(new MySqlParameter(column.Key, column.Value));
                dataAdapter.InsertCommand.Parameters[index].Direction = ParameterDirection.Input;
                dataAdapter.InsertCommand.Parameters[index].SourceColumn = column.Key;
                index++;
            }
        }
    }
}
