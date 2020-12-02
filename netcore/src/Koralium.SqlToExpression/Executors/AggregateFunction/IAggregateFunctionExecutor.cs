using Koralium.SqlToExpression.Executors.Select;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors.AggregateFunction
{
    public interface IAggregateFunctionExecutor
    {
        ValueTask<SelectResult> Execute(IQueryable queryable, ExecuteAggregateFunctionStage executeAggregateFunctionStage);
    }
}
