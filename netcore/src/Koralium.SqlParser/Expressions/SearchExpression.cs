using Koralium.SqlParser.Visitor;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlParser.Expressions
{
    public class SearchExpression : BooleanExpression
    {
        /// <summary>
        /// Set if all possible columns should be searched, (wildcard)
        /// </summary>
        public bool AllColumns { get; set; }

        public List<ColumnReference> Columns { get; set; }

        public ScalarExpression Value { get; set; }

        public SearchExpression()
        {
            Columns = new List<ColumnReference>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSearchExpression(this);
        }

        public override SqlNode Clone()
        {
            return new SearchExpression()
            {
                AllColumns = AllColumns,
                Columns = Columns.Select(x => x.Clone() as ColumnReference).ToList(),
                Value = Value.Clone() as ScalarExpression
            };
        }
    }
}
