using Koralium.Core.Interfaces;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Encoders
{
    public class Int32Encoder : IEncoder
    {
        public Block CreateBlock(Page page)
        {
            return new Block()
            {
                Ints = new Int32Block()
            };
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            block.Ints.Values.Add((int)value);
            return 4;
        }

        public void Finish()
        {
            //No operation needed
        }
    }
}
