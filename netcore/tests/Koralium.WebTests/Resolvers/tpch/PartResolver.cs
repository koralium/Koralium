using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class PartResolver : TableResolver<Part>
    {
        private readonly TpchData _tpchData;
        public PartResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        public override Task<IQueryable<Part>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(_tpchData.Part.AsQueryable());
        }
    }
}
