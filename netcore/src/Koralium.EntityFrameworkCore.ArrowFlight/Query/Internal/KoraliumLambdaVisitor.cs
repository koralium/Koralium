using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Query.Internal
{
    internal class KoraliumLambdaVisitor : SqlExpressionVisitor
    {
        protected override Expression VisitCase(CaseExpression caseExpression)
        {
            Visit(caseExpression.Operand);
            foreach (var whenClause in caseExpression.WhenClauses)
            {
                Visit(whenClause.Test);
                Visit(whenClause.Result);
            }

            if (caseExpression.ElseResult != null)
            {
                Visit(caseExpression.ElseResult);
            }
            return caseExpression;
        }

        protected override Expression VisitColumn(ColumnExpression columnExpression)
        {
            return columnExpression;
        }

        protected override Expression VisitCrossApply(CrossApplyExpression crossApplyExpression)
        {
            Visit(crossApplyExpression.Table);

            return crossApplyExpression;
        }

        protected override Expression VisitCrossJoin(CrossJoinExpression crossJoinExpression)
        {
            Visit(crossJoinExpression.Table);
            return crossJoinExpression;
        }

        protected override Expression VisitExcept(ExceptExpression exceptExpression)
        {
            return exceptExpression;
        }

        protected override Expression VisitExists(ExistsExpression existsExpression)
        {
            Visit(existsExpression.Subquery);
            return existsExpression;
        }

        protected override Expression VisitFromSql(FromSqlExpression fromSqlExpression)
        {
            return fromSqlExpression;
        }

        protected override Expression VisitIn(InExpression inExpression)
        {
            Visit(inExpression.Item);

            return inExpression;
        }

        protected override Expression VisitInnerJoin(InnerJoinExpression innerJoinExpression)
        {
            Visit(innerJoinExpression.Table);
            Visit(innerJoinExpression.JoinPredicate);
            return innerJoinExpression;
        }

        protected override Expression VisitIntersect(IntersectExpression intersectExpression)
        {
            return intersectExpression;
        }

        protected override Expression VisitLeftJoin(LeftJoinExpression leftJoinExpression)
        {
            Visit(leftJoinExpression.Table);
            Visit(leftJoinExpression.JoinPredicate);
            return leftJoinExpression;
        }

        protected override Expression VisitLike(LikeExpression likeExpression)
        {
            Visit(likeExpression.Match);
            Visit(likeExpression.Pattern);

            return likeExpression; 
        }

        protected override Expression VisitOrdering(OrderingExpression orderingExpression)
        {
            Visit(orderingExpression.Expression);
            return orderingExpression;
        }

        protected override Expression VisitOuterApply(OuterApplyExpression outerApplyExpression)
        {
            Visit(outerApplyExpression.Table);
            return outerApplyExpression;
        }

        protected override Expression VisitProjection(ProjectionExpression projectionExpression)
        {
            Visit(projectionExpression.Expression);
            return projectionExpression;
        }

        protected override Expression VisitRowNumber(RowNumberExpression rowNumberExpression)
        {
            return rowNumberExpression;
        }

        protected override Expression VisitSelect(SelectExpression selectExpression)
        {
            if (selectExpression.Predicate != null)
            {
                Visit(selectExpression.Predicate);
            }

            Visit(selectExpression.Having);

            return selectExpression;
        }

        protected override Expression VisitSqlBinary(SqlBinaryExpression sqlBinaryExpression)
        {
            
            var left = Visit(sqlBinaryExpression.Left) as SqlExpression;
            var right = Visit(sqlBinaryExpression.Right) as SqlExpression;

            return sqlBinaryExpression.Update(left, right);
        }

        protected override Expression VisitSqlConstant(SqlConstantExpression sqlConstantExpression)
        {
            return sqlConstantExpression;
        }

        protected override Expression VisitSqlFragment(SqlFragmentExpression sqlFragmentExpression)
        {
            return sqlFragmentExpression;
        }

        protected override Expression VisitSqlFunction(SqlFunctionExpression sqlFunctionExpression)
        {
            if (sqlFunctionExpression.Instance != null)
            {
                Visit(sqlFunctionExpression.Instance);
            }

            foreach(var arg in sqlFunctionExpression.Arguments)
            {
                Visit(arg);
            }
            return sqlFunctionExpression;
        }

        protected override Expression VisitSqlParameter(SqlParameterExpression sqlParameterExpression)
        {
            return new SqlFragmentExpression(sqlParameterExpression.Name);
        }

        protected override Expression VisitSqlUnary(SqlUnaryExpression sqlCastExpression)
        {
            var op = Visit(sqlCastExpression.Operand) as SqlExpression;
            return sqlCastExpression.Update(op);
        }

        protected override Expression VisitSubSelect(ScalarSubqueryExpression scalarSubqueryExpression)
        {
            throw new NotImplementedException();
        }

        protected override Expression VisitTable(TableExpression tableExpression)
        {
            throw new NotImplementedException();
        }

        protected override Expression VisitUnion(UnionExpression unionExpression)
        {
            throw new NotImplementedException();
        }
    }
}
