using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Visitor;
using System.Collections.Generic;
using System.Linq;

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

        public override SqlNode Clone()
        {
            return new GroupByClause()
            {
                Groups = Groups.Select(x => x.Clone() as Group).ToList()
            };
        }
    }
}
