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
using Koralium.SqlToExpression.Stages.CompileStages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.Having
{
    class HavingVisitor_old : BaseAggregationVisitor_old
    {
        private readonly Stack<Expression> expressions = new Stack<Expression>();

        public Expression Expression => GetExpression();

        private Expression GetExpression()
        {
            Debug.Assert(expressions.Count == 1);
            return expressions.Peek();
        }

        public HavingVisitor_old(GroupedStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
        }

        public override void AddExpressionToStack(Expression expression)
        {
            expressions.Push(expression);
        }

        public override void AddNameToStack(string name)
        {
            //Not used
        }

        public override string PopNameStack()
        {
            return string.Empty;
        }

        public override Expression PopStack()
        {
            return expressions.Pop();
        }
    }
}
