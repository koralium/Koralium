using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class NationResolver : TableResolver<Nation>
    {
        private readonly TpchData _tpchData;
        public NationResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        public override Task<IQueryable<Nation>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(_tpchData.Nation.AsQueryable());
        }
    }
}
