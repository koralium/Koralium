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
