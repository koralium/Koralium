using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Diagnostics;

namespace Koralium.SqlToExpression.Visitors.Offset
{
    internal static class OffsetHelper
    {
        public static OffsetStage GetOffsetStage(IQueryStage previousStage, OffsetClause offsetClause, VisitorMetadata visitorMetadata)
        {
            OffsetVisitor offsetVisitor = new OffsetVisitor(visitorMetadata);
            offsetClause.Accept(offsetVisitor);

            return new OffsetStage(
                previousStage.TypeInfo,
                previousStage.ParameterExpression,
                previousStage.CurrentType,
                previousStage.FromAliases,
                offsetVisitor.OffsetCount,
                offsetVisitor.TakeCount
                );
        }

        public static OffsetStage GetOffsetStage(IQueryStage previousStage, TopRowFilter topRowFilter, VisitorMetadata visitorMetadata)
        {
            Debug.Assert(topRowFilter.Expression != null);

            var expression = topRowFilter.Expression;

            while (expression is ParenthesisExpression parenthesisExpression)
            {
                expression = parenthesisExpression.Expression;
            }

            if(expression is IntegerLiteral integerLiteral && int.TryParse(integerLiteral.Value, out var value))
            {
                return new OffsetStage(
                    previousStage.TypeInfo,
                    previousStage.ParameterExpression,
                    previousStage.CurrentType,
                    previousStage.FromAliases,
                    null,
                    value
                    );
            }

            else if (expression is VariableReference variableReference)
            {
                if (!visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
                {
                    throw new SqlErrorException($"The parameter {variableReference.Name} was not found");
                }
                if (parameter.TryGetValue<int>(out var parameterValue))
                {
                    return new OffsetStage(
                        previousStage.TypeInfo,
                        previousStage.ParameterExpression,
                        previousStage.CurrentType,
                        previousStage.FromAliases,
                        null,
                        parameterValue
                        );
                }
                else
                {
                    throw new SqlErrorException($"The value in parameter {variableReference.Name} used in TOP can only contain integer values");
                }
            }
            else
            {
                throw new SqlErrorException("Only integers can be used with TOP command");
            }
        }
    }
}
