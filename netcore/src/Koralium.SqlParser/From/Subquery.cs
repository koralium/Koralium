using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.From
{
    public class Subquery : TableReference
    {
        public SelectStatement SelectStatement { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSubquery(this);
        }
    }
}
