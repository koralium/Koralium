using Grpc.Core;
using Koralium.Core.Metadata;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium.Core.Interfaces
{
    public interface IIndexResolver
    {
        Task GetData(IndexRequest dataRequest, KoraliumTable table, TableIndex index, ServerCallContext context, ChannelWriter<Page> channelWriter);
    }
}
