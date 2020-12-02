using Koralium.SqlParser.Visitor;

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
