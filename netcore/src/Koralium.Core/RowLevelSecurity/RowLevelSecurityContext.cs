using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium
{
    public abstract class RowLevelSecurityContext
    {
        internal abstract BooleanExpression Build();

        internal static RowLevelSecurityContext<Entity> Create<Entity>()
        {
            return new RowLevelSecurityContext<Entity>();
        }
    }

    public class RowLevelSecurityContext<TEntity> : RowLevelSecurityContext
    {
        private readonly List<BooleanExpression> filters = new List<BooleanExpression>();

        public RowLevelSecurityContext<TEntity> AddFilter(Expression<Func<TEntity, bool>> expression)
        {
            //add the filter
            AddFilter(QueryBuilder.BooleanExpression(expression));
            return this;
        }

        public RowLevelSecurityContext<TEntity> AddFilter(BooleanExpression booleanExpression)
        {
            //add the filter
            filters.Add(booleanExpression);
            return this;
        }

        internal override BooleanExpression Build()
        {
            return QueryBuilder.And(filters);
        }
    }
}
