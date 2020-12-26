using Koralium.WebTests.Entities.tpch;
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

        protected override Task<IQueryable<Order>> GetQueryableData()
        {
            if(QueryOptions.Parameters.TryGetParameter("p1", out var parameter))
            {
                if(parameter.TryGetValue<int>(out var stringValue))
                {
                    return Task.FromResult(_tpchData.Orders.AsQueryable().Where(x => x.Custkey == 1));
                }
            }
            AddCustomMetadata("test", "hello");
            return Task.FromResult(_tpchData.Orders.AsQueryable());
        }
    }
}
