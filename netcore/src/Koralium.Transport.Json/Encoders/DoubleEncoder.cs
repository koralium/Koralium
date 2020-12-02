using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    class DoubleEncoder : PrimitiveEncoder
    {
        public DoubleEncoder(Column column) : base(column)
        {
        }

        private protected override void WriteValue(in Utf8JsonWriter writer, in object val)
        {
            writer.WriteNumber(_name, (double)val);
        }
    }
}
