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
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Koralium.SqlToExpression.Stages
{
    internal class StageConverter : IQueryStageVisitor
    {
        private ImmutableList<IExecuteStage>.Builder builder;
        public IImmutableList<IExecuteStage> Convert(IReadOnlyList<IQueryStage> stages)
        {
            builder = ImmutableList.CreateBuilder<IExecuteStage>();
            
            foreach(var stage in stages)
            {
                stage.Accept(this);
            }

            return builder.ToImmutableList();
        }

        public void Visit(FromTableStage fromTableStage)
        {
            builder.Add(new ExecuteFromTableStage(
                fromTableStage.TableName, 
                fromTableStage.CurrentType,
                fromTableStage.SelectExpression,
                fromTableStage.ParameterExpression,
                fromTableStage.WhereExpression,
                fromTableStage.Limit,
                fromTableStage.Offset,
                fromTableStage.ContainsFullTextSearch));
        }

        public void Visit(GroupByStage groupByStage)
        {
            builder.Add(new ExecuteGroupByStage(
                groupByStage.GroupByExpression, 
                groupByStage.ValueParameterExpression, 
                groupByStage.KeyType, 
                groupByStage.ValueType));
        }

        public void Visit(SelectStage selectStage)
        {
            builder.Add(new ExecuteSelectStage(
                selectStage.SelectExpression,
                selectStage.InParameterExpression,
                selectStage.OldType,
                selectStage.CurrentType,
                selectStage.Columns
                ));
        }

        public void Visit(WhereStage whereStage)
        {
            builder.Add(new ExecuteWhereStage(
                whereStage.WhereExpression, 
                whereStage.ParameterExpression, 
                whereStage.CurrentType));
        }

        public void Visit(GroupedOrderByStage groupedOrderByStage)
        {
            builder.Add(new ExecuteOrderByStage(
                groupedOrderByStage.SortItems, 
                groupedOrderByStage.ParameterExpression, 
                groupedOrderByStage.CurrentType));
        }

        public void Visit(OrderByStage orderByStage)
        {
            builder.Add(new ExecuteOrderByStage(
                orderByStage.SortItems,
                orderByStage.ParameterExpression,
                orderByStage.CurrentType
                ));
        }

        public void Visit(HavingStage havingStage)
        {
            builder.Add(new ExecuteWhereStage(
                havingStage.FilterExpression,
                havingStage.ParameterExpression,
                havingStage.CurrentType));
        }

        public void Visit(OffsetStage offsetStage)
        {
            builder.Add(new ExecuteOffsetStage(
                offsetStage.CurrentType,
                offsetStage.Skip,
                offsetStage.Take
                ));
        }

        public void Visit(DistinctStage distinctStage)
        {
            builder.Add(new ExecuteDistinctStage(distinctStage.CurrentType));
        }

        public void Visit(SelectAggregateFunctionStage selectAggregateFunctionStage)
        {
            builder.Add(new ExecuteAggregateFunctionStage(
                selectAggregateFunctionStage.FunctionName,

                ));
            throw new System.NotImplementedException();
        }
    }
}
