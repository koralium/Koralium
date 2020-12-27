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
using System;

namespace Data.Koralium.Decoders
{
    internal class Int64Decoder : PrimitiveDecoder<long>
    {
        public override int GetInt32(in int index)
        {
            var value = Array.Values[index];

            //Check bounds
            if (value > int.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a int32 from a int64 value and the value is larger than int32 MaxValue");
            }
            if (value < int.MinValue)
            {
                throw new InvalidOperationException("Trying to get a int32 from a int64 value and the value is smaller than int32 MinValue");
            }

            return (int)value;
        }

        public override short GetInt16(in int index)
        {
            var value = Array.Values[index];

            //Check bounds
            if (value > short.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a int32 value and the value is larger than int16 MaxValue");
            }
            if (value < short.MinValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a int32 value and the value is smaller than int16 MinValue");
            }

            return (short)value;
        }

        public override long GetInt64(in int index)
        {
            return Array.Values[index];
        }

        public override byte GetByte(in int index)
        {
            var value = Array.Values[index];

            //Check bounds
            if (value > byte.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a int32 value and the value is larger than byte MaxValue");
            }
            if (value < byte.MinValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a int32 value and the value is smaller than byte MinValue");
            }

            return (byte)value;
        }

        public override float GetFloat(in int index)
        {
            return Array.Values[index];
        }

        public override double GetDouble(in int index)
        {
            return Array.Values[index];
        }

        public override decimal GetDecimal(in int index)
        {
            return Array.Values[index];
        }
    }
}
