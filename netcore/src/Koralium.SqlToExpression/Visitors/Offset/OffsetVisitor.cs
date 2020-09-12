using Koralium.SqlToExpression.Exceptions;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Koralium.SqlToExpression.Visitors.Offset
{
    internal class OffsetVisitor : TSqlFragmentVisitor
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

        public override void ExplicitVisit(OffsetClause offsetClause)
        {
            {
                if (offsetClause.OffsetExpression != null)
                {
                    if (offsetClause.OffsetExpression is IntegerLiteral integerLiteral && int.TryParse(integerLiteral.Value, out var value))
                    {
                        offsetCount = value;
                    }
                    else if(offsetClause.OffsetExpression is VariableReference variableReference)
                    {
                        if(!_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
                        {
                            throw new SqlErrorException($"The parameter {variableReference.Name} was not found");
                        }
                        if(parameter.TryGetValue<int>(out var parameterValue))
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
            }
            {
                if (offsetClause.FetchExpression != null)
                {
                    if (offsetClause.FetchExpression is IntegerLiteral integerLiteral && int.TryParse(integerLiteral.Value, out var value))
                    {
                        takeCount = value;
                    }
                    else if (offsetClause.FetchExpression is VariableReference variableReference)
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
            }
        }
    }
}
