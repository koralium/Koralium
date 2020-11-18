using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.LegacyGrpc.Interfaces
{
    public interface IEncoder
    {
        Block CreateBlock(Page page);

        uint Encode(in object value, in Block block, in int rowNumber);

        void Finish();
    }
}
