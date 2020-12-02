using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser.GroupBy
{
    public class ExpressionGroup : Group
    {
        public ScalarExpression Expression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitExpressionGroup(this);
        }
    }
}
