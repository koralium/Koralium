using System.Linq.Expressions;

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
