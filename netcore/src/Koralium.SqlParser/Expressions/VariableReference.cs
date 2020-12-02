using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class VariableReference : ScalarExpression
    {
        public string Name { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitVariableReference(this);
        }
    }
}
