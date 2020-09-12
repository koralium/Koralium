using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
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

        public override Task<IQueryable<Supplier>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(_tpchData.Supplier.AsQueryable());
        }
    }
}
