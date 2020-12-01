using Koralium.Grpc;
using Koralium.Transport.LegacyGrpc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.LegacyGrpc.Encoders
{
    class Int64Encoder : IEncoder
    {
        public Block CreateBlock(Page page)
        {
            return new Block()
            {
                Longs = new Int64Block()
            };
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            block.Longs.Values.Add((long)value);
            return 8;
        }

        public void Finish()
        {
            //No operation needed
        }
    }
}
