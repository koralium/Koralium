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

        public override SqlNode Clone()
        {
            return new BooleanIsNullExpression()
            {
                IsNot = IsNot,
                ScalarExpression = ScalarExpression.Clone() as ScalarExpression
            };
        }
    }
}
