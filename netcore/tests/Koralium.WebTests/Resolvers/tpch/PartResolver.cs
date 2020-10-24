using Koralium.WebTests.Entities.tpch;
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

        protected override Task<IQueryable<Part>> GetQueryableData()
        {
            return Task.FromResult(_tpchData.Part.AsQueryable());
        }
    }
}
