using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public void TestFunctionCall()
        {
            var actual = Parser.Parse("SELECT sum(c1) FROM test").Statements;
            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectScalarExpression()
                        {
                            Expression = new FunctionCall()
                            {
                                FunctionName = "sum",
                                Parameters = new List<ScalarExpression>()
                                {
                                    new ColumnReference()
                                    {
                                        Identifiers = new List<string>(){ "c1" }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestFunctionCallUppercase()
        {
            var actual = Parser.Parse("SELECT SUM(c1) FROM test").Statements;
            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectScalarExpression()
                        {
                            Expression = new FunctionCall()
                            {
                                FunctionName = "sum",
                                Parameters = new List<ScalarExpression>()
                                {
                                    new ColumnReference()
                                    {
                                        Identifiers = new List<string>(){ "c1" }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestFunctionCallWildcard()
        {
            var actual = Parser.Parse("SELECT count(*) FROM test").Statements;
            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectScalarExpression()
                        {
                            Expression = new FunctionCall()
                            {
                                FunctionName = "count",
                                Wildcard = true
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
