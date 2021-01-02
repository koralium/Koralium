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
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Exceptions;
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

namespace Koralium.SqlParser.ANTLR
{
    public class AntlrVisitor : KoraliumParserBaseVisitor<object>
    {
        public override object VisitStatements_list([NotNull] KoraliumParser.Statements_listContext context)
        {
            var statementNodes = context.sql_statement();

            List<Statement> statements = new List<Statement>();

            foreach(var statementNode in statementNodes)
            {
                var statement = Visit(statementNode) as Statement;

                if(statement == null)
                {
                    throw new SqlParserException("Unexpected statement");
                }
                statements.Add(statement);
            }

            return statements;
        }

        private void HandleSelectStatementSelectExpressions(SelectStatement selectStatement, KoraliumParser.Select_statementContext context)
        {
            var selectExpressions = context.select_expression();

            if (selectExpressions != null)
            {
                foreach (var selectExpressionNode in selectExpressions)
                {
                    var selectExpression = Visit(selectExpressionNode) as SelectExpression;
                    if (selectExpression == null)
                    {
                        throw new SqlParserException("Could not parse select statement");
                    }
                    selectStatement.SelectElements.Add(selectExpression);
                }
            }
        }

        private void HandleSelectStatementFromClause(SelectStatement selectStatement, KoraliumParser.Select_statementContext context)
        {
            var fromClauseNode = context.from_clause();

            if (fromClauseNode != null)
            {
                var fromClause = Visit(fromClauseNode) as FromClause;

                if (fromClause == null)
                {
                    throw new SqlParserException("Could not parse from clause");
                }
                selectStatement.FromClause = fromClause;
            }
        }

        private void HandleSelectStatementWhereClause(SelectStatement selectStatement, KoraliumParser.Select_statementContext context)
        {
            var whereClauseNode = context.where_clause();

            if (whereClauseNode != null)
            {
                var whereClause = Visit(whereClauseNode) as WhereClause;

                if (whereClause == null)
                {
                    throw new SqlParserException("Could not parse where clause");
                }

                selectStatement.WhereClause = whereClause;
            }
        }

        private void HandleSelectStatementGroupByClause(SelectStatement selectStatement, KoraliumParser.Select_statementContext context)
        {
            var groupByNode = context.groupby_clause();

            if (groupByNode != null)
            {
                var groupByClause = Visit(groupByNode) as GroupByClause;

                if (groupByClause == null)
                {
                    throw new SqlParserException("Could not parse group by clause");
                }
                selectStatement.GroupByClause = groupByClause;
            }
        }

        private void HandleSelectStatementHavingClause(SelectStatement selectStatement, KoraliumParser.Select_statementContext context)
        {
            var havingNode = context.having_clause();

            if (havingNode != null)
            {
                var havingClause = Visit(havingNode) as HavingClause;

                if (havingClause == null)
                {
                    throw new SqlParserException("Could not parse having clause");
                }
                selectStatement.HavingClause = havingClause;
            }
        }

        private void HandleSelectStatementOrderByClause(SelectStatement selectStatement, KoraliumParser.Select_statementContext context)
        {
            var orderByNode = context.order_by_clause();

            if (orderByNode != null)
            {
                var orderByClause = Visit(orderByNode) as OrderByClause;

                if (orderByClause == null)
                {
                    throw new SqlParserException("Could not parse order by clause");
                }
                selectStatement.OrderByClause = orderByClause;
            }
        }

        private void HandleSelectStatementLimitOffset(SelectStatement selectStatement, KoraliumParser.Select_statementContext context)
        {
            if (context.limit != null || context.offset != null)
            {
                OffsetLimitClause offsetLimitClause = new OffsetLimitClause();
                if (context.limit != null)
                {
                    var limit = Visit(context.limit) as ScalarExpression;

                    if (limit == null)
                    {
                        throw new SqlParserException("Could not parse limit");
                    }
                    offsetLimitClause.Limit = limit;
                }
                if (context.offset != null)
                {
                    var offset = Visit(context.offset) as ScalarExpression;

                    if (offset == null)
                    {
                        throw new SqlParserException("Could not parse offset");
                    }
                    offsetLimitClause.Offset = offset;
                }
                selectStatement.OffsetLimitClause = offsetLimitClause;
            }
        }

        private void HandleSelectStatementDistinct(SelectStatement selectStatement, KoraliumParser.Select_statementContext context)
        {
            if (context.DISTINCT() != null)
            {
                selectStatement.Distinct = true;
            }
        }

        public override object VisitSelect_statement([NotNull] KoraliumParser.Select_statementContext context)
        {
            SelectStatement selectStatement = new SelectStatement();

            HandleSelectStatementSelectExpressions(selectStatement, context);
            HandleSelectStatementFromClause(selectStatement, context);
            HandleSelectStatementWhereClause(selectStatement, context);
            HandleSelectStatementGroupByClause(selectStatement, context);
            HandleSelectStatementHavingClause(selectStatement, context);
            HandleSelectStatementOrderByClause(selectStatement, context);
            HandleSelectStatementLimitOffset(selectStatement, context);
            HandleSelectStatementDistinct(selectStatement, context);
            
            return selectStatement;
        }

        public override object VisitFrom_clause([NotNull] KoraliumParser.From_clauseContext context)
        {
            var tableNameNode = context.table_name();

            string tableAlias = null;

            var tableAliasNode = context.table_alias();
            if(tableAliasNode != null)
            {
                tableAlias = tableAliasNode.GetText().Trim('"');
            }

            if(tableNameNode != null)
            {
                return new FromClause()
                {
                    TableReference = new FromTableReference()
                    {
                        TableName = tableNameNode.GetText().Trim('"'),
                        Alias = tableAlias
                    }
                };
            }


            var subqueryNode = context.subquery();

            if(subqueryNode != null)
            {
                var subquery = Visit(subqueryNode) as Subquery;

                return new FromClause()
                {
                    TableReference = subquery
                };
            }

            throw new NotImplementedException();
        }

        public override object VisitSelect_expression([NotNull] KoraliumParser.Select_expressionContext context)
        {
            if(context.STAR() != null)
            {
                return new SelectStarExpression();
            }

            if(context.NULL() != null)
            {
                return new SelectNullExpression();
            }

            var scalarExpressionNode = context.scalar_expression();

            var scalarExpression = Visit(scalarExpressionNode) as ScalarExpression;

            if(scalarExpression == null)
            {
                throw new SqlParserException("Could not parse scalar expression");
            }

            string alias = null;
            var aliasNode = context.column_alias();

            if(aliasNode != null)
            {
                alias = aliasNode.GetText();
            }

            return new SelectScalarExpression()
            {
                Alias = alias,
                Expression = scalarExpression
            };
        }

        private object VisitCast([NotNull] KoraliumParser.Scalar_expressionContext context)
        {
            var innerScalar = Visit(context.casted) as ScalarExpression;

            var toType = context.castedidentifier.Text.ToLower();

            return new CastExpression()
            {
                ScalarExpression = innerScalar,
                ToType = toType
            };
        }

        public override object VisitScalar_expression([NotNull] KoraliumParser.Scalar_expressionContext context)
        {
            if(context.casted != null)
            {
                return VisitCast(context);
            }

            var columnReferenceNode = context.column_reference();

            if(columnReferenceNode != null)
            {
                return Visit(columnReferenceNode) as ScalarExpression;
            }

            var literalNode = context.literal_value();

            if(literalNode != null)
            {
                return Visit(literalNode) as ScalarExpression;
            }

            var functionCallNode = context.function_call();

            if(functionCallNode != null)
            {
                return Visit(functionCallNode) as ScalarExpression;
            }

            var operationTypeNode = context.binary_operation_type();

            if(operationTypeNode != null)
            {
                var binaryOperationType = operationTypeNode.GetText();

                BinaryType binaryType = BinaryType.Add;
                switch (binaryOperationType)
                {
                    case "+":
                        binaryType = BinaryType.Add;
                        break;
                    case "-":
                        binaryType = BinaryType.Subtract;
                        break;
                    case "*":
                        binaryType = BinaryType.Multiply;
                        break;
                    case "/":
                        binaryType = BinaryType.Divide;
                        break;
                    case "%":
                        binaryType = BinaryType.Modulo;
                        break;
                    case "&":
                        binaryType = BinaryType.BitwiseAnd;
                        break;
                    case "|":
                        binaryType = BinaryType.BitwiseOr;
                        break;
                    case "^":
                        binaryType = BinaryType.BitwiseXor;
                        break;
                }
                return new BinaryExpression()
                {
                    Left = Visit(context.left) as ScalarExpression,
                    Right = Visit(context.right) as ScalarExpression,
                    Type = binaryType
                };
            }

            var variableReferenceNode = context.variable_reference();

            if(variableReferenceNode != null)
            {
                return Visit(variableReferenceNode) as VariableReference;
            }

            throw new NotImplementedException();
        }

        public override object VisitLiteral_value([NotNull] KoraliumParser.Literal_valueContext context)
        {
            if (context.NULL() != null)
            {
                return new NullLiteral();
            }

            var value = context.GetText();
            //Its a string literal
            if (context.STRING_LITERAL() != null)
            {
                value = value.Trim('\'');
                return new StringLiteral()
                {
                    Value = value
                };
            }
            if (context.NUMERIC_LITERAL() != null)
            {
                if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var val))
                {
                    if ((val % 1) == 0)
                    {
                        return new IntegerLiteral()
                        {
                            Value = (long)val
                        };
                    }
                    else
                    {
                        return new NumericLiteral()
                        {
                            Value = val
                        };
                    }
                }
                else
                {
                    throw new SqlParserException($"Unmatched literal: {value}");
                }
            }

            if (context.TRUE() != null)
            {
                return new BooleanLiteral()
                {
                    Value = true
                };
            }

            if(context.FALSE() != null)
            {
                return new BooleanLiteral()
                {
                    Value = false
                };
            }

            throw new NotImplementedException();
        }

        public override object VisitColumn_reference([NotNull] KoraliumParser.Column_referenceContext context)
        {
            var columnName = context.column_name();

            if (columnName != null)
            {
                var identifiers = columnName.Select(x => x.GetText().Trim('"')).ToList();

                return new ColumnReference()
                {
                    Identifiers = identifiers
                };
            }
            throw new NotImplementedException();
        }

        public override object VisitWhere_clause([NotNull] KoraliumParser.Where_clauseContext context)
        {
            WhereClause whereClause = new WhereClause();

            var booleanExpression = context.boolean_expression();

            if(booleanExpression != null)
            {
                whereClause.Expression = Visit(booleanExpression) as BooleanExpression;
            }
            else
            {
                throw new SqlParserException("Could not parse boolean expression");
            }

            return whereClause;
        }

        private BooleanBinaryType ParseBinaryType(KoraliumParser.Boolean_binary_typeContext type)
        {
            var typeText = type.GetText().ToLower();

            switch (typeText)
            {
                case "and":
                    return BooleanBinaryType.AND;
                case "or":
                    return BooleanBinaryType.OR;
            }

            throw new SqlParserException($"Unexpected boolean binary type '{typeText}'");
        }

        public override object VisitBoolean_expression([NotNull] KoraliumParser.Boolean_expressionContext context)
        {
            if(context.exclamationexpr != null || context.notexpr != null)
            {
                KoraliumParser.Boolean_expressionContext expr = context.exclamationexpr ?? context.notexpr;

                var booleanExpression = Visit(expr) as BooleanExpression;
                return new NotExpression()
                {
                    BooleanExpression = booleanExpression
                };
            }

            //Check if there is an expression inside 
            if(context.inner != null)
            {
                return Visit(context.inner);
            }

            var booleanBinaryTypeNode = context.boolean_binary_type();

            if(booleanBinaryTypeNode != null)
            {
                return new BooleanBinaryExpression()
                {
                    Left = Visit(context.left) as BooleanExpression,
                    Right = Visit(context.right) as BooleanExpression,
                    Type = ParseBinaryType(booleanBinaryTypeNode)
                };
            }

            var predicateNode = context.predicate();

            if(predicateNode != null)
            {
                return Visit(predicateNode) as BooleanExpression;
            }

            throw new NotImplementedException();
        }

        public override object VisitFunction_call([NotNull] KoraliumParser.Function_callContext context)
        {
            var parameterNodes = context.scalar_expression();

            var functionNameNode = context.function_name();
            if (functionNameNode != null)
            {
                FunctionCall functionCall = new FunctionCall()
                {
                    FunctionName = functionNameNode.GetText().ToLower()
                };

                if(context.STAR() != null)
                {
                    functionCall.Wildcard = true;
                }

                foreach (var functionParameterExpression in parameterNodes)
                {
                    var result = Visit(functionParameterExpression);

                    if (result is ScalarExpression scalarExpression)
                    {
                        functionCall.Parameters.Add(scalarExpression);
                    }
                    else
                    {
                        throw new SqlParserException("Could not parse scalar expression");
                    }
                }
                return functionCall;
            }
            throw new SqlParserException("Empty function name");
        }

        public override object VisitBoolean_comparison_expression([NotNull] KoraliumParser.Boolean_comparison_expressionContext context)
        {
            var typeNode = context.boolean_comparison_type();

            if(typeNode == null)
            {
                throw new SqlParserException("Boolean comparison without any type");
            }

            var comparisionOperation = typeNode.GetText();
            BooleanComparisonType booleanComparisonType = BooleanComparisonType.Equals;
            switch (comparisionOperation)
            {
                case "=":
                case "==":
                    booleanComparisonType = BooleanComparisonType.Equals;
                    break;
                case ">":
                    booleanComparisonType = BooleanComparisonType.GreaterThan;
                    break;
                case "<":
                    booleanComparisonType = BooleanComparisonType.LessThan;
                    break;
                case ">=":
                case "!<":
                    booleanComparisonType = BooleanComparisonType.GreaterThanOrEqualTo;
                    break;
                case "!=":
                case "<>":
                    booleanComparisonType = BooleanComparisonType.NotEqualTo;
                    break;
                case "<=":
                case "!>":
                    booleanComparisonType = BooleanComparisonType.LessThanOrEqualTo;
                    break;
            }

            return new BooleanComparisonExpression()
            {
                Left = Visit(context.left) as ScalarExpression,
                Right = Visit(context.right) as ScalarExpression,
                Type = booleanComparisonType
            };
        }

        public override object VisitGroupby_clause([NotNull] KoraliumParser.Groupby_clauseContext context)
        {
            GroupByClause groupByClause = new GroupByClause();

            var elements = context.groupby_element();

            foreach(var element in elements)
            {
                var groupElement = Visit(element) as Group;

                if(groupElement == null)
                {
                    throw new SqlParserException("Could not parse group by group");
                }

                groupByClause.Groups.Add(groupElement);
            }

            return groupByClause;
        }


        public override object VisitGroupby_element([NotNull] KoraliumParser.Groupby_elementContext context)
        {
            //Scalar expression

            var scalar = context.scalar_expression();

            if (scalar != null)
            {
                var scalarExpression = Visit(context.scalar_expression()) as ScalarExpression;

                if (scalarExpression == null)
                {
                    throw new SqlParserException("Could not parse scalar expression");
                }

                return new ExpressionGroup()
                {
                    Expression = scalarExpression
                };
            }

            //SUB QUERY
            var subqueryNode = context.group_subquery();

            if(subqueryNode != null)
            {
                var subquery = Visit(subqueryNode) as Group;

                if(subquery == null)
                {
                    throw new SqlParserException("Could not parse group by sub query");
                }

                return subquery;
            }

            throw new NotImplementedException();
        }

        public override object VisitSubquery([NotNull] KoraliumParser.SubqueryContext context)
        {
            string alias = null;
            var aliasNode = context.table_alias();

            if(aliasNode != null)
            {
                alias = aliasNode.GetText();
            }

            var selectStatement = Visit(context.select_statement()) as SelectStatement;
            
            if(selectStatement == null)
            {
                throw new SqlParserException("Could not parse select statement");
            }

            return new Subquery()
            {
                Alias = alias,
                SelectStatement = selectStatement
            };
        }

        public override object VisitGroup_subquery([NotNull] KoraliumParser.Group_subqueryContext context)
        {
            var selectStatement = Visit(context.select_statement()) as SelectStatement;

            if (selectStatement == null)
            {
                throw new SqlParserException("Could not parse select statement");
            }

            return new SelectStatementGroup()
            {
                SelectStatement = selectStatement
            };
        }

        public override object VisitOrderby_subquery([NotNull] KoraliumParser.Orderby_subqueryContext context)
        {
            var selectStatement = Visit(context.select_statement()) as SelectStatement;

            if (selectStatement == null)
            {
                throw new SqlParserException("Could not parse select statement");
            }

            return new OrderBySubquery()
            {
                SelectStatement = selectStatement
            };
        }

        public override object VisitHaving_clause([NotNull] KoraliumParser.Having_clauseContext context)
        {
            var booleanExpr = context.boolean_expression();

            if(booleanExpr != null)
            {
                var expression = Visit(booleanExpr) as BooleanExpression;

                return new HavingClause()
                {
                    Expression = expression
                };
            }

            throw new SqlParserException("Missing expression in having");
        }

        public override object VisitIn_expression([NotNull] KoraliumParser.In_expressionContext context)
        {
            if(context.element != null)
            {
                var left = Visit(context.element) as ScalarExpression;

                if(left == null)
                {
                    throw new SqlParserException("Could not find a scalar expression in left side of 'IN'");
                }

                InExpression inExpression = new InExpression()
                {
                    Expression = left,
                    Not = context.NOT() != null
                };

                var scalarExpressionNodes = context.scalar_expression();

                foreach(var node in scalarExpressionNodes)
                {
                    var scalarExpression = Visit(node) as ScalarExpression;

                    if(scalarExpression == null)
                    {
                        throw new SqlParserException("Could not find a scalar expression in 'IN' array");
                    }
                    inExpression.Values.Add(scalarExpression);
                }

                return inExpression;
            }

            throw new NotImplementedException();
        }

        public override object VisitLike_expression([NotNull] KoraliumParser.Like_expressionContext context)
        {
            if(context.element != null)
            {
                var left = Visit(context.element) as ScalarExpression;

                if (left == null)
                {
                    throw new SqlParserException("Could not find a scalar expression in left side of 'LIKE'");
                }

                var right = Visit(context.right) as ScalarExpression;

                if (right == null)
                {
                    throw new SqlParserException("Could not find a scalar expression in right side of 'LIKE'");
                }

                return new LikeExpression()
                {
                    Left = left,
                    Right = right,
                    Not = context.NOT() != null
                };
            }

            throw new NotImplementedException();
        }

        public override object VisitOrder_by_clause([NotNull] KoraliumParser.Order_by_clauseContext context)
        {
            var orderByElements = context.order_by_element();

            if(orderByElements == null || orderByElements.Length == 0)
            {
                throw new SqlParserException("Order by without any elements");
            }
            OrderByClause orderByClause = new OrderByClause();
            foreach(var orderByElementNode in orderByElements)
            {
                var orderExpression = Visit(orderByElementNode) as OrderElement;

                orderByClause.OrderExpressions.Add(orderExpression);
            }
            return orderByClause;
        }

        public override object VisitOrder_by_element([NotNull] KoraliumParser.Order_by_elementContext context)
        {
            var scalarExpressionNode = context.scalar;

            if(scalarExpressionNode != null)
            {
                var scalarExpression = Visit(scalarExpressionNode) as ScalarExpression;

                if(scalarExpression == null)
                {
                    throw new SqlParserException("Could not find a scalar expression in order by element");
                }
                bool ascending = true;
                if(context.order != null)
                {
                    switch (context.order.Text.ToLower())
                    {
                        case "asc":
                            ascending = true;
                            break;
                        case "desc":
                            ascending = false;
                            break;
                    }
                }

                return new OrderExpression()
                {
                    Ascending = ascending,
                    Expression = scalarExpression
                };
            }

            if(context.query != null)
            {
                return Visit(context.query);
            }

            return base.VisitOrder_by_element(context);
        }

        public override object VisitSet_variable_statement([NotNull] KoraliumParser.Set_variable_statementContext context)
        {
            var variableReference = Visit(context.variable_reference()) as VariableReference;
            
            if(variableReference == null)
            {
                throw new SqlParserException("Could not parse variable reference");
            }

            ScalarExpression scalarExpression = null;
            if(context.b64 != null)
            {
                scalarExpression = new Base64Literal()
                {
                    Value = context.b64.Text.Substring(4, context.b64.Text.Length - 5)
                };
            }
            else
            {
                scalarExpression = Visit(context.scalar_expression()) as ScalarExpression;
            }

            if(scalarExpression == null)
            {
                throw new SqlParserException("Could not parse scalar expression");
            }

            return new SetVariableStatement()
            {
                VariableReference = variableReference,
                ScalarExpression = scalarExpression
            };
        }

        public override object VisitVariable_reference([NotNull] KoraliumParser.Variable_referenceContext context)
        {
            if (context.variableName == null && context.identifier == null)
            {
                throw new SqlParserException("Could not get variable name");
            }

            return new VariableReference()
            {
                Name = context.variableName?.Text ?? context.identifier?.Text
            };
        }

        public override object VisitSearch_expression([NotNull] KoraliumParser.Search_expressionContext context)
        {
            SearchExpression searchExpression = new SearchExpression();

            if(context.wildcard != null)
            {
                searchExpression.AllColumns = true;
            }
            else
            {
                var columnNodes = context.column_reference();

                if (columnNodes == null)
                {
                    throw new SqlParserException("Missing columns in CONTAINS");
                }

                foreach (var columnNode in columnNodes)
                {
                    var columnReference = Visit(columnNode) as ColumnReference;

                    if (columnReference == null)
                    {
                        throw new SqlParserException("parameter in CONTAINS could not be resolved to a column");
                    }

                    searchExpression.Columns.Add(columnReference);
                }
            }
            

            var scalarExpressionNode = context.scalar_expression();

            if(scalarExpressionNode == null)
            {
                throw new SqlParserException("Could not find any search term in CONTAINS");
            }

            var scalarExpression = Visit(scalarExpressionNode) as ScalarExpression;

            if(scalarExpression == null)
            {
                throw new SqlParserException("Could not parse search term in CONTAINS");
            }

            searchExpression.Value = scalarExpression;

            return searchExpression;
        }

        public override object VisitIs_null_predicate([NotNull] KoraliumParser.Is_null_predicateContext context)
        {
            var scalarExpressionNode = context.scalar_expression();

            if(scalarExpressionNode == null)
            {
                throw new SqlParserException("Left side of IS NOT? NULL could not be parsed");
            }

            var scalarExpression = Visit(scalarExpressionNode) as ScalarExpression;

            if(scalarExpression == null)
            {
                throw new SqlParserException("Left side of IS NOT? NULL is not a scalar expression");
            }

            bool isNot = context.NOT() != null;

            return new BooleanIsNullExpression()
            {
                IsNot = isNot,
                ScalarExpression = scalarExpression
            };
        }
    }
}
