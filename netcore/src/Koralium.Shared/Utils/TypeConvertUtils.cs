using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.Shared.Utils
{
    internal static class TypeConvertUtils
    {
        public static Expression ChangeTypeWithNullableExpression(object value, Type toType)
        {
            Type nullableType = Nullable.GetUnderlyingType(toType);

            if (nullableType != null)
            {
                object safeValue = (value == null) ? null : Convert.ChangeType(value, nullableType);
                return Expression.Convert(Expression.Constant(safeValue), toType);
            }
            else
            {
                //Enum conversion
                if (toType.IsEnum)
                {
                    try
                    {
                        var enumValue = EnumUtils.ConvertToEnum(value, toType);
                        return Expression.Constant(enumValue);
                    }
                    catch
                    {
                        throw new SqlErrorException($"'{value}' is not a valid value of the enum '{toType.Name}'");
                    }
                }
                return Expression.Constant(Convert.ChangeType(value, toType));
            }
        }

        private static object ChangeTypeWithNullable(object value, Type toType)
        {
            Type nullableType = Nullable.GetUnderlyingType(toType);

            if (nullableType != null)
            {
                object safeValue = (value == null) ? null : Convert.ChangeType(value, nullableType);
                return safeValue;
            }
            else
            {
                //Enum conversion
                if (toType.IsEnum)
                {
                    try
                    {
                        var enumValue = EnumUtils.ConvertToEnum(value, toType);
                        return enumValue;
                    }
                    catch
                    {
                        throw new SqlErrorException($"'{value}' is not a valid value of the enum '{toType.Name}'");
                    }
                }
                try
                {
                    return Convert.ChangeType(value, toType);
                }
                catch (Exception e) when (e is FormatException || e is InvalidCastException)
                {
                    throw new SqlErrorException($"Could not convert value: '{value}' to type: '{toType.Name}'");
                }
            }
        }

        public static bool TryConvertToType(object value, Type type, out object convertedValue)
        {
            try
            {
                convertedValue = ChangeTypeWithNullable(value, type);
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
            return ChangeTypeWithNullable(value, type);
        }
    }
}
