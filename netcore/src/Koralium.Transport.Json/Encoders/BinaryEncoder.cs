using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    internal class BinaryEncoder : PrimitiveEncoder
    {
        public BinaryEncoder(Column column) : base(column)
        {
        }

        private protected override void WriteValue(in Utf8JsonWriter writer, in object val)
        {
            writer.WriteBase64StringValue((byte[])val);
        }
    }
}
