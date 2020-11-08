using Koralium.SqlToExpression.Executors;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteAggregateFunctionStage : IExecuteStage
    {
        public string FunctionName { get; }

        public string ColumnName { get; set; }

        public Type InType { get; }

        public IImmutableList<Expression> Parameters { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type OutType { get; }

        public ExecuteAggregateFunctionStage(
            string functionName,
            Type inType,
            string columnName,
            IImmutableList<Expression> parameters,
            ParameterExpression parameterExpression,
            Type outType)
        {
            FunctionName = functionName;
            InType = inType;
            ColumnName = columnName;
            Parameters = parameters;
            ParameterExpression = parameterExpression;
            OutType = outType;
        }


        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
