using Koralium.SqlToExpression.Executors;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteWhereStage : IExecuteStage
    {
        public Expression Expression { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type EntityType { get; }

        public ExecuteWhereStage(
            Expression expression,
            ParameterExpression parameterExpression,
            Type entityType)
        {
            Expression = expression;
            ParameterExpression = parameterExpression;
            EntityType = entityType;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
