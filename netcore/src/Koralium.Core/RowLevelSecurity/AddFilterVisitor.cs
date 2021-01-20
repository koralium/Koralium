using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.RowLevelSecurity
{
    /// <summary>
    /// Visitor to help add to a where condition on a query
    /// </summary>
    class AddFilterVisitor : KoraliumSqlVisitor
    {
        private readonly BooleanExpression _toAdd;
        private bool _added = false;
        public AddFilterVisitor(BooleanExpression toAdd)
        {
            _toAdd = toAdd;
        }

        public override void VisitSelectStatement(SelectStatement selectStatement)
        {
            // Try to find the select statement closest to the table before applying the filter
            if (selectStatement.FromClause != null)
            {
                Visit(selectStatement.FromClause);
            }

            // Check so we have not already added the filter
            // This can happen in sub queries
            if (_added)
            {
                return;
            }
            if (selectStatement.WhereClause == null)
            {
                selectStatement.WhereClause = new SqlParser.Clauses.WhereClause()
                {
                    Expression = _toAdd
                };
            }
            else
            {
                selectStatement.WhereClause.Expression = QueryBuilder.And(selectStatement.WhereClause.Expression, _toAdd);
            }
            _added = true;
        }
    }
}
