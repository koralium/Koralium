using Koralium.Core.Interfaces;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Encoders
{
    public class BoolEncoder : IEncoder
    {
        public Block CreateBlock(Page page)
        {
            return new Block()
            {
                Bools = new BoolBlock()
            };
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            block.Bools.Values.Add((bool)value);
            return 1;
        }

        public void Finish()
        {
            //No operation needed
        }
    }
}
