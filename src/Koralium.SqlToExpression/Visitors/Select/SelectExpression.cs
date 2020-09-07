using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal class SelectExpression
    {
        public Expression Expression { get; }

        public string Alias { get; }

        public SelectExpression(Expression expression, string alias)
        {
            Debug.Assert(expression != null, $"{nameof(expression)} was null");

            Expression = expression;
            Alias = alias;
        }

        public SelectExpression(Expression expression, string newAlias, string oldAlias)
        {
            Debug.Assert(expression != null, $"{nameof(expression)} was null");

            Expression = expression;
            Alias = newAlias ?? oldAlias;
        }
    }
}
