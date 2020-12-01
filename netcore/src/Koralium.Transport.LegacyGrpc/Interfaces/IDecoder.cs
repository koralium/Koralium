using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.LegacyGrpc.Interfaces
{
    public interface IDecoder
    {
        Decoder Create(int columnId, Column column);

        void NewPage(Page page);

        void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue);
    }
}
