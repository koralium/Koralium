using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class OrderResolver : TableResolver<Order>
    {
        private readonly TpchData _tpchData;
        public OrderResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        public override Task<IQueryable<Order>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(_tpchData.Orders.AsQueryable());
        }
    }
}
