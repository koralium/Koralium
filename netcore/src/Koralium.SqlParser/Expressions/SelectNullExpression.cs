using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class SelectNullExpression : SelectExpression
    {
        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectNullExpression(this);
        }

        public override SqlNode Clone()
        {
            return new SelectNullExpression()
            {
                Alias = Alias
            };
        }
    }
}
