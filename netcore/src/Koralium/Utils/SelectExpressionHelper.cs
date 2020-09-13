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
using Koralium.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Koralium.Utils
{
    public static class SelectExpressionHelper
    {
        public static Expression<Func<T, T>> CreateSelectExpression<T>(KoraliumTable table, List<string> select, bool allowNullObjects)
        {
            var param = Expression.Parameter(typeof(T), "t");
            var memberInit = CreateSelectExpression(typeof(T), table.Columns, select, param, 0, allowNullObjects);

            var lambdaExp = (Expression<Func<T, T>>)Expression.Lambda(memberInit, param);

            return lambdaExp;
        }

        public static MemberInitExpression CreateSelectExpression(Type objectType, IReadOnlyList<TableColumn> columns, List<string> select, Expression param, int depth, bool allowNullObjects)
        {
            List<MemberAssignment> assignments = new List<MemberAssignment>();
            //First handle the normal values

            for (int i = 0; i < select.Count; i++)
            {
                var column = columns.FirstOrDefault(x => x.Name.Equals(select[i], StringComparison.InvariantCultureIgnoreCase));

                if(column == null)
                {
                    throw new Exception("Column does not exist");
                }

                var memberAccess = Expression.MakeMemberAccess(param, column.Member);
                var memberBinding = Expression.Bind(column.Member, memberAccess);
                assignments.Add(memberBinding);
            }

            var newExpression = Expression.New(objectType);
            var memberInit = Expression.MemberInit(newExpression, assignments);

            return memberInit;
        }
    }
}
