using Koralium.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.Core.Utils
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
