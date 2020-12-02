using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    class Int64Encoder : PrimitiveEncoder
    {
        public Int64Encoder(Column column) : base(column)
        {
        }

        private protected override void WriteValue(in Utf8JsonWriter writer, in object val)
        {
            writer.WriteNumber(_name, (long)val);
        }
    }
}
