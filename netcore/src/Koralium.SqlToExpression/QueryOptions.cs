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
using Koralium.Shared;
using Koralium.SqlToExpression;
using Koralium.SqlToExpression.Indexing;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression
{
    internal class QueryOptions : IQueryOptions
    {
        private readonly ParameterExpression _parameterExpression;
        private MemberInitExpression _selectExpression;
        protected private Expression _whereExpression;
        private int? _limit;
        private int? _offset;

        public QueryOptions(
            ParameterExpression parameterExpression,
            MemberInitExpression selectExpression,
            Expression whereExpression,
            int? limit,
            int? offset,
            bool containsFullTextSearch,
            IReadSqlParameters parameters
            )
        {
            _parameterExpression = parameterExpression;
            _selectExpression = selectExpression;
            _whereExpression = whereExpression;
            _limit = limit;
            _offset = offset;
            ContainsFullTextSearch = containsFullTextSearch;
            Parameters = parameters;
        }

        public bool ContainsFullTextSearch { get; }

        public IReadSqlParameters Parameters { get; }

        public void CancelLimitExecution()
        {
            _limit = null;
        }

        public void CancelOffsetExecution()
        {
            _offset = null;
        }

        public void CancelSelectExecution()
        {
            _selectExpression = null;
        }

        public void CancelWhereExecution()
        {
            _whereExpression = null;
        }

        public IQueryOptions<Entity> CreateGeneric<Entity>()
        {
            return new QueryOptions<Entity>(_parameterExpression, _selectExpression, _whereExpression, _limit, _offset, ContainsFullTextSearch, Parameters);
        }

        public bool TryGetLimit(out int limit)
        {
            if(_limit != null) 
            {
                limit = _limit.Value;
                return true;
            }
            limit = default;
            return false;
        }

        public bool TryGetOffset(out int offset)
        {
            if(_offset != null)
            {
                offset = _offset.Value;
                return true;
            }
            offset = default;
            return false;
        }

        public bool TryGetSelectExpression<EntityType>(out Expression<Func<EntityType, EntityType>> selectExpression)
        {
            if(_selectExpression != null)
            {
                selectExpression = Expression.Lambda<Func<EntityType, EntityType>>(_selectExpression, _parameterExpression);
                return true;
            }
            else
            {
                selectExpression = null;
                return false;
            }
        }

        public bool TryGetWhereExpression<EntityType>(out Expression<Func<EntityType, bool>> whereExpression)
        {
            if(_whereExpression != null)
            {
                whereExpression = Expression.Lambda<Func<EntityType, bool>>(_whereExpression, _parameterExpression);
                return true;
            }
            else
            {
                whereExpression = null;
                return false;
            }
        }
    }

    internal class QueryOptions<Entity> : QueryOptions, IQueryOptions<Entity>
    {
        private IndexHelper<Entity> indexHelper;

        public QueryOptions(
            ParameterExpression parameterExpression,
            MemberInitExpression selectExpression,
            Expression whereExpression,
            int? limit,
            int? offset,
            bool containsFullTextSearch,
            IReadSqlParameters parameters
            )
            : base(parameterExpression, selectExpression, whereExpression, limit, offset, containsFullTextSearch, parameters)
        {
        }

        public bool TryGetEqualFiltersForProperty<TProp>(Expression<Func<Entity, TProp>> propertySelection, out System.Collections.Generic.IReadOnlyList<TProp> equalValues)
        {
            if(indexHelper == null)
            {
                indexHelper = new IndexHelper<Entity>(_whereExpression);
            }
            return indexHelper.TryGetEqualFiltersForProperty(propertySelection, out equalValues);
        }

        public bool TryGetSelectExpression(out Expression<Func<Entity, Entity>> selectExpression)
        {
            return base.TryGetSelectExpression<Entity>(out selectExpression);
        }

        public bool TryGetWhereExpression(out Expression<Func<Entity, bool>> whereExpression)
        {
            return base.TryGetWhereExpression<Entity>(out whereExpression);
        }
    }
}
