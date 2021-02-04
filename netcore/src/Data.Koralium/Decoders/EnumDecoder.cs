using Apache.Arrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Decoders
{
    class EnumDecoder : StringDecoder
    {
        public override string GetDataTypeName()
        {
            return "enum";
        }

        public override Type GetFieldType()
        {
            return typeof(string);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if (type.IsEnum && Enum.TryParse(type, GetString(index), out var enumValue))
            {
                return enumValue;
            }
            return base.GetFieldValue(index, type);
        }
    }
}
