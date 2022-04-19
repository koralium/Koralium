using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Shared.Utils
{
    internal static class EnumUtils
    {
        public static object ConvertToEnum(object val, Type enumType)
        {
            if (val is string stringValue)
            {
                return Enum.Parse(enumType, stringValue, true);
            }
            else
            {
                return Enum.ToObject(enumType, val);
            }
        }
    }
}
