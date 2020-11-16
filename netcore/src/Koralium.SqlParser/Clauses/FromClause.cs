using Koralium.SqlParser.From;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Clauses
{
    public class FromClause : SqlNode
    {
        public TableReference TableReference { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitFromClause(this);
        }
    }
}
