using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    [Authorize("secure")]
    public class SecureResolver : TableResolver<Order>
    {
        private readonly TpchData _tpchData;
        public SecureResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }
        protected override Task<IQueryable<Order>> GetQueryableData()
        {
            return Task.FromResult(_tpchData.Orders.AsQueryable());
        }
    }
}
