using Koralium.SqlToExpression.Models;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal interface IQueryStage
    {
        SqlTypeInfo TypeInfo { get; }

        ParameterExpression ParameterExpression { get; }

        Type CurrentType { get; }

        FromAliases FromAliases { get; }

        void Accept(IQueryStageVisitor visitor);
    }
}
