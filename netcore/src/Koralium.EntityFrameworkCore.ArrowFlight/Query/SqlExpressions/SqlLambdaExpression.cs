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
        public SqlExpression Parameter { get; }

        public SqlExpression Inner { get; }

        public SqlLambdaExpression(SqlExpression parameter, SqlExpression inner, Type type, RelationalTypeMapping typeMapping) : base(type, typeMapping)
        {
            Parameter = parameter;
            Inner = inner;
        }

        public SqlLambdaExpression(Type type, RelationalTypeMapping typeMapping) : base(type, typeMapping)
        {
        }

        public override void Print(ExpressionPrinter expressionPrinter)
        {
            expressionPrinter.Visit(Parameter);
            expressionPrinter.Append(" -> ");
            expressionPrinter.Visit(Inner);
        }

        protected override Expression VisitChildren(ExpressionVisitor visitor)
        {
            var parameter = (SqlExpression)visitor.Visit(Parameter);
            var inner = (SqlExpression)visitor.Visit(Inner);

            return this.Update(parameter, inner);
        }

        public virtual SqlLambdaExpression Update(SqlExpression parameter, SqlExpression inner)
        {
            return parameter != Parameter || inner != Inner
                ? new SqlLambdaExpression(parameter, inner, Type, TypeMapping)
                : this;
        }
    }
}
