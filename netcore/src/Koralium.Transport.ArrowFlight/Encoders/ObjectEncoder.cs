/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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

        private void AddNull()
        {
            nullBitmap.Append(false);
            nullCount++;
            for (int i = 0; i < _childEncoders.Length; i++)
            {
                _childEncoders[i].Pad(1);
            }
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
