using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class SelectStarExpression : SelectExpression
    {
        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectStarExpression(this);
        }
    }
}
