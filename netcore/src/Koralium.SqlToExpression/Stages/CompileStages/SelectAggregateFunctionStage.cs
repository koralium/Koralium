using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class SelectAggregateFunctionStage : IQueryStage
    {
        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type CurrentType { get; }

        public Type OldType { get; }

        public FromAliases FromAliases { get; }

        public string FunctionName { get; }

        public ParameterExpression InParameter { get; }

        public string ColumnName { get; }

        public IImmutableList<Expression> Parameters { get; }

        public Type FunctionOutType { get; }

        public SelectAggregateFunctionStage(
            SqlTypeInfo sqlTypeInfo,
            ParameterExpression parameterExpression,
            Type currentType,
            Type oldType,
            FromAliases fromAliases,
            string functionName,
            ParameterExpression inParameter,
            string columnName,
            IImmutableList<Expression> parameters,
            Type functionOutType
            )
        {
            TypeInfo = sqlTypeInfo;
            ParameterExpression = parameterExpression;
            CurrentType = currentType;
            FromAliases = fromAliases;
            FunctionName = functionName;
            InParameter = inParameter;
            OldType = oldType;
            ColumnName = columnName;
            Parameters = parameters;
            FunctionOutType = functionOutType;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
