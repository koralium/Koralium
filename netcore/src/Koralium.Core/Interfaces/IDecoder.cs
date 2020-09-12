using Koralium.Core.Metadata;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Interfaces
{
    public interface IDecoder
    {
        IDecoder Create(int columnId, TableColumn column);

        void NewPage(Page page);

        void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue);
    }
}
