using Google.Protobuf.WellKnownTypes;
using Koralium.Core.Interfaces;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Encoders
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
