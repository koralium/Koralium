using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Models
{
    public class SortItem
    {
        public Expression Expression { get; }

        public bool Descending { get; }

        internal SortItem(Expression expression, bool descending)
        {
            Expression = expression;
            Descending = descending;
        }
    }
}
