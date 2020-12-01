using Koralium.Grpc;
using Koralium.Transport.LegacyGrpc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.LegacyGrpc.Encoders
{
    class FloatEncoder : IEncoder
    {
        public Block CreateBlock(Page page)
        {
            return new Block()
            {
                Floats = new FloatBlock()
            };
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            block.Floats.Values.Add((float)value);
            return 4;
        }

        public void Finish()
        {
            //No operation needed
        }
    }
}
