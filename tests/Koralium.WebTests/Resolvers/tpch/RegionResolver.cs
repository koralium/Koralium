using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class RegionResolver : TableResolver<Region>
    {
        private readonly TpchData _tpchData;
        public RegionResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        public override Task<IQueryable<Region>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(_tpchData.Region.AsQueryable());
        }
    }
}
