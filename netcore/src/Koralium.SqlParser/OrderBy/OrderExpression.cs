using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.OrderBy
{
    public class OrderExpression : OrderElement
    {
        public ScalarExpression Expression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitOrderExpression(this);
        }

        public override SqlNode Clone()
        {
            return new OrderExpression()
            {
                Ascending = Ascending,
                Expression = Expression.Clone() as ScalarExpression
            };
        }
    }
}
