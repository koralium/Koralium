using Koralium.Core.Interfaces;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Encoders
{
    public class DoubleEncoder : IEncoder
    {
        public Block CreateBlock(Page page)
        {
            return new Block()
            {
                Doubles = new DoubleBlock()
            };
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            block.Doubles.Values.Add((double)value);
            return 8;
        }

        public void Finish()
        {
            //No operation needed
        }
    }
}
