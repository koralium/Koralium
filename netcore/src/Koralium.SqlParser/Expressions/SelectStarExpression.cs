using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class SelectStarExpression : SelectExpression
    {
        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectStarExpression(this);
        }

        public override SqlNode Clone()
        {
            return new SelectStarExpression()
            {
                Alias = Alias
            };
        }
    }
}
