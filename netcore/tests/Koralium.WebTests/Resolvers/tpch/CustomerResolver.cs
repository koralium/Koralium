using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
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

        public override Task<IQueryable<Customer>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(_tpchData.Customers.AsQueryable());
        }
    }
}
