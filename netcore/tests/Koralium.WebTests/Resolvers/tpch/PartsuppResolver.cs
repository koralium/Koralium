using Koralium.WebTests.Entities.tpch;
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

        protected override Task<IQueryable<Partsupp>> GetQueryableData()
        {
            return Task.FromResult(_tpchData.Partsupp.AsQueryable());
        }
    }
}
