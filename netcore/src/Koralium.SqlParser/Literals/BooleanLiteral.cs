using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Literals
{
    public class BooleanLiteral : Literal
    {
        public bool Value { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBooleanLiteral(this);
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}
