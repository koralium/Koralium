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
using Koralium.SqlToExpression.Utils;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors.GroupBy
{
    internal class GroupByVisitor : TSqlFragmentVisitor
    {
        private readonly IQueryStage _previousStage;
        private readonly List<GroupByExpression> _groupByExpressions = new List<GroupByExpression>();
        private readonly List<PropertyInfo> _usedProperties = new List<PropertyInfo>();

        public IEnumerable<PropertyInfo> UsedProperties => _usedProperties;

        public IReadOnlyList<GroupByExpression> GroupByExpressions => _groupByExpressions;

        public GroupByVisitor(IQueryStage previousStage)
        {
            _previousStage = previousStage;
        }

        public override void ExplicitVisit(ColumnReferenceExpression columnReferenceExpression)
        {
            var identifiers = columnReferenceExpression.MultiPartIdentifier.Identifiers.Select(x => x.Value).ToList();

            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
            var memberAccess = MemberUtils.GetMember(_previousStage, identifiers, out var property);
            _usedProperties.Add(property);

            _groupByExpressions.Add(new GroupByExpression(memberAccess, string.Join(".", identifiers), property));
        }
    }
}
