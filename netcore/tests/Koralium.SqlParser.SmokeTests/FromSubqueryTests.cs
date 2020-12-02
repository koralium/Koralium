using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System.Collections.Generic;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public void TestSelectFromSubquery()
        {
            var actual = Parser.Parse("SELECT * FROM (SELECT * FROM TEST) t").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new Subquery()
                        {
                            Alias = "t",
                            SelectStatement = new SelectStatement()
                            {
                                SelectElements = new List<SelectExpression>()
                                {
                                    new SelectStarExpression()
                                },
                                FromClause = new Clauses.FromClause()
                                {
                                    TableReference = new FromTableReference()
                                    {
                                        TableName = "TEST"
                                    }
                                }
                            }
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                       new SelectStarExpression()
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
