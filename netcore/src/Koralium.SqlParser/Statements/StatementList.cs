using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Statements
{
    public class StatementList : SqlNode
    {
        public List<Statement> Statements { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitStatementList(this);
        }
    }
}
