using Koralium.SqlToExpression.Executors;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteSelectStage : IExecuteStage
    {
        public MemberInitExpression Expression { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type InType { get; }

        public Type OutType { get; }

        public IImmutableList<ColumnMetadata> Columns { get; }

        public ExecuteSelectStage(
            MemberInitExpression expression,
            ParameterExpression parameterExpression,
            Type inType,
            Type outType,
            IImmutableList<ColumnMetadata> columns)
        {
            Expression = expression;
            ParameterExpression = parameterExpression;
            InType = inType;
            OutType = outType;
            Columns = columns;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
