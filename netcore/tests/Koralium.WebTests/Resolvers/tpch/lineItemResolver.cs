using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class LineItemResolver : TableResolver<LineItem>
    {
        private readonly TpchData _tpchData;
        public LineItemResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        public override Task<IQueryable<LineItem>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(_tpchData.LineItem.AsQueryable());
        }
    }
}
