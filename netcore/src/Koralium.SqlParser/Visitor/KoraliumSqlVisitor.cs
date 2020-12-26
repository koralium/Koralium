using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Statements;
using System.Collections.Generic;

namespace Koralium.SqlParser.Visitor
{
    public class KoraliumSqlVisitor
    {
        public virtual void Visit(SqlNode sqlNode)
        {
            if (sqlNode == null)
                return;

            sqlNode.Accept(this);
        }

        public virtual void Visit(IEnumerable<SqlNode> sqlNodes)
        {
            if (sqlNodes == null)
                return;

            foreach(var sqlNode in sqlNodes)
            {
                sqlNode.Accept(this);
            }
        }

        public virtual void VisitSelectStatement(SelectStatement selectStatement)
        {
            Visit(selectStatement.FromClause);
            Visit(selectStatement.GroupByClause);
            Visit(selectStatement.HavingClause);
            Visit(selectStatement.OffsetLimitClause);
            Visit(selectStatement.OrderByClause);
            Visit(selectStatement.SelectElements);
            Visit(selectStatement.WhereClause);
            //DONE
        }

        public virtual void VisitFromClause(FromClause fromClause)
        {
            Visit(fromClause.TableReference);
            //DONE
        }

        public virtual void VisitFromTableReference(FromTableReference fromTableReference)
        {
            //NOP   
        }

        public virtual void VisitSubquery(Subquery subquery)
        {
            Visit(subquery.SelectStatement);
            //DONE
        }

        public virtual void VisitGroupByClause(GroupByClause groupByClause)
        {
            Visit(groupByClause.Groups);
            //DONE
        }

        public virtual void VisitExpressionGroup(ExpressionGroup expressionGroup)
        {
            Visit(expressionGroup.Expression);
            //DONE
        }

        public virtual void VisitSelectStatementGroup(SelectStatementGroup selectStatementGroup)
        {
            Visit(selectStatementGroup.SelectStatement);
            //DONE
        }

        public virtual void VisitBooleanBinaryExpression(BooleanBinaryExpression booleanBinaryExpression)
        {
            Visit(booleanBinaryExpression.Left);
            Visit(booleanBinaryExpression.Right);
            //DONE
        }

        public virtual void VisitSelectScalarExpression(SelectScalarExpression selectScalarExpression)
        {
            Visit(selectScalarExpression.Expression);
            //DONE
        }

        public virtual void VisitSelectStarExpression(SelectStarExpression selectStarExpression)
        {
            //NOP
        }

        public virtual void VisitSelectNullExpression(SelectNullExpression selectNullExpression)
        {
            //NOP
        }

        public virtual void VisitNumericLiteral(NumericLiteral numericLiteral)
        {
            //NOP
        }

        public virtual void VisitLikeExpression(LikeExpression likeExpression)
        {
            Visit(likeExpression.Left);
            Visit(likeExpression.Right);
            //DONE
        }

        public virtual void VisitIntegerLiteral(IntegerLiteral integerLiteral)
        {
            //NOP
        }

        public virtual void VisitInExpression(InExpression inExpression)
        {
            Visit(inExpression.Expression);
            Visit(inExpression.Values);
            //DONE
        }

        public virtual void VisitStringLiteral(StringLiteral stringLiteral)
        {
            //NOP
        }

        public virtual void VisitFunctionCall(FunctionCall functionCall)
        {
            Visit(functionCall.Parameters);
            //DONE
        }

        public virtual void VisitColumnReference(ColumnReference columnReference)
        {
            //NOP
        }

        public virtual void VisitBooleanComparisonExpression(BooleanComparisonExpression booleanComparisonExpression)
        {
            Visit(booleanComparisonExpression.Left);
            Visit(booleanComparisonExpression.Right);
            //DONE
        }

        public virtual void VisitBinaryExpression(BinaryExpression binaryExpression)
        {
            Visit(binaryExpression.Left);
            Visit(binaryExpression.Right);
            //DONE
        }

        public virtual void VisitHavingClause(HavingClause havingClause)
        {
            Visit(havingClause.Expression);
            //DONE
        }

        public virtual void VisitOffsetLimitClause(OffsetLimitClause offsetLimitClause)
        {
            Visit(offsetLimitClause.Limit);
            Visit(offsetLimitClause.Offset);
            //DONE
        }

        public virtual void VisitOrderExpression(OrderExpression orderExpression)
        {
            Visit(orderExpression.Expression);
            //DONE
        }

        public virtual void VisitOrderByClause(OrderByClause orderByClause)
        {
            Visit(orderByClause.OrderExpressions);
            //DONE
        }

        public virtual void VisitWhereClause(WhereClause whereClause)
        {
            Visit(whereClause.Expression);
            //DONE
        }

        public virtual void VisitSetVariableStatement(SetVariableStatement setVariableStatement)
        {
            Visit(setVariableStatement.VariableReference);
            Visit(setVariableStatement.ScalarExpression);
            //DONE
        }

        public virtual void VisitVariableReference(VariableReference variableReference)
        {
            //NOP
        }

        public virtual void VisitSearchExpression(SearchExpression searchExpression)
        {
            Visit(searchExpression.Columns);
            Visit(searchExpression.Value);
            //DONE
        }

        public virtual void VisitBooleanIsNullExpression(BooleanIsNullExpression booleanIsNullExpression)
        {
            Visit(booleanIsNullExpression.ScalarExpression);
            //DONE
        }

        public virtual void VisitStatementList(StatementList statementList)
        {
            Visit(statementList.Statements);
            //DONE
        }

        public virtual void VisitOrderBySubquery(OrderBySubquery orderBySubquery)
        {
            Visit(orderBySubquery.SelectStatement);
            //DONE
        }

        public virtual void VisitNullLiteral(NullLiteral nullLiteral)
        {
            //NOP
        }

        public virtual void VisitBooleanLiteral(BooleanLiteral booleanLiteral)
        {
            //NOP
        }

        public virtual void VisitBase64Literal(Base64Literal base64Literal)
        {
            //NOP
        }
    }
}
