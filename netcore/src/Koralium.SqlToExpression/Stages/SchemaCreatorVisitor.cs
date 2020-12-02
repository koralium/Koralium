using Koralium.SqlToExpression.Stages.CompileStages;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Koralium.SqlToExpression.Stages
{
    class SchemaCreatorVisitor : IQueryStageVisitor
    {
        private IImmutableList<ColumnMetadata> _columns;

        public IImmutableList<ColumnMetadata> GetColumns(IReadOnlyList<IQueryStage> stages)
        {
            foreach(var stage in stages)
            {
                stage.Accept(this);
            }
            return _columns;
        }

        public void Visit(FromTableStage fromTableStage)
        {
            //NOP
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
