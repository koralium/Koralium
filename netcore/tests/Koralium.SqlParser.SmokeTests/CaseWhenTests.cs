using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Literals;
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
        public void TestCaseWhen()
        {
            var actual = Parser.Parse("SELECT CASE WHEN c1 = 'test' THEN 'val1' END FROM test").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectScalarExpression()
                        {
                            Expression = new CaseExpression()
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
                                    }
                                }
                            }
                        }
                    },
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes().AllowingInfiniteRecursion());
        }

        [Test]
        public void TestCaseWhenElse()
        {
            var actual = Parser.Parse("SELECT CASE WHEN c1 = 'test' THEN 'val1' ELSE 'val2' END FROM test").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectScalarExpression()
                        {
                            Expression = new CaseExpression()
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
                                    }
                                },
                                ElseExpression = new StringLiteral(){ Value = "val2" }
                            }
                        }
                    },
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes().AllowingInfiniteRecursion());
        }
    }
}
