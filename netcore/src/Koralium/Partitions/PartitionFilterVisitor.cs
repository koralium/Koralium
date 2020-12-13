using Koralium.SqlParser;
using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Partitions
{

    class PartitionFilterVisitor : KoraliumSqlVisitor
    {
        private bool filterSet = false;
        private readonly BooleanExpression _filter;

        public PartitionFilterVisitor(BooleanExpression filter)
        {
            _filter = filter;
        }

        public override void VisitSelectStatement(SelectStatement selectStatement)
        {
            Visit(selectStatement.FromClause);

            if (!filterSet)
            {
                if(selectStatement.WhereClause != null)
                {
                    Visit(selectStatement.WhereClause);
                }
                else
                {
                    selectStatement.WhereClause = new WhereClause();
                }
            }
            Visit(selectStatement.WhereClause);
        }

        public override void VisitWhereClause(WhereClause whereClause)
        {
            if(whereClause.Expression != null) //Merge
            {
                whereClause.Expression = QueryBuilder.And(whereClause.Expression, _filter);
            }
            else //Set the filter
            {
                whereClause.Expression = _filter;
            }
        }
    }
}
