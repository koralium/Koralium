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
    public class StatementsEqualsTests
    {
        [Test]
        public void TestSelectStatementEquals()
        {
            SelectStatement first = new SelectStatement()
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

            SelectStatement firstClone = new SelectStatement()
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

            SelectStatement second = new SelectStatement()
            {
                Distinct = true,
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

            SelectStatement third = new SelectStatement()
            {
                Distinct = false,
                FromClause = new Clauses.FromClause()
                {
                    TableReference = new FromTableReference()
                    {
                        TableName = "t2"
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

            SelectStatement fourth = new SelectStatement()
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
                            Expression = new ColumnReference() { Identifiers = new List<string>() { "c12" } }
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

            SelectStatement fifth = new SelectStatement()
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
                    Expression = new BooleanScalarExpression() { ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c3" } } }
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

            SelectStatement sixth = new SelectStatement()
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
                    Limit = new IntegerLiteral() { Value = 5 },
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

            SelectStatement seventh = new SelectStatement()
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
                        new OrderExpression(){ Expression = new ColumnReference(){ Identifiers = new List<string>(){ "c2" }}}
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

            SelectStatement eigth = new SelectStatement()
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
                    new SelectScalarExpression(){ Expression = new ColumnReference() { Identifiers = new List<string>() { "c2"} } }
                },
                WhereClause = new Clauses.WhereClause()
                {
                    Expression = new BooleanScalarExpression() { ScalarExpression = new BooleanLiteral() { Value = false } }
                }
            };

            SelectStatement ninth = new SelectStatement()
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
                    Expression = new BooleanScalarExpression() { ScalarExpression = new BooleanLiteral() { Value = true } }
                }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, fourth));
            Assert.IsFalse(Equals(first, fifth));
            Assert.IsFalse(Equals(first, sixth));
            Assert.IsFalse(Equals(first, seventh));
            Assert.IsFalse(Equals(first, eigth));
            Assert.IsFalse(Equals(first, ninth));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), fourth.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), fifth.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), sixth.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), seventh.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), eigth.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), ninth.GetHashCode());
        }

        [Test]
        public void TestSetVariableStatementEquals()
        {
            SetVariableStatement first = new SetVariableStatement()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                VariableReference = new VariableReference()
                {
                    Name = "t"
                }
            };

            SetVariableStatement firstClone = new SetVariableStatement()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                VariableReference = new VariableReference()
                {
                    Name = "t"
                }
            };

            SetVariableStatement second = new SetVariableStatement()
            {
                ScalarExpression = new StringLiteral() { Value = "test2" },
                VariableReference = new VariableReference()
                {
                    Name = "t"
                }
            };

            SetVariableStatement third = new SetVariableStatement()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                VariableReference = new VariableReference()
                {
                    Name = "t2"
                }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
        }

        [Test]
        public void TestStatementListEquals()
        {
            StatementList first = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SetVariableStatement()
                    {
                        ScalarExpression = new StringLiteral() { Value = "t" }
                    }
                }
            };

            StatementList firstClone = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SetVariableStatement()
                    {
                        ScalarExpression = new StringLiteral() { Value = "t" }
                    }
                }
            };

            StatementList second = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    new SetVariableStatement()
                    {
                        ScalarExpression = new StringLiteral() { Value = "t2" }
                    }
                }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}
