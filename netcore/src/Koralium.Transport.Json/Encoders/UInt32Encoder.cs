using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    class UInt32Encoder : PrimitiveEncoder
    {
        public UInt32Encoder(Column column) : base(column)
        {
        }

        private protected override void WriteValue(in Utf8JsonWriter writer, in object val)
        {
            writer.WriteNumber(_name, (uint)val);
        }
    }
}
