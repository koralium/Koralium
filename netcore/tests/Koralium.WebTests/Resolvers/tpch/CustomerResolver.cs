using Koralium.WebTests.Entities.tpch;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class CustomerResolver : TableResolver<Customer>
    {
        private readonly TpchData _tpchData;
        public CustomerResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        protected override Task<IQueryable<Customer>> GetQueryableData()
        {
            return Task.FromResult(_tpchData.Customers.AsQueryable());
        }
    }
}
