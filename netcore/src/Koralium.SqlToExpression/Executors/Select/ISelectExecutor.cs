using Koralium.SqlToExpression.Executors.Select;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public interface ISelectExecutor
    {
        ValueTask<SelectResult> Execute(IQueryable queryable, ExecuteSelectStage selectStage);
    }
}
