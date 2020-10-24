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
using Koralium.Grpc;
using System;

namespace Koralium.Encoders
{
    public class TimestampEncoder : IEncoder
    {
        public Block CreateBlock(Page page)
        {
            return new Block()
            {
                Timestamps = new TimestampBlock()
            };
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            if (value == null)
            {
                block.Timestamps.Values.Add(default(Timestamp));
            }
            if (value is DateTime dateTime)
            {
                if (dateTime.Kind != DateTimeKind.Utc)
                {
                    dateTime = dateTime.ToUniversalTime();
                }
                var timestamp = Timestamp.FromDateTime(dateTime);
                block.Timestamps.Values.Add(timestamp);

                return 8;
            }
            else if (value is DateTimeOffset dateTimeOffset)
            {
                var timestamp = Timestamp.FromDateTimeOffset(dateTimeOffset);
                block.Timestamps.Values.Add(timestamp);

                return 8;
            }


            throw new NotImplementedException();
        }

        public void Finish()
        {
            //No operation needed
        }
    }
}
