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

        public static ColumnType GetKoraliumType(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return GetKoraliumType(Nullable.GetUnderlyingType(type));
            }
            if (type.Equals(typeof(int)))
            {
                return ColumnType.Int32;
            }
            if (type.Equals(typeof(long)))
            {
                return ColumnType.Int64;
            }
            if (type.Equals(typeof(string)))
            {
                return ColumnType.String;
            }
            if (type.Equals(typeof(bool)))
            {
                return ColumnType.Bool;
            }
            if (type.Equals(typeof(float)))
            {
                return ColumnType.Float;
            }
            if (type.Equals(typeof(double)))
            {
                return ColumnType.Double;
            }
            if (type.Equals(typeof(DateTime)))
            {
                return ColumnType.Timestamp;
            }
            if (IsArray(type))
            {
                return ColumnType.List;
            }
            if (!IsBaseType(type))
            {
                return ColumnType.Object;
            }

            throw new Exception("Unsupported type");
        }
    }
}
