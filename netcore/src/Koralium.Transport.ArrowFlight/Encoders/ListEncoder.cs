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
    class ListEncoder : IArrowEncoder
    {
        readonly ArrowBuffer.Builder<int> offsetBuilder;
        private readonly IArrowEncoder _childEncoder;
        private readonly Func<object, object> _getFunc;
        private readonly bool _nullable;
        private readonly IArrowType _valueType;
        private int currentOffset = 0;
        private int count = 0;
        private int nullCount = 0;
        readonly ArrowBuffer.BitmapBuilder nullBitmap;
        public ListEncoder(Column column)
        {
            Debug.Assert(column.Children.Count == 1);
            _getFunc = column.GetFunction;
            _nullable = column.IsNullable;
            var child = column.Children.First();
            offsetBuilder = new ArrowBuffer.Builder<int>();

            var listChildColumn = new Column(child.Name, child.Type, x => x, child.Children, child.ColumnType, child.IsNullable);

            _childEncoder = EncoderHelper.GetEncoder(listChildColumn);
            _valueType = TypeConverter.Convert(column);
            nullBitmap = new ArrowBuffer.BitmapBuilder();
        }

        public IArrowArray BuildArray()
        {
            offsetBuilder.Append(currentOffset);
            return new ListArray(_valueType, count, offsetBuilder.Build(), _childEncoder.BuildArray(), nullBitmap.Build(), nullCount);
        }

        public void NewBatch()
        {
            currentOffset = 0;
            count = 0;
            nullCount = 0;
            _childEncoder.NewBatch();
            offsetBuilder.Clear();
            nullBitmap.Clear();
        }

        private void AddNull()
        {
            nullBitmap.Append(false);
            nullCount++;
            offsetBuilder.Append(currentOffset);
        }

        public void Encode(object row)
        {
            var val = _getFunc(row);
            count++;

            if (_nullable && val == null)
            {
                AddNull();
            }
            else
            {
                nullBitmap.Append(true);
                offsetBuilder.Append(currentOffset);

                var enumerable = (IEnumerable)val;
                foreach(var obj in enumerable)
                {
                    _childEncoder.Encode(obj);
                    currentOffset++;
                }
            }
        }

        public void Encode(IReadOnlyList<object> rows)
        {
            throw new NotImplementedException();
        }

        public long Size()
        {
            return _childEncoder.Size();
        }

        public void Pad(int length)
        {
            for (int i = 0; i < length; i++)
            {
                count++;
                AddNull();
            }
        }
    }
}
