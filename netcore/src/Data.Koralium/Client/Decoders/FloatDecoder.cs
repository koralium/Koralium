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
using Koralium.Grpc;
using System;

namespace Data.Koralium.Client.Decoders
{
    public class FloatDecoder : ColumnDecoder
    {
        public FloatDecoder(int ordinal) : base(ordinal)
        {
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Floats.Values;

            Decode(nulls, values, setter, numberOfRows);
        }

        public override string GetDataTypeName()
        {
            return "float";
        }

        public override Type GetFieldType()
        {
            return typeof(float);
        }

        public override void ReadBlock(Block block, KoraliumRow[] rows)
        {
            Decode(block, (index, val) =>
            {
                rows[index].SetData(ordinal, val);
            });
        }

        public override double GetDouble(KoraliumRow row)
        {
            return (double)Convert.ChangeType(GetFloat(row), typeof(double));
        }

        public override float GetFloat(KoraliumRow row)
        {
            return (float)row.GetData(ordinal);
        }

        public override decimal GetDecimal(KoraliumRow row)
        {
            return (decimal)Convert.ChangeType(GetFloat(row), typeof(decimal));
        }
    }
}
