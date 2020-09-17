/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.Where
{
    internal class WhereVisitor : BaseVisitor
    {
        private readonly IQueryStage _previousStage;
        private readonly Stack<Expression> expressions = new Stack<Expression>();

        public Expression Expression => GetExpression();

        private Expression GetExpression()
        {
            Debug.Assert(expressions.Count == 1);
            return expressions.Peek();
        }

        public WhereVisitor(IQueryStage queryStage, VisitorMetadata visitorMetadata)
            : base(queryStage, visitorMetadata)
        {
            Debug.Assert(queryStage != null, $"{nameof(queryStage)} was null");

            _previousStage = queryStage;
        }

        public override void ExplicitVisit(WhereClause whereClause)
        {
            whereClause.SearchCondition.Accept(this);
        }

        public override void ExplicitVisit(LikePredicate likePredicate)
        {
            likePredicate.FirstExpression.Accept(this);

            var leftExpression = PopStack();

            if(likePredicate.SecondExpression is StringLiteral stringLiteral)
            {
                var value = stringLiteral.Value;
                bool startsWith = false;
                bool endsWith = false;
                if (value.StartsWith("%"))
                {
                    endsWith = true;
                    value = value.Substring(1);
                }
                if (value.EndsWith("%") && (value.Length - 1 == 0 || value[value.Length - 1] != '\\'))
                {
                    startsWith = true;
                    value = value.Substring(0, value.Length - 1);
                }

                // Contains
                if(startsWith && endsWith)
                {
                    var containsExpression = PredicateUtils.CallContains(leftExpression, value);
                    AddExpressionToStack(containsExpression);
                }
                //Starts with
                else if (startsWith)
                {
                    var startsWithExpression = PredicateUtils.CallStartsWith(leftExpression, value);
                    AddExpressionToStack(startsWithExpression);
                }
                //Ends with
                else if (endsWith)
                {
                    var endsWithExpression = PredicateUtils.CallEndsWith(leftExpression, value);
                    AddExpressionToStack(endsWithExpression);
                }
                //Equals
                else
                {
                    var equalsExpression = PredicateUtils.CreateComparisonExpression(leftExpression, Expression.Constant(value), BooleanComparisonType.Equals);
                    AddExpressionToStack(equalsExpression);
                }
            }
            else
            {
                throw new SqlErrorException("Like can only be used with strings");
            }
        }

        public override void AddExpressionToStack(Expression expression)
        {
            expressions.Push(expression);
        }

        public override Expression PopStack()
        {
            return expressions.Pop();
        }

        public override void AddNameToStack(string name)
        {
            //Not used
        }

        public override string PopNameStack()
        {
            return string.Empty;
        }
    }
}
