using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public interface IQueryExecutor
    {
        ValueTask<QueryResult> Execute(IImmutableList<IExecuteStage> stages, object data);

        ValueTask<IQueryable> Visit(ExecuteFromTableStage executeFromTableStage);

        ValueTask<IQueryable> Visit(ExecuteGroupByStage executeGroupByStage);

        ValueTask<IQueryable> Visit(ExecuteOrderByStage executeOrderByStage);

        ValueTask<IQueryable> Visit(ExecuteSelectStage executeSelectStage);

        ValueTask<IQueryable> Visit(ExecuteWhereStage executeWhereStage);

        ValueTask<IQueryable> Visit(ExecuteOffsetStage executeOffsetStage);

        ValueTask<IQueryable> Visit(ExecuteDistinctStage executeDistinctStage);
    }
}
