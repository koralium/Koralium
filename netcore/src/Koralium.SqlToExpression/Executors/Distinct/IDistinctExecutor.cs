using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public interface IDistinctExecutor
    {
        ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteDistinctStage executeDistinctStage);
    }
}
