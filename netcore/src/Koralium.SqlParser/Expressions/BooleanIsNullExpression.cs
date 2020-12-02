using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class BooleanIsNullExpression : BooleanExpression
    {
        public bool IsNot { get; set; }

        public ScalarExpression ScalarExpression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBooleanIsNullExpression(this);
        }
    }
}
