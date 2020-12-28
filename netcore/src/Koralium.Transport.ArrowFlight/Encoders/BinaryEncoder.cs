using Apache.Arrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    internal class BinaryEncoder : IArrowEncoder
    {
        private BinaryArray.Builder _builder;
        private readonly Func<object, object> _getFunc;
        private readonly bool _nullable;

        private int size = 0;

        public BinaryEncoder(Column column)
        {
            _getFunc = column.GetFunction;
            _nullable = column.IsNullable;
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
                var byteArray = (byte[])val;
                size += byteArray.Length;
                _builder.Append(byteArray.AsSpan());
            }
        }

        public void NewBatch()
        {
            _builder = new BinaryArray.Builder();
            size = 0;
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
            return size;
        }
    }
}
