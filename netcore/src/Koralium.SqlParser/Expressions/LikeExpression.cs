using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class LikeExpression : BooleanExpression
    {
        public ScalarExpression Left { get; set; }

        public ScalarExpression Right { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitLikeExpression(this);
        }
    }
}
