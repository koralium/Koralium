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
using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal class SelectPlainVisitor : BaseVisitor, ISelectVisitor
    {
        private readonly IQueryStage _previousStage;
        protected readonly List<SelectExpression> selectExpressions = new List<SelectExpression>();
        protected readonly Stack<Expression> expressionStack = new Stack<Expression>();
        protected readonly Stack<string> nameStack = new Stack<string>();

        public IReadOnlyList<SelectExpression> SelectExpressions => selectExpressions;

        public SelectPlainVisitor(IQueryStage previousStage, VisitorMetadata visitorMetadata)
            : base(previousStage, visitorMetadata)
        {
            _previousStage = previousStage;
        }

        public override void VisitSelectScalarExpression(SelectScalarExpression selectScalarExpression)
        {
            selectScalarExpression.Expression.Accept(this);
            var expression = expressionStack.Pop();
            string columnName = selectScalarExpression.Alias ?? nameStack.Pop();

            selectExpressions.Add(new SelectExpression(expression, columnName));
        }

        public override void VisitSelectStarExpression(SelectStarExpression selectStarExpression)
        {
            if (expressionStack.Count == 0)
            {
                foreach (var property in _previousStage.TypeInfo.GetProperties())
                {
                    if (property.Value.GetCustomAttribute<KoraliumIgnoreAttribute>() != null)
                    {
                        continue;
                    }

                    //Set property as used
                    AddUsedProperty(property.Value);

                    var memberExpression = Expression.MakeMemberAccess(_previousStage.ParameterExpression, property.Value);
                    selectExpressions.Add(new SelectExpression(memberExpression, property.Key));
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public override void AddExpressionToStack(Expression expression)
        {
            expressionStack.Push(expression);
        }

        public override Expression PopStack()
        {
            return expressionStack.Pop();
        }

        public override void AddNameToStack(string name)
        {
            nameStack.Push(name);
        }

        public override string PopNameStack()
        {
            return nameStack.Pop();
        }

        public void VisitSelect(SqlNode sqlNode)
        {
            sqlNode.Accept(this);
        }
    }
}
