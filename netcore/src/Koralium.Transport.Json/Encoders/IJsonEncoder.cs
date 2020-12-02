using System;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    public interface IJsonEncoder
    {
        internal JsonEncodedText PropertyName { get; }
        internal Func<object, object> GetValueFunc { get; }
        void Encode(in Utf8JsonWriter utf8JsonWriter, in object row);
    }
}
