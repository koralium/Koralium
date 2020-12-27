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
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Koralium.SqlToExpression.Stages
{
    class SchemaCreatorVisitor : IQueryStageVisitor
    {
        private string _fromTableName = null;
        private IImmutableList<ColumnMetadata> _columns;

        public SchemaResult GetSchema(IReadOnlyList<IQueryStage> stages)
        {
            foreach (var stage in stages)
            {
                stage.Accept(this);
            }
            return new SchemaResult(_fromTableName, _columns);
        }

        public void Visit(FromTableStage fromTableStage)
        {
            if(_fromTableName == null)
            {
                _fromTableName = fromTableStage.TableName;
            }
        }

        public void Visit(GroupByStage groupByStage)
        {
            //NOP
        }

        public void Visit(SelectStage selectStage)
        {
            _columns = selectStage.Columns;
        }

        public void Visit(WhereStage whereStage)
        {
            //NOP
        }

        public void Visit(GroupedOrderByStage groupedOrderByStage)
        {
            //NOP
        }

        public void Visit(OrderByStage orderByStage)
        {
            //NOP
        }

        public void Visit(HavingStage havingStage)
        {
            //NOP
        }

        public void Visit(OffsetStage offsetStage)
        {
            //NOP
        }

        public void Visit(DistinctStage distinctStage)
        {
            //NOP
        }

        public void Visit(SelectAggregateFunctionStage selectAggregateFunctionStage)
        {
            _columns = ImmutableList.Create(new ColumnMetadata(selectAggregateFunctionStage.ColumnName, selectAggregateFunctionStage.FunctionOutType, null));
        }
    }
}
