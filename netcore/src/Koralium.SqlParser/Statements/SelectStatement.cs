using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Statements;
using Koralium.SqlParser.Visitor;
using System.Collections.Generic;

namespace Koralium.SqlParser
{
    public class SelectStatement : Statement
    {
        public SelectStatement() 
        {
            SelectElements = new List<SelectExpression>();
        }

        public bool Distinct { get; set; }

        public List<SelectExpression> SelectElements { get; set; }

        public FromClause FromClause { get; set; }

        public WhereClause WhereClause { get; set; }

        public GroupByClause GroupByClause { get; set; }

        public HavingClause HavingClause { get; set; }

        public OrderByClause OrderByClause { get; set; }

        public OffsetLimitClause OffsetLimitClause { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectStatement(this);
        }
    }
}
