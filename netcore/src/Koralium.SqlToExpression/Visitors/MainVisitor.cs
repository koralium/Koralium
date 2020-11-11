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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors
{
    internal class MainVisitor : TSqlFragmentVisitor
    {
        private readonly List<IQueryStage> _stages = new List<IQueryStage>();
        private readonly VisitorMetadata _visitorMetadata;
        private readonly HashSet<PropertyInfo> _usedProperties = new HashSet<PropertyInfo>();
        private FromTableStage _fromTable;

        public IReadOnlyList<IQueryStage> Stages => _stages;

        private IQueryStage LastStage => _stages.Last();

        public MainVisitor(VisitorMetadata visitorMetadata)
        {
            _visitorMetadata = visitorMetadata;
        }

        private void HandleFromClause(QuerySpecification node)
        {
            if (node.FromClause != null)
            {
                var fromStages = FromHelper.GetFromTableStage(node.FromClause, _visitorMetadata);

                //Check if it is only a from table stage, this is used to add used properties into
                if (fromStages.Count == 1 && fromStages[0] is FromTableStage fromTableStage)
                {
                    _fromTable = fromTableStage;
                }

                _stages.AddRange(fromStages);
            }
            else
            {
                throw new SqlErrorException("Selects must always have FROM");
            }
        }

        private void HandleWhereClause(QuerySpecification node)
        {
            if (node.WhereClause != null)
            {
                var whereStage = WhereHelper.GetWhereStage(LastStage, node.WhereClause, _visitorMetadata, _usedProperties);

                if (LastStage is FromTableStage fromTableStage)
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
        }

        private void HandleGroupByClause(QuerySpecification node, bool containsAggregates)
        {
            if (node.GroupByClause != null)
            {
                _stages.Add(GroupByHelper.GetGroupByStage(LastStage, node.GroupByClause, _usedProperties));
            }
            else if (containsAggregates && !IsSimpleAggregate(node))
            {
                _stages.Add(GroupByUtils.CreateStaticGroupBy(LastStage));
            }
        }

        private static bool IsSimpleAggregate(QuerySpecification node)
        {
            if(node.SelectElements.Count > 1 || node.HavingClause != null || node.GroupByClause != null)
            {
                return false;
            }
            if(node.SelectElements.Count == 1 &&
                node.SelectElements[0] is SelectScalarExpression selectScalarExpression &&
                selectScalarExpression.Expression is FunctionCall)
            {
                return true;
            }
            return false;
        }

        private void HandleHavingClause(QuerySpecification node)
        {
            if (node.HavingClause != null)
            {
                _stages.Add(HavingHelper.GetHavingStage(LastStage, node.HavingClause, _visitorMetadata, _usedProperties));
            }
        }

        private void HandleOrderByClause(QuerySpecification node)
        {
            if (node.OrderByClause != null)
            {
                _stages.Add(OrderByHelper.GetOrderByStage(LastStage, node.OrderByClause, _visitorMetadata, _usedProperties));
            }
        }

        private void HandleSelect(QuerySpecification node, bool containsAggregates)
        {
            if (containsAggregates && IsSimpleAggregate(node))
            {
                _stages.Add(SelectHelper.GetSelectAggregateFunctionStage(LastStage, node.SelectElements, _visitorMetadata, _usedProperties));
            }
            else
            {
                _stages.Add(SelectHelper.GetSelectStage(LastStage, node.SelectElements, _visitorMetadata, _usedProperties));
            }   
        }

        private void HandleDistinct(QuerySpecification node)
        {
            if (node.UniqueRowFilter == UniqueRowFilter.Distinct)
            {
                _stages.Add(DistinctHelper.GetDistinctStage(LastStage));
            }
        }

        private void HandleOffsetClause(QuerySpecification node)
        {
            if (node.OffsetClause != null)
            {
                var offsetStage = OffsetHelper.GetOffsetStage(LastStage, node.OffsetClause, _visitorMetadata);

                //Check if we can push the values into the table scan
                if (LastStage is FromTableStage fromTableStage)
                {
                    fromTableStage.Limit = offsetStage.Take;
                    fromTableStage.Offset = offsetStage.Skip;
                }
                else
                {
                    _stages.Add(OffsetHelper.GetOffsetStage(LastStage, node.OffsetClause, _visitorMetadata));
                }
            }
        }

        private void HandleTop(QuerySpecification node)
        {
            if (node.TopRowFilter != null)
            {
                var offsetStage = OffsetHelper.GetOffsetStage(LastStage, node.TopRowFilter, _visitorMetadata);

                if (LastStage is FromTableStage fromTableStage)
                {
                    fromTableStage.Limit = offsetStage.Take;
                    fromTableStage.Offset = offsetStage.Skip;
                }
                else
                {
                    _stages.Add(OffsetHelper.GetOffsetStage(LastStage, node.TopRowFilter, _visitorMetadata));
                }
            }
        }

        public override void ExplicitVisit(SetVariableStatement node)
        {
            if(node.Expression is StringLiteral stringLiteral)
            {
                _visitorMetadata.Parameters.Add(SqlParameter.Create(node.Variable.Name, stringLiteral.Value));
            }
            else if(node.Expression is IntegerLiteral integerLiteral)
            {
                if(int.TryParse(integerLiteral.Value, out var value))
                {
                    _visitorMetadata.Parameters.Add(SqlParameter.Create(node.Variable.Name, value));
                }
                else
                {
                    throw new SqlErrorException($"Could not parse '{integerLiteral.Value}' as an integer");
                }
            }
            else if(node.Expression is NumericLiteral numericLiteral)
            {
                var value = double.Parse(numericLiteral.Value, CultureInfo.InvariantCulture);
                _visitorMetadata.Parameters.Add(SqlParameter.Create(node.Variable.Name, value));
            }
            else
            {
                throw new NotImplementedException($"The parameter type: {node.Expression.GetType().Name} is not implemented");
            }
            
            //node.Expression
        }

        public override void ExplicitVisit(QuerySpecification node)
        {
            HandleFromClause(node);
            HandleWhereClause(node);

            var containsAggregates = ContainsAggregateHelper.ContainsAggregate(node.SelectElements);

            HandleGroupByClause(node, containsAggregates);
            HandleHavingClause(node);
            HandleOrderByClause(node);
            HandleSelect(node, containsAggregates);
            HandleDistinct(node);
            HandleOffsetClause(node);
            HandleTop(node);

            //Add a select stage that selects all the properties required
            //This should be added to be done directly after the 'from table' stage
            //This helps solve some issues with automapper related issues where extra complicated queries in
            //entity framework are created
            if (_fromTable != null && _usedProperties.Count > 0)
            {
                _fromTable.SelectExpression = SelectExpressionUtils.CreateSelectExpression(_fromTable, _usedProperties);
            }
        }
    }
}
