using System;
using System.Data;
using System.Linq;

namespace Api.Core.Extensions
{
    public static class DataReaderExtensions
    {
        public static bool IsDBNull(this IDataReader dataReader, string column)
        {
            return DBNull.Value.Equals(dataReader[column]);
        }

        public static object GetValuesAsSpecificType(this IDataReader dataReader, string column, Type valueType)
        {
            if(DBNull.Value.Equals(dataReader[column]))
            {
                throw new ArgumentNullException($"La propiedad {column} no existe.");
            }

            if(valueType.IsEnum)
            {
                return Enum.ToObject(valueType, dataReader[column]);
            }
            else
            {
                return Convert.ChangeType(dataReader[column], Nullable.GetUnderlyingType(valueType) ?? valueType);
            }
        }

        public static bool Contains(this IDataReader dataReader, string column)
        {
            return dataReader.GetSchemaTable().Rows.OfType<DataRow>().Any(row =>
            {
                return row["ColumnName"].ToString() == column;
            });
        }
    }
}
