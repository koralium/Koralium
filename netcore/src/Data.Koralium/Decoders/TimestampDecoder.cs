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
    internal class TimestampDecoder : ColumnDecoder
    {
        private TimestampArray _array;

        public override string GetDataTypeName()
        {
            return "timestamp";
        }

        public override Type GetFieldType()
        {
            return typeof(DateTime);
        }

        private DateTimeOffset GetDateTimeOffset(in int index)
        {
            return _array.GetTimestampUnchecked(index);
        }

        public override DateTime GetDateTime(in int index)
        {
            return GetDateTimeOffset(index).DateTime;
        }

        public override object GetValue(in int index)
        {
            return GetDateTimeOffset(index);
        }

        public override long GetInt64(in int index)
        {
            return _array.Values[index];
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            if (arrowArray is TimestampArray timestampArray)
            {
                _array = timestampArray;
            }
            else
            {
                throw new ArgumentException("Expected timestamp array", nameof(arrowArray));
            }
        }

        public override bool IsDbNull(in int index)
        {
            return _array.IsNull(index);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if(Equals(type, typeof(DateTimeOffset)))
            {
                return GetDateTimeOffset(index);
            }

            return Convert.ChangeType(GetDateTimeOffset(index), type);
        }
    }
}
