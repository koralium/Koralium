using Koralium.SqlParser.Visitor;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlParser.Expressions
{
    public class ColumnReference : ScalarExpression
    {
        public List<string> Identifiers { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitColumnReference(this);
        }

        public override SqlNode Clone()
        {
            return new ColumnReference()
            {
                Identifiers = Identifiers.ToList()
            };
        }

        public ColumnReference()
        {
            Identifiers = new List<string>();
        }
    }
}
