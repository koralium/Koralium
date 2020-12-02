using Koralium.SqlParser.Visitor;
using System.Collections.Generic;

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
