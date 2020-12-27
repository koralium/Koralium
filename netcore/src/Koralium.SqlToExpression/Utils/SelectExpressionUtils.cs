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
using Koralium.SqlToExpression.Stages.CompileStages;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Utils
{
    internal static class SelectExpressionUtils
    {
        public static MemberInitExpression CreateSelectExpression(IQueryStage fromStage, ICollection<PropertyInfo> properties)
        {
            List<MemberAssignment> assignments = new List<MemberAssignment>();

            foreach(var property in properties)
            {
                var memberAccess = Expression.MakeMemberAccess(fromStage.ParameterExpression, property);
                var memberBinding = Expression.Bind(property, memberAccess);
                assignments.Add(memberBinding);
            }

            var newExpression = Expression.New(fromStage.CurrentType);
            var memberInit = Expression.MemberInit(newExpression, assignments);
            return memberInit;
        }
    }
}
