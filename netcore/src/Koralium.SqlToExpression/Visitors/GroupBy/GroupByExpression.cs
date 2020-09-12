using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.GroupBy
{
    public class GroupByExpression
    {
        public Expression Expression { get; }

        public string Name { get; }

        public GroupByExpression(Expression expression, string name)
        {
            Expression = expression;
            Name = name;
        }
    }
}
