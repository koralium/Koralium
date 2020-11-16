using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

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
