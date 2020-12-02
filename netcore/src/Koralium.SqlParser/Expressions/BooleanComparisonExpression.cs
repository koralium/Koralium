using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class BooleanComparisonExpression : BooleanExpression
    {
        public ScalarExpression Left { get; set; }

        public ScalarExpression Right { get; set; } 

        public BooleanComparisonType Type { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBooleanComparisonExpression(this);
        }
    }
}
