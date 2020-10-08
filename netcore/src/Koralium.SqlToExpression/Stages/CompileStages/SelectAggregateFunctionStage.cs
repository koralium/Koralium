using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class SelectAggregateFunctionStage : IQueryStage
    {
        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type CurrentType { get; }

        public FromAliases FromAliases { get; }

        public string FunctionName { get; }

        public Expression Parameter { get; }

        public IImmutableList<ColumnMetadata> Columns { get; }

        public SelectAggregateFunctionStage(
            SqlTypeInfo sqlTypeInfo,
            ParameterExpression parameterExpression,
            Type currentType,
            FromAliases fromAliases,
            string functionName,
            Expression parameter,
            IImmutableList<ColumnMetadata> columns
            )
        {
            TypeInfo = sqlTypeInfo;
            ParameterExpression = parameterExpression;
            CurrentType = currentType;
            FromAliases = fromAliases;
            FunctionName = functionName;
            Parameter = parameter;
            Columns = columns;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
