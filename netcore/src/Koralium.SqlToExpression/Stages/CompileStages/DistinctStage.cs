using Koralium.SqlToExpression.Models;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class DistinctStage : IQueryStage
    {
        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type CurrentType { get; }

        public FromAliases FromAliases { get; }

        public DistinctStage(
            SqlTypeInfo sqlTypeInfo,
            ParameterExpression parameterExpression,
            Type type,
            FromAliases fromAliases
            )
        {
            TypeInfo = sqlTypeInfo;
            ParameterExpression = parameterExpression;
            CurrentType = type;
            FromAliases = fromAliases;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
