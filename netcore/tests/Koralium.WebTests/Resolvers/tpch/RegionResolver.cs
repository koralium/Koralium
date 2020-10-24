using Koralium.WebTests.Entities.tpch;
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

        protected override Task<IQueryable<Region>> GetQueryableData()
        {
            return Task.FromResult(_tpchData.Region.AsQueryable());
        }
    }
}
