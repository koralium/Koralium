﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression
{
    internal class QueryOptions : IQueryOptions
    {
        private ParameterExpression _parameterExpression;
        private MemberInitExpression _selectExpression;
        private Expression _whereExpression;
        private int? _limit;
        private int? _offset;

        public QueryOptions(
            ParameterExpression parameterExpression,
            MemberInitExpression selectExpression,
            Expression whereExpression,
            int? limit,
            int? offset,
            bool containsFullTextSearch
            )
        {
            _parameterExpression = parameterExpression;
            _selectExpression = selectExpression;
            _whereExpression = whereExpression;
            _limit = limit;
            _offset = offset;
            ContainsFullTextSearch = containsFullTextSearch;
        }

        public bool ContainsFullTextSearch { get; }

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
            return new QueryOptions<Entity>(_parameterExpression, _selectExpression, _whereExpression, _limit, _offset, ContainsFullTextSearch);
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
        public QueryOptions(
            ParameterExpression parameterExpression,
            MemberInitExpression selectExpression,
            Expression whereExpression,
            int? limit,
            int? offset,
            bool containsFullTextSearch
            )
            : base(parameterExpression, selectExpression, whereExpression, limit, offset, containsFullTextSearch)
        {
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