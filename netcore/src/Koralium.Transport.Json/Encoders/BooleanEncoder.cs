using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    class BooleanEncoder : PrimitiveEncoder
    {
        public BooleanEncoder(Column column) : base(column)
        {
        }

        private protected override void WriteValue(in Utf8JsonWriter writer, in object val)
        {
            writer.WriteBoolean(_name, (bool)val);
        }
    }
}
