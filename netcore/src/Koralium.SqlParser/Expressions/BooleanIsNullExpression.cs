using Koralium.SqlParser.Visitor;
using System.Text;

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
