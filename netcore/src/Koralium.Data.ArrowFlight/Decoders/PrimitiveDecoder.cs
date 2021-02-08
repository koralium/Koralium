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

namespace Koralium.Data.ArrowFlight.Decoders
{
    internal class PrimitiveDecoder<T> : ColumnDecoder
        where T : struct
    {
        private protected PrimitiveArray<T> Array { get; private set; }

        public override string GetDataTypeName()
        {
            return typeof(T).Name;
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            if(arrowArray is PrimitiveArray<T> primitiveArray)
            {
                Array = primitiveArray;
            }
            else
            {
                throw new ArgumentException("Expected primitive array", nameof(arrowArray));
            }
        }

        public override bool IsDbNull(in int index)
        {
            return Array.IsNull(index);
        }

        public override Type GetFieldType()
        {
            return typeof(T);
        }

        public override object GetValue(in int index)
        {
            return Array.Values[index];
        }

        public override TType GetFieldValue<TType>(in int index)
        {
            var value = Array.Values[index];

            if (value is TType toTypeValue)
            {
                return toTypeValue;
            }

            return (TType)Convert.ChangeType(Array.Values[index], typeof(T));
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if(Equals(type, typeof(T)))
            {
                return GetValue(index);
            }
            var nullableInnerType = Nullable.GetUnderlyingType(type);

            if(nullableInnerType == null)
            {
                return Convert.ChangeType(GetValue(index), type);
            }

            if(Equals(nullableInnerType, typeof(T)))
            {
                return GetValue(index);
            }
            else
            {
                return Convert.ChangeType(GetValue(index), nullableInnerType);
            }
        }
    }
}
