using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Indexing
{
    class IndexHelper<TEntity>
    {
        private readonly Expression _whereExpression;
        private readonly IReadOnlyDictionary<string, List<object>> _filters;

        public IndexHelper(Expression whereExpression)
        {
            _whereExpression = whereExpression;
            _filters = CreateFilters();
        }

        private IReadOnlyDictionary<string, List<object>> CreateFilters()
        {
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();
            indexBuilderVisitor.Visit(_whereExpression);
            return indexBuilderVisitor.Filters;
        }

        public bool TryGetEqualFiltersForProperty<TProp>(Expression<Func<TEntity, TProp>> propertySelection, out IReadOnlyList<TProp> equalValues)
        {
            if (propertySelection.Body is MemberExpression memberExpression)
            {
                var key = IndexBuilderVisitor.GetStringFromMemberExpression(memberExpression);

                List<TProp> output = new List<TProp>();
                if (_filters.TryGetValue(key, out var values))
                {
                    foreach (var val in values)
                    {
                        if (val is TProp propVal)
                        {
                            output.Add(propVal);
                        }
                    }
                    equalValues = output;
                    return true;
                }
                equalValues = null;
                return false;
            }
            else
            {
                throw new NotSupportedException($"Can only get filters for a property selection");
            }
        }

    }
}
