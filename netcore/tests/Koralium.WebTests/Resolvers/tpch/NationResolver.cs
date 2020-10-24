using Koralium.WebTests.Entities.tpch;
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

        protected override Task<IQueryable<Nation>> GetQueryableData()
        {
            return Task.FromResult(_tpchData.Nation.AsQueryable());
        }
    }
}
