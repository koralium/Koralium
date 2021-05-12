using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.Shared.Utils
{
    public static class ArrayUtils
    {
        public static bool IsArray(Type type)
        {
            if (type.IsArray)
                return true;

            return typeof(IEnumerable).IsAssignableFrom(type);
        }

        
        public static Type GetArrayElementType(Type type)
        {
            //From: https://stackoverflow.com/questions/906499/getting-type-t-from-ienumerablet

            // Type is Array
            // short-circuit if you expect lots of arrays 
            if (type.IsArray)
                return type.GetElementType();

            // type is IEnumerable<T>;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return type.GetGenericArguments()[0];

            // type implements/extends IEnumerable<T>;
            var enumType = type.GetInterfaces()
                                    .Where(t => t.IsGenericType &&
                                           t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                                    .Select(t => t.GenericTypeArguments[0]).FirstOrDefault();

            return enumType ?? type;
        }
    }
}
