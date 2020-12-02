using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Literals
{
    public class NullLiteral : Literal
    {
        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitNullLiteral(this);
        }

        public override object GetValue()
        {
            return null;
        }
    }
}
