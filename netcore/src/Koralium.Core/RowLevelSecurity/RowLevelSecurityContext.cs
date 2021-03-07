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
using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
