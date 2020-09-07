using Koralium.SqlToExpression.Executors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteDistinctStage : IExecuteStage
    {
        public Type Type { get; }

        public ExecuteDistinctStage(Type type)
        {
            Type = type;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
