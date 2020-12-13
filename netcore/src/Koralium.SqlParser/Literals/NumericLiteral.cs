using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Literals
{
    public class NumericLiteral : Literal
    {
        public decimal Value { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitNumericLiteral(this);
        }

        public override SqlNode Clone()
        {
            return new NumericLiteral()
            {
                Value = Value
            };
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}
