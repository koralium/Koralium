using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Interfaces
{
    public interface IStringOperationsProvider
    {
        Expression GetEqualsExpressions(Expression left, Expression right);

        Expression GetStartsWithExpression(Expression left, Expression right);

        Expression GetEndsWithExpression(Expression left, Expression right);

        Expression GetContainsExpression(Expression left, Expression right);
    }
}
