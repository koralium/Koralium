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
using Google.Protobuf.WellKnownTypes;
using Koralium.Interfaces;
using Koralium.Metadata;
using Koralium.Grpc;
using System;

namespace Koralium.Decoders
{
    public class TimestampDecoder : BaseDecoder
    {
        public override IDecoder Create(int columnId, TableColumn column)
        {
            return new TimestampDecoder();
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Timestamps.Values;

            Decode(nulls, values, (index, value) =>
            {
                var timestamp = value as Timestamp;
                setter(index, timestamp.ToDateTime());
            }, numberOfRows);
        }
    }
}
