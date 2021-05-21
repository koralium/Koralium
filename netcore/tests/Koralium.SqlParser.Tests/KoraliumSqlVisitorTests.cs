using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Statements;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    class KoraliumSqlVisitorTests
    {
        [Test]
        public void TestVisitSelectStatement()
        {
            Mock<WhereClause> whereMock = new Mock<WhereClause>();
            Mock<FromClause> fromMock = new Mock<FromClause>();
            Mock<GroupByClause> groupByMock = new Mock<GroupByClause>();
            Mock<HavingClause> havingMock = new Mock<HavingClause>();
            Mock<OffsetLimitClause> offsetLimitMock = new Mock<OffsetLimitClause>();
            Mock<OrderByClause> orderByMock = new Mock<OrderByClause>();
            Mock<SelectScalarExpression> selectMock = new Mock<SelectScalarExpression>();

            SelectStatement selectStatement = new SelectStatement()
            {
                WhereClause = whereMock.Object,
                FromClause = fromMock.Object,
                GroupByClause = groupByMock.Object,
                HavingClause = havingMock.Object,
                OffsetLimitClause = offsetLimitMock.Object,
                OrderByClause = orderByMock.Object,
                SelectElements = new List<SelectExpression>()
                {
                    selectMock.Object
                }
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();

            koraliumSqlVisitor.Visit(selectStatement);
            whereMock.Verify(x => x.Accept(koraliumSqlVisitor));
            fromMock.Verify(x => x.Accept(koraliumSqlVisitor));
            havingMock.Verify(x => x.Accept(koraliumSqlVisitor));
            offsetLimitMock.Verify(x => x.Accept(koraliumSqlVisitor));
            orderByMock.Verify(x => x.Accept(koraliumSqlVisitor));
            selectMock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitFromClause()
        {
            Mock<TableReference> mock = new Mock<TableReference>();
            FromClause fromClause = new FromClause()
            {
                TableReference = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(fromClause);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitFromTableReference()
        {
            FromTableReference fromTableReference = new FromTableReference();

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(fromTableReference);
            
            //Nothing to verify yet for from table reference
            Assert.Pass();
        }

        [Test]
        public void TestVisitSubquery()
        {
            Mock<SelectStatement> mock = new Mock<SelectStatement>();
            Subquery subquery = new Subquery()
            {
                SelectStatement = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(subquery);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitGroupByClause()
        {
            Mock<ExpressionGroup> mock = new Mock<ExpressionGroup>();
            GroupByClause groupByClause = new GroupByClause()
            {
                Groups = new List<GroupBy.Group>()
                {
                    mock.Object
                }
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(groupByClause);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitExpressionGroup()
        {
            Mock<ScalarExpression> mock = new Mock<ScalarExpression>();
            ExpressionGroup expressionGroup = new ExpressionGroup()
            {
                Expression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(expressionGroup);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitSelectStatementGroup()
        {
            Mock<SelectStatement> mock = new Mock<SelectStatement>();
            SelectStatementGroup selectStatementGroup = new SelectStatementGroup()
            {
                SelectStatement = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(selectStatementGroup);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitBooleanBinaryExpression()
        {
            Mock<BooleanExpression> leftMock = new Mock<BooleanExpression>();
            Mock<BooleanExpression> rightMock = new Mock<BooleanExpression>();

            BooleanBinaryExpression booleanBinaryExpression = new BooleanBinaryExpression()
            {
                Left = leftMock.Object,
                Right = rightMock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(booleanBinaryExpression);

            leftMock.Verify(x => x.Accept(koraliumSqlVisitor));
            rightMock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitSelectScalarExpression()
        {
            Mock<ScalarExpression> mock = new Mock<ScalarExpression>();
            SelectScalarExpression selectScalarExpression = new SelectScalarExpression()
            {
                Expression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(selectScalarExpression);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitSelectStarExpression()
        {
            SelectStarExpression selectStarExpression = new SelectStarExpression();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(selectStarExpression);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitSelectNullExpression()
        {
            SelectNullExpression selectNullExpression = new SelectNullExpression();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(selectNullExpression);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitNumericLiteral()
        {
            NumericLiteral numericLiteral = new NumericLiteral();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(numericLiteral);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitLikeExpression()
        {
            Mock<ScalarExpression> left = new Mock<ScalarExpression>();
            Mock<ScalarExpression> right = new Mock<ScalarExpression>();

            LikeExpression likeExpression = new LikeExpression()
            {
                Left = left.Object,
                Right = right.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(likeExpression);

            left.Verify(x => x.Accept(koraliumSqlVisitor));
            right.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitIntegerLiteral()
        {
            IntegerLiteral integerLiteral = new IntegerLiteral();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(integerLiteral);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitInExpression()
        {
            Mock<ScalarExpression> expMock = new Mock<ScalarExpression>();
            Mock<ScalarExpression> valueMock = new Mock<ScalarExpression>();
            InExpression inExpression = new InExpression()
            {
                Expression = expMock.Object,
                Values = new List<ScalarExpression>()
                {
                    valueMock.Object
                }
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(inExpression);

            expMock.Verify(x => x.Accept(koraliumSqlVisitor));
            valueMock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitStringLiteral()
        {
            StringLiteral stringLiteral = new StringLiteral();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(stringLiteral);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitFunctionCall()
        {
            Mock<SqlExpression> parameterMock = new Mock<SqlExpression>();
            FunctionCall functionCall = new FunctionCall()
            {
                Parameters = new List<SqlExpression>()
                {
                    parameterMock.Object
                }
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(functionCall);

            parameterMock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitColumnReference()
        {
            ColumnReference columnReference = new ColumnReference();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(columnReference);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitBooleanComparisonExpression()
        {
            Mock<ScalarExpression> left = new Mock<ScalarExpression>();
            Mock<ScalarExpression> right = new Mock<ScalarExpression>();

            BooleanComparisonExpression booleanComparisonExpression = new BooleanComparisonExpression()
            {
                Left = left.Object,
                Right = right.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(booleanComparisonExpression);

            left.Verify(x => x.Accept(koraliumSqlVisitor));
            right.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitBinaryExpression()
        {
            Mock<ScalarExpression> left = new Mock<ScalarExpression>();
            Mock<ScalarExpression> right = new Mock<ScalarExpression>();

            BinaryExpression binaryExpression = new BinaryExpression()
            {
                Left = left.Object,
                Right = right.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(binaryExpression);

            left.Verify(x => x.Accept(koraliumSqlVisitor));
            right.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitHavingClause()
        {
            Mock<BooleanExpression> mock = new Mock<BooleanExpression>();
            HavingClause havingClause = new HavingClause()
            {
                Expression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(havingClause);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitOffsetLimitClause()
        {
            Mock<ScalarExpression> limitMock = new Mock<ScalarExpression>();
            Mock<ScalarExpression> offsetMock = new Mock<ScalarExpression>();

            OffsetLimitClause offsetLimitClause = new OffsetLimitClause()
            {
                Limit = limitMock.Object,
                Offset = offsetMock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(offsetLimitClause);

            limitMock.Verify(x => x.Accept(koraliumSqlVisitor));
            offsetMock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitOrderExpression()
        {
            Mock<ScalarExpression> mock = new Mock<ScalarExpression>();
            OrderExpression orderExpression = new OrderExpression()
            {
                Expression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(orderExpression);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitOrderByClause()
        {
            Mock<OrderElement> mock = new Mock<OrderElement>();
            OrderByClause orderByClause = new OrderByClause()
            {
                OrderExpressions = new List<OrderElement>()
                {
                    mock.Object
                }
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(orderByClause);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitWhereClause()
        {
            Mock<BooleanExpression> mock = new Mock<BooleanExpression>();
            WhereClause whereClause = new WhereClause()
            {
                Expression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(whereClause);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitSetVariableStatement()
        {
            Mock<ScalarExpression> scalarMock = new Mock<ScalarExpression>();
            Mock<VariableReference> variableMock = new Mock<VariableReference>();
            SetVariableStatement setVariableStatement = new SetVariableStatement()
            {
                ScalarExpression = scalarMock.Object,
                VariableReference = variableMock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(setVariableStatement);

            scalarMock.Verify(x => x.Accept(koraliumSqlVisitor));
            variableMock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitVariableReference()
        {
            VariableReference variableReference = new VariableReference();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(variableReference);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitSearchExpression()
        {
            Mock<ColumnReference> columnMock = new Mock<ColumnReference>();
            Mock<ScalarExpression> valueMock = new Mock<ScalarExpression>();

            SearchExpression searchExpression = new SearchExpression()
            {
                Columns = new List<ColumnReference>() { columnMock.Object },
                Value = valueMock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(searchExpression);

            columnMock.Verify(x => x.Accept(koraliumSqlVisitor));
            valueMock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitBooleanIsNullExpression()
        {
            Mock<ScalarExpression> mock = new Mock<ScalarExpression>();
            BooleanIsNullExpression booleanIsNullExpression = new BooleanIsNullExpression()
            {
                ScalarExpression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(booleanIsNullExpression);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitStatementList()
        {
            Mock<Statement> mock = new Mock<Statement>();
            StatementList statementList = new StatementList()
            {
                Statements = new List<Statement>()
                {
                    mock.Object
                }
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(statementList);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitOrderBySubquery()
        {
            Mock<SelectStatement> mock = new Mock<SelectStatement>();
            OrderBySubquery orderBySubquery = new OrderBySubquery()
            {
                SelectStatement = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(orderBySubquery);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitNullLiteral()
        {
            NullLiteral nullLiteral = new NullLiteral();

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(nullLiteral);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }
       
        [Test]
        public void TestVisitBooleanLiteral()
        {
            BooleanLiteral booleanLiteral = new BooleanLiteral();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(booleanLiteral);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitBase64Literal()
        {
            Base64Literal base64Literal = new Base64Literal();
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(base64Literal);

            //Nothing to verify yet, only that no exceptions are thrown
            Assert.Pass();
        }

        [Test]
        public void TestVisitCastExpression()
        {
            Mock<ScalarExpression> mock = new Mock<ScalarExpression>();
            CastExpression castExpression = new CastExpression()
            {
                ScalarExpression = mock.Object
            };
            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(castExpression);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitNotExpression()
        {
            Mock<BooleanExpression> mock = new Mock<BooleanExpression>();
            NotExpression notExpression = new NotExpression()
            {
                BooleanExpression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(notExpression);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitBetweenExpression()
        {
            Mock<ScalarExpression> expMock = new Mock<ScalarExpression>();
            Mock<ScalarExpression> fromMock = new Mock<ScalarExpression>();
            Mock<ScalarExpression> toMock = new Mock<ScalarExpression>();
            BetweenExpression betweenExpression = new BetweenExpression()
            {
                Expression = expMock.Object,
                From = fromMock.Object,
                To = toMock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(betweenExpression);

            expMock.Verify(x => x.Accept(koraliumSqlVisitor));
            fromMock.Verify(x => x.Accept(koraliumSqlVisitor));
            toMock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitLambdaExpression()
        {
            Mock<SqlExpression> mock = new Mock<SqlExpression>();
            LambdaExpression lambdaExpression = new LambdaExpression()
            {
                Expression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(lambdaExpression);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }

        [Test]
        public void TestVisitBooleanScalarExpression()
        {
            Mock<ScalarExpression> mock = new Mock<ScalarExpression>();
            BooleanScalarExpression booleanScalarExpression = new BooleanScalarExpression()
            {
                ScalarExpression = mock.Object
            };

            KoraliumSqlVisitor koraliumSqlVisitor = new KoraliumSqlVisitor();
            koraliumSqlVisitor.Visit(booleanScalarExpression);

            mock.Verify(x => x.Accept(koraliumSqlVisitor));
        }
    }
}
