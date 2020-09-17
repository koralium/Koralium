using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

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
