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
        public void TestWhereTrue()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE true = true").Statements;

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
                            Left = new Literals.BooleanLiteral()
                            {
                                Value = true
                            },
                            Right = new Literals.BooleanLiteral()
                            {
                                Value = true
                            },
                            Type = BooleanComparisonType.Equals
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestPredicateInParenthisis()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE (true = true)").Statements;

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
                            Left = new Literals.BooleanLiteral()
                            {
                                Value = true
                            },
                            Right = new Literals.BooleanLiteral()
                            {
                                Value = true
                            },
                            Type = BooleanComparisonType.Equals
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
