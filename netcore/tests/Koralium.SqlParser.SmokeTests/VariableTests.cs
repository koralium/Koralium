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
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System.Collections.Generic;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public void TestSetVariableString()
        {
            var actual = Parser.Parse("SET @Test = 'test'").Statements;
            var expected = new List<Statement>()
            {
                new SetVariableStatement()
                {
                    VariableReference = new VariableReference()
                    {
                        Name = "@Test"
                    },
                    ScalarExpression = new StringLiteral()
                    {
                        Value = "test"
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSetVariableInteger()
        {
            var actual = Parser.Parse("SET @Test = 1").Statements;
            var expected = new List<Statement>()
            {
                new SetVariableStatement()
                {
                    VariableReference = new VariableReference()
                    {
                        Name = "@Test"
                    },
                    ScalarExpression = new IntegerLiteral()
                    {
                        Value = 1
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSetVariableNumeric()
        {
            var actual = Parser.Parse("SET @Test = 1.3").Statements;
            var expected = new List<Statement>()
            {
                new SetVariableStatement()
                {
                    VariableReference = new VariableReference()
                    {
                        Name = "@Test"
                    },
                    ScalarExpression = new NumericLiteral()
                    {
                        Value = 1.3M
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSetVariableNoAt()
        {
            var actual = Parser.Parse("SET test = 'a'").Statements;
            var expected = new List<Statement>()
            {
                new SetVariableStatement()
                {
                    VariableReference = new VariableReference()
                    {
                        Name = "test"
                    },
                    ScalarExpression = new StringLiteral()
                    {
                        Value = "a"
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestVaraibleInWhere()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE c1 = @Param1").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
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
                                Identifiers = new List<string>(){ "c1" }
                            },
                            Right = new VariableReference()
                            {
                                Name = "@Param1"
                            },
                            Type = BooleanComparisonType.Equals
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSetBase64VariableString()
        {
            var actual = Parser.Parse("SET @Test = b64'MQ=='").Statements;
            var expected = new List<Statement>()
            {
                new SetVariableStatement()
                {
                    VariableReference = new VariableReference()
                    {
                        Name = "@Test"
                    },
                    ScalarExpression = new Base64Literal()
                    {
                        Value = "MQ=="
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
