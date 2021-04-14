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
using FluentAssertions;
using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System.Collections.Generic;

namespace Koralium.SqlParser.Tests
{
    public class PrintTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSelectStar()
        {
            StatementList statementList = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SelectStatement()
                    {
                        SelectElements = new List<Expressions.SelectExpression>()
                        {
                            new SelectStarExpression()
                        }
                    }
                }
            };

            var expected = "SELECT *";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectStarFromTable()
        {
            StatementList statementList = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SelectStatement()
                    {
                        SelectElements = new List<Expressions.SelectExpression>()
                        {
                            new SelectStarExpression()
                        },
                        FromClause = new Clauses.FromClause()
                        {
                            TableReference = new FromTableReference()
                            {
                                TableName = "test"
                            }
                        }
                    }
                }
            };

            var expected = "SELECT * FROM test";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectStarFromTableWithAlias()
        {
            StatementList statementList = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SelectStatement()
                    {
                        SelectElements = new List<Expressions.SelectExpression>()
                        {
                            new SelectStarExpression()
                        },
                        FromClause = new Clauses.FromClause()
                        {
                            TableReference = new FromTableReference()
                            {
                                TableName = "test",
                                Alias= "t"
                            }
                        }
                    }
                }
            };

            var expected = "SELECT * FROM test t";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelecColumns()
        {
            StatementList statementList = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SelectStatement()
                    {
                        SelectElements = new List<Expressions.SelectExpression>()
                        {
                            new SelectScalarExpression()
                            {
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>()
                                    {
                                        "c1"
                                    }
                                }
                            },
                            new SelectScalarExpression()
                            {
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>()
                                    {
                                        "c2"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var expected = "SELECT c1, c2";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelecColumnsWithAlias()
        {
            StatementList statementList = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SelectStatement()
                    {
                        SelectElements = new List<Expressions.SelectExpression>()
                        {
                            new SelectScalarExpression()
                            {
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>()
                                    {
                                        "c1"
                                    }
                                },
                                Alias = "a"
                            },
                            new SelectScalarExpression()
                            {
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>()
                                    {
                                        "c2"
                                    }
                                },
                                Alias = "b"
                            }
                        }
                    }
                }
            };

            var expected = "SELECT c1 AS a, c2 AS b";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectWhereComparison()
        {
            StatementList statementList = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SelectStatement()
                    {
                        SelectElements = new List<Expressions.SelectExpression>()
                        {
                            new SelectStarExpression()
                        },
                        FromClause = new Clauses.FromClause()
                        {
                            TableReference = new FromTableReference()
                            {
                                TableName = "test"
                            }
                        },
                        WhereClause = new Clauses.WhereClause()
                        {
                            Expression = new BooleanComparisonExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>()
                                    {
                                        "c1"
                                    }
                                },
                                Right = new StringLiteral()
                                {
                                    Value = "a"
                                },
                                Type = BooleanComparisonType.Equals
                            }
                        }
                    }
                }
            };

            var expected = "SELECT * FROM test WHERE c1 = 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        private StatementList GetBinaryTestStructure(BinaryType binaryType)
        {
            return new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SelectStatement()
                    {
                        SelectElements = new List<Expressions.SelectExpression>()
                        {
                            new SelectScalarExpression()
                            {
                                Expression = new BinaryExpression()
                                {
                                    Left = new ColumnReference()
                                    {
                                        Identifiers = new List<string>()
                                        {
                                            "c1"
                                        }
                                    },
                                    Right = new StringLiteral()
                                    {
                                        Value = "a"
                                    },
                                    Type = binaryType
                                }
                            }
                        }
                    }
                }
            };
        }

        [Test]
        public void TestSelectBinaryAdd()
        {
            StatementList statementList = GetBinaryTestStructure(BinaryType.Add);

            var expected = "SELECT c1 + 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectBinaryBitwiseAnd()
        {
            StatementList statementList = GetBinaryTestStructure(BinaryType.BitwiseAnd);

            var expected = "SELECT c1 & 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectBinaryBitwiseOr()
        {
            StatementList statementList = GetBinaryTestStructure(BinaryType.BitwiseOr);

            var expected = "SELECT c1 | 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectBinaryBitwiseXor()
        {
            StatementList statementList = GetBinaryTestStructure(BinaryType.BitwiseXor);

            var expected = "SELECT c1 ^ 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectBinaryBitwiseDivide()
        {
            StatementList statementList = GetBinaryTestStructure(BinaryType.Divide);

            var expected = "SELECT c1 / 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectBinaryBitwiseModulo()
        {
            StatementList statementList = GetBinaryTestStructure(BinaryType.Modulo);

            var expected = "SELECT c1 % 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectBinaryBitwiseMultiply()
        {
            StatementList statementList = GetBinaryTestStructure(BinaryType.Multiply);

            var expected = "SELECT c1 * 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }
        [Test]
        public void TestSelectBinaryBitwiseSubtract()
        {
            StatementList statementList = GetBinaryTestStructure(BinaryType.Subtract);

            var expected = "SELECT c1 - 'a'";
            var actual = statementList.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanBinaryAnd()
        {
            BooleanBinaryExpression booleanBinaryExpression = new BooleanBinaryExpression()
            {
                Left = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>()
                        {
                            "c1"
                        }
                    },
                    Right = new StringLiteral()
                    {
                        Value = "a"
                    }
                },
                Right = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>()
                        {
                            "c2"
                        }
                    },
                    Right = new StringLiteral()
                    {
                        Value = "b"
                    }
                },
                Type = BooleanBinaryType.AND
            };

            var expected = "(c1 = 'a') AND (c2 = 'b')";
            var actual = booleanBinaryExpression.Print();

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanBinaryOr()
        {
            BooleanBinaryExpression booleanBinaryExpression = new BooleanBinaryExpression()
            {
                Left = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>()
                        {
                            "c1"
                        }
                    },
                    Right = new StringLiteral()
                    {
                        Value = "a"
                    }
                },
                Right = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>()
                        {
                            "c2"
                        }
                    },
                    Right = new StringLiteral()
                    {
                        Value = "b"
                    }
                },
                Type = BooleanBinaryType.OR
            };

            var expected = "(c1 = 'a') OR (c2 = 'b')";
            var actual = booleanBinaryExpression.Print();

            actual.Should().Be(expected);
        }

        private BooleanComparisonExpression GetBooleanComparisonExpression(BooleanComparisonType booleanComparisonType)
        {
            return new BooleanComparisonExpression()
            {
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>()
                    {
                        "c1"
                    }
                },
                Right = new IntegerLiteral()
                {
                    Value = 3
                },
                Type = booleanComparisonType
            };
        }

        [Test]
        public void TestBooleanComparisonEquals()
        {
            var actual = GetBooleanComparisonExpression(BooleanComparisonType.Equals).Print();
            var expected = "c1 = 3";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanComparisonGreaterThan()
        {
            var actual = GetBooleanComparisonExpression(BooleanComparisonType.GreaterThan).Print();
            var expected = "c1 > 3";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanComparisonGreaterThanOrEqualTo()
        {
            var actual = GetBooleanComparisonExpression(BooleanComparisonType.GreaterThanOrEqualTo).Print();
            var expected = "c1 >= 3";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanComparisonLessThan()
        {
            var actual = GetBooleanComparisonExpression(BooleanComparisonType.LessThan).Print();
            var expected = "c1 < 3";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanComparisonLessThanOrEqualTo()
        {
            var actual = GetBooleanComparisonExpression(BooleanComparisonType.LessThanOrEqualTo).Print();
            var expected = "c1 <= 3";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanComparisonNotEqualTo()
        {
            var actual = GetBooleanComparisonExpression(BooleanComparisonType.NotEqualTo).Print();
            var expected = "c1 != 3";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanIsNull()
        {
            var actual = new BooleanIsNullExpression()
            {
                ScalarExpression = new ColumnReference()
                {
                    Identifiers = new List<string> { "c1" }
                }
            }.Print();
            var expected = "c1 IS NULL";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanIsNotNull()
        {
            var actual = new BooleanIsNullExpression()
            {
                ScalarExpression = new ColumnReference()
                {
                    Identifiers = new List<string> { "c1" }
                },
                IsNot = true
            }.Print();
            var expected = "c1 IS NOT NULL";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanLiteralTrue()
        {
            var actual = new BooleanLiteral() { Value = true }.Print();
            var expected = "true";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBooleanLiteralFalse()
        {
            var actual = new BooleanLiteral() { Value = false }.Print();
            var expected = "false";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestFunctionCallWildcard()
        {
            var actual = new FunctionCall() { FunctionName = "test", Wildcard = true }.Print();
            var expected = "test(*)";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestFunctionCallSingleParameter()
        {
            var actual = new FunctionCall() { 
                FunctionName = "test",
                Parameters = new List<ScalarExpression>()
                {
                    new ColumnReference()
                    {
                        Identifiers = new List<string> { "c1" }
                    }
                }
            }.Print();
            var expected = "test(c1)";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestFunctionCallTwoParameters()
        {
            var actual = new FunctionCall()
            {
                FunctionName = "test",
                Parameters = new List<ScalarExpression>()
                {
                    new ColumnReference()
                    {
                        Identifiers = new List<string> { "c1" }
                    },
                    new ColumnReference()
                    {
                        Identifiers = new List<string> { "c2" }
                    }
                }
            }.Print();
            var expected = "test(c1, c2)";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestNullLiteral()
        {
            var actual = new NullLiteral().Print();
            var expected = "NULL";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestNumericLiteralNoDecimal()
        {
            var actual = new NumericLiteral() { Value = 12M }.Print();
            var expected = "12";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestNumericLiteralWithDecimal()
        {
            var actual = new NumericLiteral() { Value = 12.3M }.Print();
            var expected = "12.3";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestGroupBySingle()
        {
            var actual = new GroupByClause() { 
                Groups = new List<GroupBy.Group>() 
                { 
                    new ExpressionGroup() { Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } } } 
                } 
            }.Print();
            var expected = "GROUP BY c1";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestGroupByTwo()
        {
            var actual = new GroupByClause()
            {
                Groups = new List<GroupBy.Group>()
                {
                    new ExpressionGroup() { Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } } },
                    new ExpressionGroup() { Expression = new ColumnReference() { Identifiers = new List<string>() { "c2" } } }
                }
            }.Print();
            var expected = "GROUP BY c1, c2";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectStatementGroup()
        {
            var actual = new SelectStatementGroup()
            {
                SelectStatement = new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectNullExpression()
                    }
                }
            }.Print();

            var expected = "(SELECT NULL)";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestHaving()
        {
            var actual = new HavingClause()
            {
                Expression = GetBooleanComparisonExpression(BooleanComparisonType.Equals)
            }.Print();
            var expected = "HAVING c1 = 3";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestInExpressionSingleValue()
        {
            var actual = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "a" }
                }
            }.Print();
            var expected = "c1 IN ('a')";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestInExpressionTwoValues()
        {
            var actual = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "a" },
                    new IntegerLiteral() { Value = 1}
                }
            }.Print();
            var expected = "c1 IN ('a', 1)";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestNotInExpressionSingleValue()
        {
            var actual = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "a" }
                },
                Not = true
            }.Print();
            var expected = "c1 NOT IN ('a')";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestNotInExpressionTwoValues()
        {
            var actual = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "a" },
                    new IntegerLiteral() { Value = 1}
                },
                Not = true
            }.Print();
            var expected = "c1 NOT IN ('a', 1)";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestLikeExpression()
        {
            var actual = new LikeExpression()
            {
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new StringLiteral() { Value = "%test%" }
            }.Print();
            var expected = "c1 LIKE '%test%'";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestNotLikeExpression()
        {
            var actual = new LikeExpression()
            {
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new StringLiteral() { Value = "%test%" },
                Not = true
            }.Print();
            var expected = "c1 NOT LIKE '%test%'";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestLimitNoOffset()
        {
            var actual = new OffsetLimitClause()
            {
                Limit = new IntegerLiteral() { Value = 17 }
            }.Print();
            var expected = "LIMIT 17";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestOffsetNoLimit()
        {
            var actual = new OffsetLimitClause()
            {
                Offset = new IntegerLiteral() { Value = 17 }
            }.Print();
            var expected = "OFFSET 17";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestLimitAndOffset()
        {
            var actual = new OffsetLimitClause()
            {
                Limit = new IntegerLiteral() { Value = 3 },
                Offset = new IntegerLiteral() { Value = 17 }
            }.Print();
            var expected = "LIMIT 3 OFFSET 17";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestOrderBySingle()
        {
            var actual = new OrderByClause()
            {
                OrderExpressions = new List<OrderBy.OrderElement>()
                {
                    new OrderExpression()
                    {
                        Expression = new ColumnReference() {Identifiers = new List<string>() { "c1" } },
                        Ascending = true
                    }
                }
            }.Print();
            var expected = "ORDER BY c1 ASC";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestOrderByMultiple()
        {
            var actual = new OrderByClause()
            {
                OrderExpressions = new List<OrderBy.OrderElement>()
                {
                    new OrderExpression()
                    {
                        Expression = new ColumnReference() {Identifiers = new List<string>() { "c1" } },
                        Ascending = true
                    },
                    new OrderExpression()
                    {
                        Expression = new ColumnReference() {Identifiers = new List<string>() { "c2" } },
                        Ascending = false
                    },
                    new OrderBySubquery()
                    {
                        SelectStatement = new SelectStatement()
                        {
                            SelectElements = new List<SelectExpression>()
                            {
                                new SelectNullExpression()
                            }
                        },
                        Ascending = true
                    },
                    new OrderBySubquery()
                    {
                        SelectStatement = new SelectStatement()
                        {
                            SelectElements = new List<SelectExpression>()
                            {
                                new SelectNullExpression()
                            }
                        },
                        Ascending = false
                    }
                }
            }.Print();
            var expected = "ORDER BY c1 ASC, c2 DESC, (SELECT NULL) ASC, (SELECT NULL) DESC";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectNullWithAlias()
        {
            var actual = new SelectNullExpression() { Alias = "c" }.Print();
            var expected = "NULL AS c";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectStatementDistinct()
        {
            var actual = new SelectStatement()
            {
                Distinct = true,
                SelectElements = new List<SelectExpression>()
                {
                    new SelectNullExpression()
                }
            }.Print();
            var expected = "SELECT DISTINCT NULL";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectStatementGroupBy()
        {
            var actual = new SelectStatement()
            {
                SelectElements = new List<SelectExpression>()
                {
                    new SelectNullExpression()
                },
                FromClause = new FromClause()
                {
                    TableReference = new FromTableReference() { TableName = "test" }
                },
                GroupByClause = new GroupByClause()
                {
                    Groups = new List<Group>()
                    {
                        new ExpressionGroup()
                        {
                            Expression = new ColumnReference(){Identifiers = new List<string>() { "c1" } }
                        }
                    }
                }
            }.Print();
            var expected = "SELECT NULL FROM test GROUP BY c1";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectStatementHaving()
        {
            var actual = new SelectStatement()
            {
                SelectElements = new List<SelectExpression>()
                {
                    new SelectNullExpression()
                },
                FromClause = new FromClause()
                {
                    TableReference = new FromTableReference() { TableName = "test" }
                },
                GroupByClause = new GroupByClause()
                {
                    Groups = new List<Group>()
                    {
                        new ExpressionGroup()
                        {
                            Expression = new ColumnReference(){Identifiers = new List<string>() { "c1" } }
                        }
                    }
                },
                HavingClause = new HavingClause()
                {
                    Expression = GetBooleanComparisonExpression(BooleanComparisonType.Equals)
                }
            }.Print();
            var expected = "SELECT NULL FROM test GROUP BY c1 HAVING c1 = 3";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectStatementOrderBy()
        {
            var actual = new SelectStatement()
            {
                SelectElements = new List<SelectExpression>()
                {
                    new SelectNullExpression()
                },
                FromClause = new FromClause()
                {
                    TableReference = new FromTableReference() { TableName = "test" }
                },
                OrderByClause = new OrderByClause()
                {
                    OrderExpressions = new List<OrderElement>()
                    {
                        new OrderExpression()
                        {
                            Expression = new ColumnReference(){ Identifiers = new List<string>() { "c1" } },
                            Ascending = true
                        }
                    }
                }
            }.Print();

            var expected = "SELECT NULL FROM test ORDER BY c1 ASC";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSelectStatementOffsetLimit()
        {
            var actual = new SelectStatement()
            {
                SelectElements = new List<SelectExpression>()
                {
                    new SelectNullExpression()
                },
                FromClause = new FromClause()
                {
                    TableReference = new FromTableReference() { TableName = "test" }
                },
                OffsetLimitClause = new OffsetLimitClause()
                {
                    Limit = new IntegerLiteral() { Value = 20 }
                }
            }.Print();

            var expected = "SELECT NULL FROM test LIMIT 20";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSetVariable()
        {
            var actual = new SetVariableStatement()
            {
                VariableReference = new VariableReference()
                {
                    Name = "@testvar"
                },
                ScalarExpression = new StringLiteral()
                {
                    Value = "test"
                }
            }.Print();
            var expected = "SET @testvar = 'test'";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSubquery()
        {
            var actual = new Subquery()
            {
                SelectStatement = new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectScalarExpression()
                        {
                            Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                        }
                    }
                }
            }.Print();
            var expected = "(SELECT c1)";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSubqueryWithAlias()
        {
            var actual = new Subquery()
            {
                SelectStatement = new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectScalarExpression()
                        {
                            Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                        }
                    }
                },
                Alias = "t"
            }.Print();
            var expected = "(SELECT c1) t";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSearchAllColumns()
        {
            var actual = new SearchExpression()
            {
                AllColumns = true,
                Value = new StringLiteral()
                {
                    Value = "test"
                }
            }.Print();
            var expected = "CONTAINS(*, 'test')";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSearchSingleColumn()
        {
            var actual = new SearchExpression()
            {
                Columns = new List<ColumnReference>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() { "c1" } }
                },
                Value = new StringLiteral()
                {
                    Value = "test"
                }
            }.Print();
            var expected = "CONTAINS(c1, 'test')";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestSearchMultipleColumns()
        {
            var actual = new SearchExpression()
            {
                Columns = new List<ColumnReference>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() { "c1" } },
                    new ColumnReference(){ Identifiers = new List<string>() { "c2" } }
                },
                Value = new StringLiteral()
                {
                    Value = "test"
                }
            }.Print();
            var expected = "CONTAINS((c1, c2), 'test')";
            actual.Should().Be(expected);
        }

        [Test]
        public void TestMultiplestatements()
        {
            var actual = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SetVariableStatement()
                    {
                        ScalarExpression = new StringLiteral(){ Value = "test" },
                        VariableReference = new VariableReference(){ Name = "@testvar"}
                    },
                    new SetVariableStatement()
                    {
                        ScalarExpression = new StringLiteral(){ Value = "test2" },
                        VariableReference = new VariableReference(){ Name = "@testvar2"}
                    },
                    new SelectStatement()
                    {
                        SelectElements = new List<SelectExpression>()
                        {
                            new SelectNullExpression()
                        }
                    }
                }
            }.Print();
            var expected = "SET @testvar = 'test';\r\n" +
                           "SET @testvar2 = 'test2';\r\n" +
                           "SELECT NULL";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestCast()
        {
            var actual = new CastExpression()
            {
                ScalarExpression = new ColumnReference()
                {
                    Identifiers = new List<string>() { "c1" }
                },
                ToType = "double"
            }.Print();
            var expected = "CAST(c1 AS double)";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestNot()
        {
            var actual = new NotExpression()
            {
                BooleanExpression = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new BooleanLiteral() { Value = true },
                    Type = BooleanComparisonType.Equals
                }
            }.Print();
            var expected = "NOT (c1 = true)";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestBetween()
        {
            var actual = new BetweenExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                From = new IntegerLiteral() { Value = 1 },
                To = new IntegerLiteral() { Value = 10 }
            }.Print();
            var expected = "c1 BETWEEN 1 AND 10";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestCaseWhen()
        {
            var actual = new CaseExpression()
            {
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Type = BooleanComparisonType.Equals,
                            Left = new ColumnReference(){ Identifiers = new List<string>() { "c1" }},
                            Right = new StringLiteral(){ Value = "test" }
                        },
                        ScalarExpression = new StringLiteral(){ Value = "val1" }
                    },
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Type = BooleanComparisonType.Equals,
                            Left = new ColumnReference(){ Identifiers = new List<string>() { "c2" }},
                            Right = new StringLiteral(){ Value = "test" }
                        },
                        ScalarExpression = new StringLiteral(){ Value = "val2" }
                    }
                }
            }.Print();
            var expected = "CASE WHEN c1 = 'test' THEN 'val1' WHEN c2 = 'test' THEN 'val2' END";

            actual.Should().Be(expected);
        }

        [Test]
        public void TestCaseWhenElse()
        {
            var actual = new CaseExpression()
            {
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Type = BooleanComparisonType.Equals,
                            Left = new ColumnReference(){ Identifiers = new List<string>() { "c1" }},
                            Right = new StringLiteral(){ Value = "test" }
                        },
                        ScalarExpression = new StringLiteral(){ Value = "val1" }
                    },
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Type = BooleanComparisonType.Equals,
                            Left = new ColumnReference(){ Identifiers = new List<string>() { "c2" }},
                            Right = new StringLiteral(){ Value = "test" }
                        },
                        ScalarExpression = new StringLiteral(){ Value = "val2" }
                    }
                },
                ElseExpression = new StringLiteral() { Value = "val3" }
            }.Print();
            var expected = "CASE WHEN c1 = 'test' THEN 'val1' WHEN c2 = 'test' THEN 'val2' ELSE 'val3' END";

            actual.Should().Be(expected);
        }
    }
}