using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class PartsuppResolver : TableResolver<Partsupp>
    {
        private readonly TpchData _tpchData;
        public PartsuppResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        public override Task<IQueryable<Partsupp>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(_tpchData.Partsupp.AsQueryable());
        }
    }
}
