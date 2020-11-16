using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Visitor;
using Koralium.SqlToExpression.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.Offset
{
    internal class OffsetVisitor : KoraliumSqlVisitor
    {
        private readonly VisitorMetadata _visitorMetadata;

        private int? offsetCount = null;
        private int? takeCount = null;

        public int? OffsetCount => offsetCount;
        public int? TakeCount => takeCount;

        public OffsetVisitor(VisitorMetadata visitorMetadata)
        {
            _visitorMetadata = visitorMetadata;
        }

        private void VisitOffsetExpression(ScalarExpression offsetExpression)
        {
            if (offsetExpression is IntegerLiteral integerLiteral)
            {
                offsetCount = (int)integerLiteral.Value;
            }
            else if (offsetExpression is VariableReference variableReference)
            {
                if (!_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
                {
                    throw new SqlErrorException($"The parameter {variableReference.Name} was not found");
                }
                if (parameter.TryGetValue<int>(out var parameterValue))
                {
                    offsetCount = parameterValue;
                }
                else
                {
                    throw new SqlErrorException($"The value in parameter {variableReference.Name} used in offset can only contain integer values");
                }
            }
            else
            {
                throw new SqlErrorException("Only integers or variables can be used as offset");
            }
        }

        private void VisitFetchExpression(ScalarExpression fetchExpression)
        {
            if (fetchExpression is IntegerLiteral integerLiteral)
            {
                takeCount = (int)integerLiteral.Value;
            }
            else if (fetchExpression is VariableReference variableReference)
            {
                if (!_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
                {
                    throw new SqlErrorException($"The parameter {variableReference.Name} was not found");
                }
                if (parameter.TryGetValue<int>(out var parameterValue))
                {
                    takeCount = parameterValue;
                }
                else
                {
                    throw new SqlErrorException($"The value in parameter {variableReference.Name} used in fetch can only contain integer values");
                }
            }
            else
            {
                throw new SqlErrorException("Only integers or variables can be used as offset");
            }
        }

        public override void VisitOffsetLimitClause(OffsetLimitClause offsetLimitClause)
        {
            if (offsetLimitClause.Offset != null)
            {
                VisitOffsetExpression(offsetLimitClause.Offset);
            }
            if (offsetLimitClause.Limit != null)
            {
                VisitFetchExpression(offsetLimitClause.Limit);
            }
        }
    }
}
