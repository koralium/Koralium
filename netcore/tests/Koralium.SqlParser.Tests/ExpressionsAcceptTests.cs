using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class ExpressionsAcceptTests
    {
        [Test]
        public void TestBetweenExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BetweenExpression betweenExpression = new BetweenExpression();

            betweenExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitBetweenExpression(betweenExpression));
        }

        [Test]
        public void TestBinaryExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BinaryExpression binaryExpression = new BinaryExpression();

            binaryExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitBinaryExpression(binaryExpression));
        }

        [Test]
        public void TestBooleanBinaryExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BooleanBinaryExpression booleanBinaryExpression = new BooleanBinaryExpression();

            booleanBinaryExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitBooleanBinaryExpression(booleanBinaryExpression));
        }

        [Test]
        public void TestBooleanComparisonExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BooleanComparisonExpression booleanComparisonExpression = new BooleanComparisonExpression();

            booleanComparisonExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitBooleanComparisonExpression(booleanComparisonExpression));
        }

        [Test]
        public void TestBooleanIsNullExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BooleanIsNullExpression booleanIsNullExpression = new BooleanIsNullExpression();

            booleanIsNullExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitBooleanIsNullExpression(booleanIsNullExpression));
        }

        [Test]
        public void TestBooleanScalarExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BooleanScalarExpression booleanScalarExpression = new BooleanScalarExpression();

            booleanScalarExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitBooleanScalarExpression(booleanScalarExpression));
        }

        [Test]
        public void TestCastExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            CastExpression castExpression = new CastExpression();

            castExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitCastExpression(castExpression));
        }

        [Test]
        public void TestColumnReferenceAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            ColumnReference columnReference = new ColumnReference();

            columnReference.Accept(mock.Object);
            mock.Verify(x => x.VisitColumnReference(columnReference));
        }

        [Test]
        public void TestFunctionCallAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            FunctionCall functionCall = new FunctionCall();

            functionCall.Accept(mock.Object);
            mock.Verify(x => x.VisitFunctionCall(functionCall));
        }

        [Test]
        public void TestInExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            InExpression inExpression = new InExpression();

            inExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitInExpression(inExpression));
        }

        [Test]
        public void TestLambdaExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            LambdaExpression lambdaExpression = new LambdaExpression();

            lambdaExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitLambdaExpression(lambdaExpression));
        }

        [Test]
        public void TestLikeExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            LikeExpression likeExpression = new LikeExpression();

            likeExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitLikeExpression(likeExpression));
        }

        [Test]
        public void TestNotExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            NotExpression notExpression = new NotExpression();

            notExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitNotExpression(notExpression));
        }

        [Test]
        public void TestSearchExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            SearchExpression searchExpression = new SearchExpression();

            searchExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitSearchExpression(searchExpression));
        }

        [Test]
        public void TestSelectNullExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            SelectNullExpression selectNullExpression = new SelectNullExpression();

            selectNullExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitSelectNullExpression(selectNullExpression));
        }

        [Test]
        public void TestSelectScalarExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            SelectScalarExpression selectScalarExpression = new SelectScalarExpression();

            selectScalarExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitSelectScalarExpression(selectScalarExpression));
        }

        [Test]
        public void TestSelectStarExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            SelectStarExpression selectStarExpression = new SelectStarExpression();

            selectStarExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitSelectStarExpression(selectStarExpression));
        }

        [Test]
        public void TestVariableReferenceAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            VariableReference variableReference = new VariableReference();

            variableReference.Accept(mock.Object);
            mock.Verify(x => x.VisitVariableReference(variableReference));
        }
    }
}
