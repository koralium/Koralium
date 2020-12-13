using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.GroupBy
{
    public class ExpressionGroup : Group
    {
        public ScalarExpression Expression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitExpressionGroup(this);
        }

        public override SqlNode Clone()
        {
            return new ExpressionGroup()
            {
                Expression = Expression.Clone() as ScalarExpression
            };
        }
    }
}
