using Koralium.Core.Interfaces;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Encoders
{
    public class FloatEncoder : IEncoder
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
