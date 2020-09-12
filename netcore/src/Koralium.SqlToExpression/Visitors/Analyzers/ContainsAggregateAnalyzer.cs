using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Koralium.SqlToExpression.Visitors.Analyzers
{
    public class ContainsAggregateAnalyzer : TSqlFragmentVisitor
    {
        private bool isAggregate = false;

        public bool IsAggregate => isAggregate;

        public override void Visit(ScalarExpression scalarExpression)
        {
            if (scalarExpression is FunctionCall functionCall)
            {
                HandleFunctionCall(functionCall);
            }
        }

        private void HandleFunctionCall(FunctionCall functionCall)
        {
            var functionName = functionCall.FunctionName.Value.ToLower();
            switch (functionName)
            {
                case "sum":
                    isAggregate = true;
                    break;
                case "min":
                    isAggregate = true;
                    break;
                case "max":
                    isAggregate = true;
                    break;
                case "count":
                    isAggregate = true;
                    break;
                case "count_big":
                    isAggregate = true;
                    break;
                case "avg":
                    isAggregate = true;
                    break;
            }
        }
    }
}
