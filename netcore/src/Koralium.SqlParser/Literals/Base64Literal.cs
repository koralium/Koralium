using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Literals
{
    public class Base64Literal : Literal
    {
        public string Value { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBase64Literal(this);
        }

        public override SqlNode Clone()
        {
            return new Base64Literal()
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
