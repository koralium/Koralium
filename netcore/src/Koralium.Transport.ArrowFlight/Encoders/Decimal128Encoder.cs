using Apache.Arrow;
using Apache.Arrow.Types;
using Koralium.Transport.ArrowFlight.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    class Decimal128Encoder : IArrowEncoder
    {
        private Decimal128Array.Builder _builder;
        private readonly Func<object, object> _getFunc;
        private readonly bool _nullable;
        private readonly Decimal128Type _type;
        public Decimal128Encoder(Column column)
        {
            _getFunc = column.GetFunction;
            _nullable = column.IsNullable;
            _type = TypeConverter.Convert(column) as Decimal128Type;
            Debug.Assert(_type != null);
        }

        public IArrowArray BuildArray()
        {
            return _builder.Build();
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
                _builder.Append((decimal)val);
            }
        }

        public void NewBatch()
        {
            _builder = new Decimal128Array.Builder(_type);
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
                    _builder.Append(0);
                }
            }
        }

        public long Size()
        {
            return _builder.Length * 16;
        }
    }
}
