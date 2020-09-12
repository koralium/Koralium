using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlToExpression.Visitors.GroupBy
{
    internal class GroupByVisitor : TSqlFragmentVisitor
    {
        private readonly IQueryStage _previousStage;
        private readonly List<GroupByExpression> _groupByExpressions = new List<GroupByExpression>();

        public IReadOnlyList<GroupByExpression> GroupByExpressions => _groupByExpressions;

        public GroupByVisitor(IQueryStage previousStage)
        {
            _previousStage = previousStage;
        }

        public override void ExplicitVisit(ColumnReferenceExpression columnReferenceExpression)
        {
            var identifiers = columnReferenceExpression.MultiPartIdentifier.Identifiers.Select(x => x.Value).ToList();

            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
            var memberAccess = MemberUtils.GetMember(_previousStage, identifiers);

            _groupByExpressions.Add(new GroupByExpression(memberAccess, string.Join(".", identifiers)));
        }
    }
}
