using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Grpc.Interfaces
{
    public interface IEncoder
    {
        //IEncoder Create(int columnId);

        Block CreateBlock(Page page);

        uint Encode(in object value, in Block block, in int rowNumber);

        void Finish();
    }
}
