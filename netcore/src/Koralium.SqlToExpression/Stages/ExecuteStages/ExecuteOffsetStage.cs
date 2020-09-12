using Koralium.SqlToExpression.Executors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteOffsetStage : IExecuteStage
    {
        public Type Type { get; }

        public int? Skip { get; }

        public int? Take { get; }

        public ExecuteOffsetStage(Type type, int? skip, int? take)
        {
            Type = type;
            Skip = skip;
            Take = take;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
