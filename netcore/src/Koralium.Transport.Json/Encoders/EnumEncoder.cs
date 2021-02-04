using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    class EnumEncoder : PrimitiveEncoder
    {
        private readonly Type _type;
        public EnumEncoder(Column column) : base(column)
        {
            _type = column.Type;
        }

        private protected override void WriteValue(in Utf8JsonWriter writer, in object val)
        {
            writer.WriteStringValue(Enum.GetName(_type, val));  
        }
    }
}
