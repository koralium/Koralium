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
using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Statements;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Koralium.SqlParser.Visitor
{
    internal class PrintVisitor : KoraliumSqlVisitor
    {
        readonly Stack<string> stack = new Stack<string>();

        private string VisitPop(in SqlNode sqlNode)
        {
            Visit(sqlNode);
            return stack.Pop();
        }

        private void Push(in string sql)
        {
            stack.Push(sql);
        }

        public string Print(in SqlNode node)
        {
            return VisitPop(node);
        }

        public override void VisitStatementList(StatementList statementList)
        {
            Push(string.Join(";\r\n", statementList.Statements.Select(x => VisitPop(x))));
        }

        public override void VisitBinaryExpression(BinaryExpression binaryExpression)
        {
            var left = VisitPop(binaryExpression.Left);
            var right = VisitPop(binaryExpression.Right);

            string op = null;
            switch (binaryExpression.Type)
            {
                case BinaryType.Add:
                    op = "+";
                    break;
                case BinaryType.BitwiseAnd:
                    op = "&";
                    break;
                case BinaryType.BitwiseOr:
                    op = "|";
                    break;
                case BinaryType.BitwiseXor:
                    op = "^";
                    break;
                case BinaryType.Divide:
                    op = "/";
                    break;
                case BinaryType.Modulo:
                    op = "%";
                    break;
                case BinaryType.Multiply:
                    op = "*";
                    break;
                case BinaryType.Subtract:
                    op = "-";
                    break;
                default:
                    throw new NotImplementedException();
            }
            Push($"{left} {op} {right}");
        }

        public override void VisitBooleanBinaryExpression(BooleanBinaryExpression booleanBinaryExpression)
        {
            var left = VisitPop(booleanBinaryExpression.Left);
            var right = VisitPop(booleanBinaryExpression.Right);

            string op = null;

            switch (booleanBinaryExpression.Type)
            {
                case BooleanBinaryType.AND:
                    op = "AND";
                    break;
                case BooleanBinaryType.OR:
                    op = "OR";
                    break;
                default:
                    throw new NotImplementedException();
            }

            Push($"({left}) {op} ({right})");
        }

        public override void VisitBooleanComparisonExpression(BooleanComparisonExpression booleanComparisonExpression)
        {
            var left = VisitPop(booleanComparisonExpression.Left);
            var right = VisitPop(booleanComparisonExpression.Right);

            string op = null;
            switch (booleanComparisonExpression.Type)
            {
                case BooleanComparisonType.Equals:
                    op = "=";
                    break;
                case BooleanComparisonType.GreaterThan:
                    op = ">";
                    break;
                case BooleanComparisonType.GreaterThanOrEqualTo:
                    op = ">=";
                    break;
                case BooleanComparisonType.LessThan:
                    op = "<";
                    break;
                case BooleanComparisonType.LessThanOrEqualTo:
                    op = "<=";
                    break;
                case BooleanComparisonType.NotEqualTo:
                    op = "!=";
                    break;
            }

            Push($"{left} {op} {right}");
        }

        public override void VisitBooleanIsNullExpression(BooleanIsNullExpression booleanIsNullExpression)
        {
            var left = VisitPop(booleanIsNullExpression.ScalarExpression);

            if (booleanIsNullExpression.IsNot)
            {
                Push($"{left} IS NOT NULL");
            }
            else
            {
                Push($"{left} IS NULL");
            }
        }

        public override void VisitBooleanLiteral(BooleanLiteral booleanLiteral)
        {
            if (booleanLiteral.Value)
            {
                Push($"true");
            }
            else
            {
                Push($"false");
            }
        }

        public override void VisitFromClause(FromClause fromClause)
        {
            var table = VisitPop(fromClause.TableReference);
            Push($"FROM {table}");
        }

        public override void VisitColumnReference(ColumnReference columnReference)
        {
            var column = string.Join(".", columnReference.Identifiers);
            Push(column);
        }

        public override void VisitFromTableReference(FromTableReference fromTableReference)
        {
            if (fromTableReference.Alias != null)
            {
                Push($"{fromTableReference.TableName} {fromTableReference.Alias}");
            }
            else
            {
                Push($"{fromTableReference.TableName}");
            }
        }

        public override void VisitFunctionCall(FunctionCall functionCall)
        {
            if (functionCall.Wildcard)
            {
                Push($"{functionCall.FunctionName}(*)");
                return;
            }
            List<string> parameters = new List<string>(functionCall.Parameters.Count);
            foreach(var parameter in functionCall.Parameters)
            {
                parameters.Add(VisitPop(parameter));
            }

            Push($"{functionCall.FunctionName}({string.Join(", ", parameters)})");
        }

        public override void VisitIntegerLiteral(IntegerLiteral integerLiteral)
        {
            Push(integerLiteral.Value.ToString());
        }

        public override void VisitNullLiteral(NullLiteral nullLiteral)
        {
            Push("NULL");
        }

        public override void VisitNumericLiteral(NumericLiteral numericLiteral)
        {
            Push(numericLiteral.Value.ToString(CultureInfo.InvariantCulture));
        }

        public override void VisitStringLiteral(StringLiteral stringLiteral)
        {
            Push($"'{stringLiteral.Value}'");
        }

        public override void VisitWhereClause(WhereClause whereClause)
        {
            var predicate = VisitPop(whereClause.Expression);
            Push($"WHERE {predicate}");
        }

        public override void VisitGroupByClause(GroupByClause groupByClause)
        {
            var groupByString = string.Join(", ", groupByClause.Groups.Select(x => VisitPop(x)));

            Push($"GROUP BY {groupByString}");
        }

        public override void VisitExpressionGroup(ExpressionGroup expressionGroup)
        {
            //Just pass the string to the group by clause
            Visit(expressionGroup.Expression);
        }

        public override void VisitSelectStatementGroup(SelectStatementGroup selectStatementGroup)
        {
            var selectString = VisitPop(selectStatementGroup.SelectStatement);
            Push($"({selectString})");
        }

        public override void VisitHavingClause(HavingClause havingClause)
        {
            var having = VisitPop(havingClause.Expression);
            Push($"HAVING {having}");
        }

        public override void VisitInExpression(InExpression inExpression)
        {
            var expression = VisitPop(inExpression.Expression);
            var values = string.Join(", ", inExpression.Values.Select(x => VisitPop(x)));

            if (inExpression.Not)
            {
                Push($"{expression} NOT IN ({values})");
            }
            else
            {
                Push($"{expression} IN ({values})");
            }
        }

        public override void VisitLikeExpression(LikeExpression likeExpression)
        {
            var left = VisitPop(likeExpression.Left);
            var right = VisitPop(likeExpression.Right);

            if (likeExpression.Not)
            {
                Push($"{left} NOT LIKE {right}");
            }
            else
            {
                Push($"{left} LIKE {right}");
            }
        }

        public override void VisitOffsetLimitClause(OffsetLimitClause offsetLimitClause)
        {
            string sql = "";
            if(offsetLimitClause.Limit != null)
            {
                sql += $"LIMIT {VisitPop(offsetLimitClause.Limit)}";
            }
            if(offsetLimitClause.Offset != null)
            {
                if(sql != "")
                {
                    sql += " ";
                }
                sql += $"OFFSET {VisitPop(offsetLimitClause.Offset)}";
            }
            Push(sql);
        }

        public override void VisitOrderByClause(OrderByClause orderByClause)
        {
            var orderByString = string.Join(", ", orderByClause.OrderExpressions.Select(x => VisitPop(x)));
            Push($"ORDER BY {orderByString}");
        }

        public override void VisitOrderBySubquery(OrderBySubquery orderBySubquery)
        {
            var select = VisitPop(orderBySubquery.SelectStatement);
            if (orderBySubquery.Ascending)
            {
                Push($"({select}) ASC");
            }
            else
            {
                Push($"({select}) DESC");
            }
        }

        public override void VisitOrderExpression(OrderExpression orderExpression)
        {
            var expression = VisitPop(orderExpression.Expression);

            if (orderExpression.Ascending)
            {
                Push($"{expression} ASC");
            }
            else
            {
                Push($"{expression} DESC");
            }
        }

        public override void VisitSelectNullExpression(SelectNullExpression selectNullExpression)
        {
            if(selectNullExpression.Alias != null)
            {
                Push($"NULL AS {selectNullExpression.Alias}");
            }
            else
            {
                Push("NULL");
            }
        }

        public override void VisitSelectScalarExpression(SelectScalarExpression selectScalarExpression)
        {
            var expression = VisitPop(selectScalarExpression.Expression);

            if(selectScalarExpression.Alias != null)
            {
                Push($"{expression} AS {selectScalarExpression.Alias}");
            }
            else
            {
                Push(expression);
            }
        }

        public override void VisitSelectStarExpression(SelectStarExpression selectStarExpression)
        {
            Push("*");
        }

        public override void VisitSelectStatement(SelectStatement selectStatement)
        {
            List<string> ops = new List<string>();

            if (selectStatement.Distinct)
            {
                ops.Add($"SELECT DISTINCT {string.Join(", ", selectStatement.SelectElements.Select(x => VisitPop(x)))}");
            }
            else
            {
                ops.Add($"SELECT {string.Join(", ", selectStatement.SelectElements.Select(x => VisitPop(x)))}");
            }

            if(selectStatement.FromClause != null)
            {
                ops.Add(VisitPop(selectStatement.FromClause));
            }
            if (selectStatement.WhereClause != null)
            {
                ops.Add(VisitPop(selectStatement.WhereClause));
            }
            if(selectStatement.GroupByClause != null)
            {
                ops.Add(VisitPop(selectStatement.GroupByClause));
            }
            if(selectStatement.HavingClause != null)
            {
                ops.Add(VisitPop(selectStatement.HavingClause));
            }
            if(selectStatement.OrderByClause != null)
            {
                ops.Add(VisitPop(selectStatement.OrderByClause));
            }
            if(selectStatement.OffsetLimitClause != null)
            {
                ops.Add(VisitPop(selectStatement.OffsetLimitClause));
            }

            Push(string.Join(" ", ops));
        }

        public override void VisitSetVariableStatement(SetVariableStatement setVariableStatement)
        {
            var variable = VisitPop(setVariableStatement.VariableReference);
            var value = VisitPop(setVariableStatement.ScalarExpression);

            Push($"SET {variable} = {value}");
        }

        public override void VisitSubquery(Subquery subquery)
        {
            var select = VisitPop(subquery.SelectStatement);
            
            if(subquery.Alias != null)
            {
                Push($"({select}) {subquery.Alias}");
            }
            else
            {
                Push($"({select})");
            }
        }

        public override void VisitVariableReference(VariableReference variableReference)
        {
            Push(variableReference.Name);
        }

        public override void VisitSearchExpression(SearchExpression searchExpression)
        {
            var value = VisitPop(searchExpression.Value);

            if (searchExpression.AllColumns)
            {
                Push($"CONTAINS(*, {value})");
            }
            else
            {
                if(searchExpression.Columns.Count == 1)
                {
                    var column = VisitPop(searchExpression.Columns.First());
                    Push($"CONTAINS({column}, {value})");
                }
                else
                {
                    var columns = string.Join(", ", searchExpression.Columns.Select(x => VisitPop(x)));
                    Push($"CONTAINS(({columns}), {value})");
                }
            }
        }

        public override void VisitBase64Literal(Base64Literal base64Literal)
        {
            Push($"b64'{base64Literal.Value}'");
        }

        public override void VisitCastExpression(CastExpression castExpression)
        {
            var text = VisitPop(castExpression.ScalarExpression);
            Push($"CAST({text} AS {castExpression.ToType})");
        }

        public override void VisitNotExpression(NotExpression notExpression)
        {
            var text = VisitPop(notExpression.BooleanExpression);
            Push($"NOT ({text})");
        }

        public override void VisitBetweenExpression(BetweenExpression betweenExpression)
        {
            var reference = VisitPop(betweenExpression.Expression);
            var from = VisitPop(betweenExpression.From);
            var to = VisitPop(betweenExpression.To);
            Push($"{reference} BETWEEN {from} AND {to}");
        }

        public override void VisitLambdaExpression(LambdaExpression lambdaExpression)
        {
            var expr = VisitPop(lambdaExpression.Expression);

            string parameters;
            if (lambdaExpression.Parameters.Count == 1)
            {
                parameters = lambdaExpression.Parameters.First();
            }
            else
            {
                parameters = $"({string.Join(", ", lambdaExpression.Parameters)})";
            }
            Push($"{parameters} -> {expr}");
        }

        public override void VisitBooleanScalarExpression(BooleanScalarExpression booleanScalarExpression)
        {
            Visit(booleanScalarExpression.ScalarExpression);
        }
    }
}
