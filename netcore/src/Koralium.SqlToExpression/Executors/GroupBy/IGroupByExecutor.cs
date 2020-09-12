using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public interface IGroupByExecutor
    {
        ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteGroupByStage groupByStage);
    }
}
