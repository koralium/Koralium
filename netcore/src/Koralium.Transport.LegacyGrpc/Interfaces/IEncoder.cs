using Koralium.Grpc;

namespace Koralium.Transport.LegacyGrpc.Interfaces
{
    public interface IEncoder
    {
        Block CreateBlock(Page page);

        uint Encode(in object value, in Block block, in int rowNumber);

        void Finish();
    }
}
