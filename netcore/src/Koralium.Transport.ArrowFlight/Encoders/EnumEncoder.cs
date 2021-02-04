using Apache.Arrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    class EnumEncoder : IArrowEncoder
    {
        private readonly Type _enumType;
        private StringArray.Builder _builder;
        private readonly Func<object, object> _getFunc;
        private readonly bool _nullable;

        private long _size;
        public EnumEncoder(Column column)
        {
            _getFunc = column.GetFunction;
            _nullable = column.IsNullable;
            _enumType = column.Type;
        }

        public IArrowArray BuildArray()
        {
            return _builder.Build();
        }

        public void NewBatch()
        {
            _size = 0;
            _builder = new StringArray.Builder();
        }

        public void Encode(object row)
        {
            var val = _getFunc(row);

            if (_nullable && val == null)
            {
                _builder.AppendNull();
            }
            else
            {
                var stringVal = Enum.GetName(_enumType, val);
                _size += stringVal.Length;
                _builder.Append(stringVal);
            }
        }

        public long Size()
        {
            return _size;
        }

        public void Pad(int length)
        {
            if (_nullable)
            {
                for (int i = 0; i < length; i++)
                {
                    _builder.AppendNull();
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    _builder.Append(string.Empty);
                }
            }
        }
    }
}
