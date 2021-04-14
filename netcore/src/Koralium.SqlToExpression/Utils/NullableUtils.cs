using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Utils
{
    internal static class NullableUtils
    {
        public static bool IsNullable(Type type)
        {
            if (type.IsPrimitive)
            {
                return false;
            }
            if (type.IsClass)
            {
                return true;
            }
            var innerNullableType = Nullable.GetUnderlyingType(type);
            return (!type.IsValueType || innerNullableType != null);
        }

        /// <summary>
        /// Returns a type that makes the sent in type nullable.
        /// A class is returned as it is, while primitives, structs are returned as Nullable<T>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNullable(Type type)
        {
            if (IsNullable(type))
            {
                return type;
            }
            return typeof(Nullable<>).MakeGenericType(type);
        }
    }
}
