using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class SelectScalarExpression : SelectExpression
    {
        public ScalarExpression Expression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectScalarExpression(this);
        }
    }
}
