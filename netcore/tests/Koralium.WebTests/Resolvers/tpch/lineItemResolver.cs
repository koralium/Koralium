using Koralium.WebTests.Entities.tpch;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    public class LineItemResolver : TableResolver<LineItem>
    {
        private readonly TpchData _tpchData;
        public LineItemResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        protected override Task<IQueryable<LineItem>> GetQueryableData()
        {
            return Task.FromResult(_tpchData.LineItem.AsQueryable());
        }
    }
}
