using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class SelectScalarExpression : SelectExpression
    {
        public ScalarExpression Expression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectScalarExpression(this);
        }

        public override SqlNode Clone()
        {
            return new SelectScalarExpression()
            {
                Alias = Alias,
                Expression = Expression.Clone() as ScalarExpression
            };
        }
    }
}
