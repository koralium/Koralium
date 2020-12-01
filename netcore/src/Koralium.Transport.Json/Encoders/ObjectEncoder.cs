using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    public class ObjectEncoder : IJsonEncoder
    {
        private readonly JsonEncodedText _name;
        private readonly Func<object, object> _getFunc;
        private readonly IJsonEncoder[] _childEncoders;
        public ObjectEncoder(Column column)
        {
            _name = JsonEncodedText.Encode(column.Name);
            _getFunc = column.GetFunction;

            _childEncoders = new IJsonEncoder[column.Children.Count];

            for(int i = 0; i < column.Children.Count; i++)
            {
                _childEncoders[i] = EncoderHelper.GetEncoder(column.Children[i]);
            }
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
                utf8JsonWriter.WriteStartObject(_name);

                for(int i = 0; i < _childEncoders.Length; i++)
                {
                    _childEncoders[i].Encode(in utf8JsonWriter, val);
                }

                utf8JsonWriter.WriteEndObject();
            }
        }
    }
}
