using Koralium.Grpc;
using Koralium.Transport.LegacyGrpc.Interfaces;

namespace Koralium.Transport.LegacyGrpc.Encoders
{
    class DoubleEncoder : IEncoder
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
