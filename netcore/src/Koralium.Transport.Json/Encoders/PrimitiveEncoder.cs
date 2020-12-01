using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    abstract class PrimitiveEncoder : IJsonEncoder
    {
        private protected readonly JsonEncodedText _name;
        private readonly Func<object, object> _getFunc;

        protected PrimitiveEncoder(Column column)
        {
            _name = JsonEncodedText.Encode(column.Name);
            _getFunc = column.GetFunction;
        }

        JsonEncodedText IJsonEncoder.PropertyName => _name;

        Func<object, object> IJsonEncoder.GetValueFunc => _getFunc;

        public void Encode(in Utf8JsonWriter utf8JsonWriter, in object row)
        {
            var val = _getFunc(row);

            if (val == null)
            {
                utf8JsonWriter.WriteNull(_name);
            }
            else
            {
                WriteValue(in utf8JsonWriter, in val);
            }
        }

        private protected abstract void WriteValue(in Utf8JsonWriter writer, in object val);
    }
}
