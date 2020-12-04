using Apache.Arrow;
using Apache.Arrow.Types;
using Koralium.Transport.ArrowFlight.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    public class ObjectEncoder : IArrowEncoder
    {
        private readonly IArrowEncoder[] _childEncoders;
        private readonly Func<object, object> _getFunc;
        private readonly bool _nullable;
        private readonly IArrowType _type;
        private int count = 0;
        private int nullCount = 0;
        readonly ArrowBuffer.BitmapBuilder nullBitmap;
        public ObjectEncoder(Column column)
        {
            _getFunc = column.GetFunction;
            _nullable = column.IsNullable;

            _type = TypeConverter.Convert(column);

            _childEncoders = new IArrowEncoder[column.Children.Count];

            for(int i = 0; i < _childEncoders.Length; i++)
            {
                _childEncoders[i] = EncoderHelper.GetEncoder(column.Children[i]);
            }

            nullBitmap = new ArrowBuffer.BitmapBuilder();
        }

        public IArrowArray BuildArray()
        {
            return new StructArray(_type, count, _childEncoders.Select(x => x.BuildArray()), nullBitmap.Build(), nullCount);
        }

        public void NewBatch()
        {
            count = 0;
            nullCount = 0;
            foreach(var encoder in _childEncoders)
            {
                encoder.NewBatch();
            }
            nullBitmap.Clear();
        }

        public void Encode(object row)
        {
            var val = _getFunc(row);
            count++;

            if (_nullable && val == null)
            {
                nullBitmap.Append(true);
                nullCount++;
            }
            else
            {
                nullBitmap.Append(false);

                for(int i = 0; i < _childEncoders.Length; i++)
                {
                    _childEncoders[i].Encode(val);
                }
            }
        }

        public void Encode(IReadOnlyList<object> rows)
        {
            throw new NotImplementedException();
        }

        public long Size()
        {
            return _childEncoders.Select(x => x.Size()).Sum();
        }
    }
}
