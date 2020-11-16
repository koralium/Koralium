using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.Analyzers
{
    public class ContainsAggregateAnalyzer : KoraliumSqlVisitor
    {
        private bool isAggregate = false;

        public bool IsAggregate => isAggregate;

        public override void VisitFunctionCall(FunctionCall functionCall)
        {
            var functionName = functionCall.FunctionName.ToLower();
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
