using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.GroupBy
{
    internal class GroupByVisitor : KoraliumSqlVisitor
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

        public override void VisitColumnReference(ColumnReference columnReference)
        {
            var identifiers = columnReference.Identifiers;

            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
            var memberAccess = MemberUtils.GetMember(_previousStage, identifiers, out var property);
            _usedProperties.Add(property);

            _groupByExpressions.Add(new GroupByExpression(memberAccess, string.Join(".", identifiers), property));
        }
    }
}
