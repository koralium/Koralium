using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    class FloatEncoder : PrimitiveEncoder
    {
        public FloatEncoder(Column column) : base(column)
        {
        }

        private protected override void WriteValue(in Utf8JsonWriter writer, in object val)
        {
            writer.WriteNumber(_name, (float)val);
        }
    }
}
