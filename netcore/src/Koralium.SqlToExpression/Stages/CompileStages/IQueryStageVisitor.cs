namespace Koralium.SqlToExpression.Stages.CompileStages
{
    interface IQueryStageVisitor
    {
        void Visit(FromTableStage fromTableStage);

        void Visit(GroupByStage groupByStage);

        void Visit(SelectStage selectStage);

        void Visit(WhereStage whereStage);

        void Visit(GroupedOrderByStage groupedOrderByStage);

        void Visit(OrderByStage orderByStage);

        void Visit(HavingStage havingStage);

        void Visit(OffsetStage offsetStage);

        void Visit(DistinctStage distinctStage);
    }
}
