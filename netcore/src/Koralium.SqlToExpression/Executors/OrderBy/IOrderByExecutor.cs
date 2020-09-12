using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public interface IOrderByExecutor
    {
        ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteOrderByStage executeOrderByStage);
    }
}
