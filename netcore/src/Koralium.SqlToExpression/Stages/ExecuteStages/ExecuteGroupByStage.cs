using Koralium.SqlToExpression.Executors;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteGroupByStage : IExecuteStage
    {
        public Expression Expression { get; }

        public ParameterExpression ParameterExpression { get; }

        /// <summary>
        /// The type that represents the key, which is the fields in the group by
        /// </summary>
        public Type KeyType { get; }

        /// <summary>
        /// The type that represents the entity that was grouped
        /// </summary>
        public Type ValueType { get; }

        public ExecuteGroupByStage(
            Expression expression,
            ParameterExpression parameterExpression,
            Type keyType,
            Type valueType)
        {
            Expression = expression;
            ParameterExpression = parameterExpression;
            KeyType = keyType;
            ValueType = valueType;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
