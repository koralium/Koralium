using Koralium.SqlToExpression.Models;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class WhereStage : IQueryStage
    {
        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Expression WhereExpression { get; }

        public Type CurrentType { get; }

        public FromAliases FromAliases { get; }

        public WhereStage(
            SqlTypeInfo sqlTypeInfo,
            ParameterExpression parameterExpression,
            Expression whereExpression,
            Type type,
            FromAliases fromAliases
            )
        {
            TypeInfo = sqlTypeInfo;
            ParameterExpression = parameterExpression;
            WhereExpression = whereExpression;
            CurrentType = type;
            FromAliases = fromAliases;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
