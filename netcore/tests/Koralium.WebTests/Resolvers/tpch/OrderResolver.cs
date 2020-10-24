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
            //This just exists to be able to see that extra data is being sent correctly
            if (ExtraData.TryGetValue("test", out var extraDataValue))
            {
                AddCustomMetadata("test", "extrametadata");
                return Task.FromResult(_tpchData.Orders.AsQueryable().Where(x => x.Custkey == 1));
            }
            AddCustomMetadata("test", "hello");
            return Task.FromResult(_tpchData.Orders.AsQueryable());
        }
    }
}
