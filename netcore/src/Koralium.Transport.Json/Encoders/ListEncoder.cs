using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    public class ListEncoder : IJsonEncoder
    {
        private readonly JsonEncodedText _name;
        private readonly Func<object, object> _getFunc;
        private readonly IJsonEncoder _childEncoder;

        public ListEncoder(Column column)
        {
            _name = JsonEncodedText.Encode(column.Name);
            _getFunc = column.GetFunction;

            Debug.Assert(column.Children.Count == 1);
            _childEncoder = EncoderHelper.GetEncoder(column.Children.First());
        }

        JsonEncodedText IJsonEncoder.PropertyName => _name;

        Func<object, object> IJsonEncoder.GetValueFunc => _getFunc;

        public void Encode(in Utf8JsonWriter utf8JsonWriter, in object row)
        {
            var val = _getFunc(row);

            if(val == null)
            {
                utf8JsonWriter.WriteNull(_name);
            }
            else
            {
                var enumerable = val as IEnumerable;

                utf8JsonWriter.WriteStartArray();

                foreach(var o in enumerable)
                {
                    _childEncoder.Encode(in utf8JsonWriter, o);
                }

                utf8JsonWriter.WriteEndArray();
            }
        }
    }
}
