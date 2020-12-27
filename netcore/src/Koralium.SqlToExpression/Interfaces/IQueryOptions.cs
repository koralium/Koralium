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
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression
{
    public interface IQueryOptions
    {
        /// <summary>
        /// Get the where condition that will be applied on the queryable
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        bool TryGetWhereExpression<EntityType>(out Expression<Func<EntityType, bool>> whereExpression);

        /// <summary>
        /// If the where expression has already been used outside, use this method to remove it from the execution chain
        /// </summary>
        void CancelWhereExecution();

        /// <summary>
        /// Get the select expression that is required for the following stages
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        bool TryGetSelectExpression<EntityType>(out Expression<Func<EntityType, EntityType>> selectExpression);

        /// <summary>
        /// Use this if the required fields have already been selected and it is not required to be run
        /// </summary>
        void CancelSelectExecution();

        bool TryGetLimit(out int limit);

        void CancelLimitExecution();

        bool TryGetOffset(out int offset);

        void CancelOffsetExecution();

        IQueryOptions<Entity> CreateGeneric<Entity>();

        bool ContainsFullTextSearch { get; }

        IReadSqlParameters Parameters { get; }
    }

    public interface IQueryOptions<Entity>
    {
        /// <summary>
        /// Get the where condition that will be applied on the queryable
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        bool TryGetWhereExpression(out Expression<Func<Entity, bool>> whereExpression);

        /// <summary>
        /// If the where expression has already been used outside, use this method to remove it from the execution chain
        /// </summary>
        void CancelWhereExecution();

        /// <summary>
        /// Get the select expression that is required for the following stages
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        bool TryGetSelectExpression(out Expression<Func<Entity, Entity>> selectExpression);

        /// <summary>
        /// Use this if the required fields have already been selected and it is not required to be run
        /// </summary>
        void CancelSelectExecution();

        bool TryGetLimit(out int limit);

        void CancelLimitExecution();

        bool TryGetOffset(out int offset);

        void CancelOffsetExecution();

        bool ContainsFullTextSearch { get; }

        IReadSqlParameters Parameters { get; }
    }
}
