using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Extensions
{
    public static class ExpressionExtensions
    {
        public static bool IsNull(this Expression expression)
        {
            if (expression == null)
                return true;

            if(expression is ConstantExpression constantExpression && constantExpression.Value == null)
            {
                return true;
            }
            return false;
        }
    }
}
