using Koralium.WebTests.Entities.tpch;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class SupplierResolver : TableResolver<Supplier>
    {
        private readonly TpchData _tpchData;
        public SupplierResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        protected override Task<IQueryable<Supplier>> GetQueryableData()
        {
            return Task.FromResult(_tpchData.Supplier.AsQueryable());
        }
    }
}
