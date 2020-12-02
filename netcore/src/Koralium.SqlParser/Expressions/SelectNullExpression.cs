using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class SelectNullExpression : SelectExpression
    {
        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectNullExpression(this);
        }
    }
}
