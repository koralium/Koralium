using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Visitor;
using System.Collections.Generic;

namespace Koralium.SqlParser.Clauses
{
    public class GroupByClause : SqlNode
    {
        public List<Group> Groups { get; set; }

        public GroupByClause()
        {
            Groups = new List<Group>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitGroupByClause(this);
        }
    }
}
