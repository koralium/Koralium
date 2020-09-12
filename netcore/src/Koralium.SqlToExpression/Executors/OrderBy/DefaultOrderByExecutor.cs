using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultOrderByExecutor<Entity> : OrderByExecutor<Entity>
    {
        public override ValueTask<IQueryable<Entity>> ExecuteOrderBy(IQueryable<Entity> queryable, ExecuteOrderByStage executeOrderByStage)
        {
            var sortItems = executeOrderByStage.SortItems;

            if (sortItems.Count == 0)
                return new ValueTask<IQueryable<Entity>>(queryable);

            int i = 0;

            var sortItem = sortItems[i];
            var lambda = GetSortLambda(sortItem, executeOrderByStage.ParameterExpression);

            IOrderedQueryable<Entity> orderedQueryable;
            if (sortItem.Descending)
            {
                orderedQueryable = queryable.OrderByDescending(lambda);
            }
            else
            {
                orderedQueryable = queryable.OrderBy(lambda);
            }
            i++;

            for(; i < sortItems.Count; i++)
            {
                sortItem = sortItems[i];
                lambda = GetSortLambda(sortItem, executeOrderByStage.ParameterExpression);

                if (sortItem.Descending)
                {
                    orderedQueryable = orderedQueryable.ThenByDescending(lambda);
                }
                else
                {
                    orderedQueryable = orderedQueryable.ThenBy(lambda);
                }
            }
            return new ValueTask<IQueryable<Entity>>(orderedQueryable);
        }
    }
}
