using Koralium.SqlParser.Visitor;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlParser.Statements
{
    public class StatementList : SqlNode
    {
        public List<Statement> Statements { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitStatementList(this);
        }

        public override SqlNode Clone()
        {
            return new StatementList()
            {
                Statements = Statements.Select(x => x.Clone() as Statement).ToList()
            };
        }
    }
}
