/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.SqlToExpression.Exceptions;
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
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors
{
    internal class MainVisitor : TSqlFragmentVisitor
    {
        private readonly List<IQueryStage> _stages = new List<IQueryStage>();
        private readonly VisitorMetadata _visitorMetadata;
        private HashSet<PropertyInfo> _usedProperties = new HashSet<PropertyInfo>();
        public IReadOnlyList<IQueryStage> Stages => _stages;

        private IQueryStage LastStage => _stages.Last();

        public MainVisitor(VisitorMetadata visitorMetadata)
        {
            _visitorMetadata = visitorMetadata;
        }

        public override void ExplicitVisit(QuerySpecification query)
        {
            FromTableStage fromTable = null;
            //FROM
            if(query.FromClause != null)
            {
                var fromStages = FromHelper.GetFromTableStage(query.FromClause, _visitorMetadata);

                //Check if it is only a from table stage, this is used to add used properties into
                if(fromStages.Count == 1 && fromStages[0] is FromTableStage fromTableStage)
                {
                    fromTable = fromTableStage;
                }

                _stages.AddRange(fromStages);
            }
            else
            {
                throw new SqlErrorException("Selects must always have FROM");
            }

            //WHERE
            if(query.WhereClause != null)
            {
                var whereStage = WhereHelper.GetWhereStage(LastStage, query.WhereClause, _visitorMetadata, _usedProperties);

                if(LastStage is FromTableStage fromTableStage)
                {
                    //Push the where condition into the table resolvers
                    fromTableStage.WhereExpression = whereStage.WhereExpression;
                    fromTableStage.ContainsFullTextSearch = whereStage.ContainsFullTextSearch;
                }
                else
                {
                    //If its not possible to push up, add it as a normal stage
                    _stages.Add(whereStage);
                }
            }

            //GROUP BY
            if(query.GroupByClause != null)
            {
                _stages.Add(GroupByHelper.GetGroupByStage(LastStage, query.GroupByClause, _usedProperties));
            }
            else if (ContainsAggregateHelper.ContainsAggregate(query.SelectElements))
            {
                _stages.Add(GroupByUtils.CreateStaticGroupBy(LastStage));
            }

            //HAVING
            if(query.HavingClause != null)
            {
                _stages.Add(HavingHelper.GetHavingStage(LastStage, query.HavingClause, _visitorMetadata, _usedProperties));
            }
            
            //ORDER BY
            if(query.OrderByClause != null)
            {
                _stages.Add(OrderByHelper.GetOrderByStage(LastStage, query.OrderByClause, _visitorMetadata, _usedProperties));
            }

            //SELECT
            _stages.Add(SelectHelper.GetSelectStage(LastStage, query.SelectElements, _visitorMetadata, _usedProperties));

            //DISTINCT
            if(query.UniqueRowFilter == UniqueRowFilter.Distinct)
            {
                _stages.Add(DistinctHelper.GetDistinctStage(LastStage));
            }

            //OFSET
            if(query.OffsetClause != null)
            {
                var offsetStage = OffsetHelper.GetOffsetStage(LastStage, query.OffsetClause, _visitorMetadata);

                //Check if we can push the values into the table scan
                if(LastStage is FromTableStage fromTableStage)
                {
                    fromTableStage.Limit = offsetStage.Take;
                    fromTableStage.Offset = offsetStage.Skip;
                }
                else
                {
                    _stages.Add(OffsetHelper.GetOffsetStage(LastStage, query.OffsetClause, _visitorMetadata));
                }
            }

            //TOP
            if(query.TopRowFilter != null){
                var offsetStage = OffsetHelper.GetOffsetStage(LastStage, query.TopRowFilter, _visitorMetadata);

                if(LastStage is FromTableStage fromTableStage)
                {
                    fromTableStage.Limit = offsetStage.Take;
                    fromTableStage.Offset = offsetStage.Skip;
                }
                else
                {
                    _stages.Add(OffsetHelper.GetOffsetStage(LastStage, query.TopRowFilter, _visitorMetadata));
                }
            }

            //Add a select stage that selects all the properties required
            //This should be added to be done directly after the 'from table' stage
            //This helps solve some issues with automapper related issues where extra complicated queries in
            //entity framework are created
            if (fromTable != null)
            {
                fromTable.SelectExpression = SelectExpressionUtils.CreateSelectExpression(fromTable, _usedProperties);
            }
        }
    }
}
