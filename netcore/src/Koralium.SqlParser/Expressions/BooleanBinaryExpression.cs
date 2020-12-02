using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class BooleanBinaryExpression : BooleanExpression
    {
        public BooleanExpression Left { get; set; }

        public BooleanExpression Right { get; set; }

        public BooleanBinaryType Type { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBooleanBinaryExpression(this);
        }
    }
}
