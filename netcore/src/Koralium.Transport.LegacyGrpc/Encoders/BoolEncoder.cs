using Koralium.Grpc;
using Koralium.Transport.LegacyGrpc.Interfaces;
using System.Text;

namespace Koralium.Transport.LegacyGrpc.Encoders
{
    class BoolEncoder : IEncoder
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
