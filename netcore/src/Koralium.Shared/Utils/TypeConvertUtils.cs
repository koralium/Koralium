using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Shared.Utils
{
    internal static class TypeConvertUtils
    {
        public static bool TryConvertToType(object value, Type type, out object convertedValue)
        {
            try
            {
                convertedValue = ConvertToType(value, type);
                return true;
            }
            catch (SqlErrorException)
            {
                convertedValue = default;
                return false;
            }
        }

        public static object ConvertToType(object value, Type type)
        {
           
            if (type.IsEnum)
            {
                try
                {
                    return EnumUtils.ConvertToEnum(value, type);
                }
                catch (ArgumentException)
                {
                    throw new SqlErrorException($"Could not find a value in enum '{type.Name}' that matched: '{value}'");
                }
            }
            try
            {
                return Convert.ChangeType(value, type);
            }
            catch (FormatException)
            {
                throw new SqlErrorException($"Could not convert value: '{value}' to type: '{type.Name}");
            }
        }
    }
}
