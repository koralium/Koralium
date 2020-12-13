using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Statements
{
    public class SetVariableStatement : Statement
    {
        public VariableReference VariableReference { get; set; }

        public ScalarExpression ScalarExpression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSetVariableStatement(this);
        }

        public override SqlNode Clone()
        {
            return new SetVariableStatement()
            {
                ScalarExpression = ScalarExpression.Clone() as ScalarExpression,
                VariableReference = VariableReference.Clone() as VariableReference
            };
        }
    }
}
