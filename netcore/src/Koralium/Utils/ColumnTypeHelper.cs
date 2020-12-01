using Koralium.Transport;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Utils
{
    static class ColumnTypeHelper
    {

        internal static bool IsArray(Type type)
        {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>));
        }

        internal static bool IsBaseType(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return IsBaseType(Nullable.GetUnderlyingType(type));
            }
            if (type.IsPrimitive ||
                type.Equals(typeof(string)) ||
                type.Equals(typeof(DateTime)))
                return true;
            return false;
        }

        public static (ColumnType columnType, bool nullable) GetKoraliumType(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return (GetKoraliumType(Nullable.GetUnderlyingType(type)).columnType, true);
            }
            if (type.Equals(typeof(int)))
            {
                return (ColumnType.Int32, false);
            }
            if (type.Equals(typeof(long)))
            {
                return (ColumnType.Int64, false);
            }
            if (type.Equals(typeof(string)))
            {
                return (ColumnType.String, false);
            }
            if (type.Equals(typeof(bool)))
            {
                return (ColumnType.Bool, false);
            }
            if (type.Equals(typeof(float)))
            {
                return (ColumnType.Float, false);
            }
            if (type.Equals(typeof(double)))
            {
                return (ColumnType.Double, false);
            }
            if (type.Equals(typeof(DateTime)))
            {
                return (ColumnType.DateTime, false);
            }
            if (IsArray(type))
            {
                return (ColumnType.List, true);
            }
            if (!IsBaseType(type))
            {
                return (ColumnType.Object, true);
            }

            throw new Exception("Unsupported type");
        }
    }
}
