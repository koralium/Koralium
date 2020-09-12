using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Interfaces
{
    public interface IEncoder
    {
        Block CreateBlock(Page page);

        uint Encode(in object value, in Block block, in int rowNumber);

        void Finish();
    }
}
