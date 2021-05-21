using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class StatementsCloneTests
    {
        [Test]
        public void TestCloneSelectStatement()
        {
            SelectStatement selectStatement = new SelectStatement()
            {
                Distinct = false,
                FromClause = new Clauses.FromClause()
                {
                    TableReference = new FromTableReference()
                    {
                        TableName = "t"
                    }
                },
                GroupByClause = new Clauses.GroupByClause()
                {
                    Groups = new List<GroupBy.Group>()
                    {
                        new ExpressionGroup()
                        {
                            Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                        }
                    }
                },
                HavingClause = new Clauses.HavingClause()
                {
                    Expression = new BooleanScalarExpression() { ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } } }
                },
                OffsetLimitClause = new Clauses.OffsetLimitClause()
                {
                    Limit = new IntegerLiteral() { Value = 3 },
                    Offset = new IntegerLiteral() { Value = 17 }
                },
                OrderByClause = new Clauses.OrderByClause()
                {
                    OrderExpressions = new List<OrderBy.OrderElement>()
                    {
                        new OrderExpression(){ Expression = new ColumnReference(){ Identifiers = new List<string>(){ "c1" }}}
                    }
                },
                SelectElements = new List<SelectExpression>()
                {
                    new SelectScalarExpression(){ Expression = new ColumnReference() { Identifiers = new List<string>() { "c1"} } }
                },
                WhereClause = new Clauses.WhereClause()
                {
                    Expression = new BooleanScalarExpression() { ScalarExpression = new BooleanLiteral() { Value = false } }
                }
            };

            var clone = selectStatement.Clone() as SelectStatement;

            Assert.AreEqual(selectStatement, clone);
            Assert.IsFalse(ReferenceEquals(selectStatement, clone));
            Assert.IsFalse(ReferenceEquals(selectStatement.FromClause, clone.FromClause));
            Assert.IsFalse(ReferenceEquals(selectStatement.GroupByClause, clone.GroupByClause));
            Assert.IsFalse(ReferenceEquals(selectStatement.HavingClause, clone.HavingClause));
            Assert.IsFalse(ReferenceEquals(selectStatement.OffsetLimitClause, clone.OffsetLimitClause));
            Assert.IsFalse(ReferenceEquals(selectStatement.OrderByClause, clone.OrderByClause));
            Assert.IsFalse(ReferenceEquals(selectStatement.SelectElements, clone.SelectElements));
            Assert.IsFalse(ReferenceEquals(selectStatement.WhereClause, clone.WhereClause));

            for (int i = 0; i < selectStatement.SelectElements.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(selectStatement.SelectElements[i], clone.SelectElements[i]));
            }
        }

        [Test]
        public void TestCloneSetVariableStatement()
        {
            TestCloneSetVariableStatement_internal(new SetVariableStatement()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                VariableReference = new VariableReference()
                {
                    Name = "t"
                }
            });

            TestCloneSetVariableStatement_internal(new SetVariableStatement()
            {
                ScalarExpression = null,
                VariableReference = new VariableReference()
                {
                    Name = "t"
                }
            });

            TestCloneSetVariableStatement_internal(new SetVariableStatement()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                VariableReference = null
            });

        }

        private void TestCloneSetVariableStatement_internal(SetVariableStatement setVariableStatement)
        {
            var clone = setVariableStatement.Clone() as SetVariableStatement;

            Assert.AreEqual(setVariableStatement, clone);
            Assert.IsFalse(ReferenceEquals(setVariableStatement, clone));

            if (setVariableStatement.ScalarExpression != null && clone.ScalarExpression != null)
            {
                Assert.IsFalse(ReferenceEquals(setVariableStatement.ScalarExpression, clone.ScalarExpression));
            }
            if (setVariableStatement.VariableReference != null && clone.VariableReference != null)
            {
                Assert.IsFalse(ReferenceEquals(setVariableStatement.VariableReference, clone.VariableReference));
            }  
        }


        [Test]
        public void TestCloneStatementList()
        {
            StatementList statementList = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SetVariableStatement()
                    {
                        ScalarExpression = new StringLiteral() { Value = "t" }
                    }
                }
            };

            var clone = statementList.Clone() as StatementList;

            Assert.AreEqual(statementList, clone);
            Assert.IsFalse(ReferenceEquals(statementList, clone));
            Assert.IsFalse(ReferenceEquals(statementList.Statements, clone.Statements));

            for (int i = 0; i < statementList.Statements.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(statementList.Statements[i], clone.Statements[i]));
            }
        }
    }
}
