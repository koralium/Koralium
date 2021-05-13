using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Query.SqlExpressions
{
    public class SqlLambdaExpression : SqlExpression
    {
        public SqlExpression LambdaParameter { get; }

        public SqlExpression Inner { get; }

        public SqlLambdaExpression(SqlExpression parameter, SqlExpression inner, Type type, RelationalTypeMapping typeMapping) : base(type, typeMapping)
        {
            LambdaParameter = parameter;
            Inner = inner;
        }

        public override void Print(ExpressionPrinter expressionPrinter)
        {
            expressionPrinter.Visit(LambdaParameter);
            expressionPrinter.Append(" -> ");
            expressionPrinter.Visit(Inner);
        }

        protected override Expression VisitChildren(ExpressionVisitor visitor)
        {
            var parameter = (SqlExpression)visitor.Visit(LambdaParameter);
            var inner = (SqlExpression)visitor.Visit(Inner);

            return this.Update(parameter, inner);
        }

        public virtual SqlLambdaExpression Update(SqlExpression parameter, SqlExpression inner)
        {
            return parameter != LambdaParameter || inner != Inner
                ? new SqlLambdaExpression(parameter, inner, Type, TypeMapping)
                : this;
        }
    }
}
