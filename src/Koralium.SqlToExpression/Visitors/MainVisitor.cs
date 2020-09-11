using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Koralium.SqlToExpression.Visitors.Analyzers;
using Koralium.SqlToExpression.Visitors.Distinct;
using Koralium.SqlToExpression.Visitors.From;
using Koralium.SqlToExpression.Visitors.GroupBy;
using Koralium.SqlToExpression.Visitors.Having;
using Koralium.SqlToExpression.Visitors.Offset;
using Koralium.SqlToExpression.Visitors.OrderBy;
using Koralium.SqlToExpression.Visitors.Select;
using Koralium.SqlToExpression.Visitors.Where;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlToExpression.Visitors
{
    internal class MainVisitor : TSqlFragmentVisitor
    {
        private readonly List<IQueryStage> _stages = new List<IQueryStage>();
        private readonly VisitorMetadata _visitorMetadata;

        public IReadOnlyList<IQueryStage> Stages => _stages;

        private IQueryStage LastStage => _stages.Last();

        public MainVisitor(VisitorMetadata visitorMetadata)
        {
            _visitorMetadata = visitorMetadata;
        }

        public override void ExplicitVisit(QuerySpecification query)
        {
            //FROM
            if(query.FromClause != null)
            {
                _stages.AddRange(FromHelper.GetFromTableStage(query.FromClause, _visitorMetadata));
            }

            //WHERE
            if(query.WhereClause != null)
            {
                _stages.Add(WhereHelper.GetWhereStage(LastStage, query.WhereClause, _visitorMetadata));
            }

            //GROUP BY
            if(query.GroupByClause != null)
            {
                _stages.Add(GroupByHelper.GetGroupByStage(LastStage, query.GroupByClause));
            }
            else if (ContainsAggregateHelper.ContainsAggregate(query.SelectElements))
            {
                _stages.Add(GroupByUtils.CreateStaticGroupBy(LastStage));
            }

            //HAVING
            if(query.HavingClause != null)
            {
                _stages.Add(HavingHelper.GetHavingStage(LastStage, query.HavingClause, _visitorMetadata));
            }
            
            //ORDER BY
            if(query.OrderByClause != null)
            {
                _stages.Add(OrderByHelper.GetOrderByStage(LastStage, query.OrderByClause, _visitorMetadata));
            }

            //SELECT
            _stages.Add(SelectHelper.GetSelectStage(LastStage, query.SelectElements, _visitorMetadata));

            //DISTINCT
            if(query.UniqueRowFilter == UniqueRowFilter.Distinct)
            {
                _stages.Add(DistinctHelper.GetDistinctStage(LastStage));
            }

            //OFSET
            if(query.OffsetClause != null)
            {
                _stages.Add(OffsetHelper.GetOffsetStage(LastStage, query.OffsetClause, _visitorMetadata));
            }

            //TOP
            if(query.TopRowFilter != null){
                _stages.Add(OffsetHelper.GetOffsetStage(LastStage, query.TopRowFilter, _visitorMetadata));
            }
        }
    }
}
