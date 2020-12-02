using System;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    class DateTimeEncoder : PrimitiveEncoder
    {
        public DateTimeEncoder(Column column) : base(column)
        {
        }

        private protected override void WriteValue(in Utf8JsonWriter writer, in object val)
        {
            writer.WriteString(_name, (DateTime)val);
        }
    }
}
