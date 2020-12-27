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
using System;

namespace Data.Koralium.Decoders
{
    internal class BoolDecoder : ColumnDecoder
    {
        private BooleanArray _array;
        public override bool GetBoolean(in int index)
        {
            return _array.GetBoolean(index);
        }

        public override string GetDataTypeName()
        {
            return "bool";
        }

        public override Type GetFieldType()
        {
            return typeof(bool);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if (Equals(type, typeof(bool)))
            {
                return GetValue(index);
            }
            return Convert.ChangeType(GetValue(index), type);
        }

        public override object GetValue(in int index)
        {
            return GetBoolean(index);
        }

        public override long GetInt64(in int index)
        {
            return GetBoolean(index) ? 1 : 0;
        }

        public override bool IsDbNull(in int index)
        {
            return _array.IsNull(index);
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            if (arrowArray is BooleanArray booleanArray)
            {
                _array = booleanArray;
            }
            else
            {
                throw new ArgumentException("Expected boolean array", nameof(arrowArray));
            }
        }
    }
}
