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
using Koralium.SqlToExpression.Providers;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.Where
{
    internal class WhereVisitor : BaseVisitor
    {

        private readonly IQueryStage _previousStage;
        private readonly VisitorMetadata _visitorMetadata;
        private readonly Stack<Expression> expressions = new Stack<Expression>();

        public Expression Expression => GetExpression();

        public bool ContainsFullTextSearch { get; private set; }

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
            _visitorMetadata = visitorMetadata;
        }

        public override void ExplicitVisit(WhereClause node)
        {
            node.SearchCondition.Accept(this);
        }

        public override void ExplicitVisit(FullTextPredicate node)
        {
            ContainsFullTextSearch = true;
            bool allFields = false;
            List<Expression> columns = new List<Expression>();
            foreach (var column in node.Columns)
            {
                //Check if it is a wildcard
                if (column is ColumnReferenceExpression columnReferenceExpression &&
                    columnReferenceExpression.ColumnType == ColumnType.Wildcard)
                {
                    allFields = true;
                }
                else
                {
                    column.Accept(this);
                    var columnExpression = PopStack();
                    columns.Add(columnExpression);
                }
            }
            if(node.Value is VariableReference variableReference)
            {
                if(_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
                {
                    if(parameter.TryGetValue<string>(out var searchString))
                    {
                        var searchParameters = new SearchParameters(allFields, columns, searchString, _previousStage.ParameterExpression);
                        var searchExpression = _visitorMetadata.SearchExpressionProvider.GetSearchExpression(searchParameters);
                        AddExpressionToStack(searchExpression);
                    }
                    else
                    {
                        throw new SqlErrorException("Search can only be done with strings");
                    }
                }
                else
                {
                    throw new SqlErrorException($"No parameter could be found with name {variableReference.Name}");
                }
            }
            else if(node.Value is StringLiteral stringLiteral)
            {
                var searchParameters = new SearchParameters(allFields, columns, stringLiteral.Value, _previousStage.ParameterExpression);
                var searchExpression = _visitorMetadata.SearchExpressionProvider.GetSearchExpression(searchParameters);
                AddExpressionToStack(searchExpression);
            }
            else
            {
                throw new SqlErrorException("Search can only be done with strings");
            }
        }

        public override void ExplicitVisit(LikePredicate node)
        {
            LikeVisitor likeVisitor = new LikeVisitor(_previousStage, _visitorMetadata);
            node.Accept(likeVisitor);

            //Add the properties that was found in the like visitor
            foreach(var usedProperty in likeVisitor.UsedProperties)
            {
                AddUsedProperty(usedProperty);
            }

            expressions.Push(likeVisitor.Expression);
        }

        public override void ExplicitVisit(InPredicate node)
        {
            if (node.Values == null)
            {
                throw new SqlErrorException("IN predicate only supports a list of values right now");
            }

            Expression memberExpression;
            if (node.Expression is ColumnReferenceExpression columnReferenceExpression)
            {
                //Check here if any index can be used aswell

                var identifiers = columnReferenceExpression.MultiPartIdentifier.Identifiers.Select(x => x.Value).ToList();

                identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
                memberExpression = MemberUtils.GetMember(_previousStage, identifiers, out var property);
                AddUsedProperty(property);
                AddNameToStack(string.Join(".", identifiers));
            }
            else
            {
                throw new SqlErrorException("IN predicate can only be used against column names");
            }

            IList list = ListUtils.GetNewListFunction(memberExpression.Type)();
            foreach (var value in node.Values)
            {
                if (value is Literal literal)
                {
                    list.Add(Convert.ChangeType(literal.Value, memberExpression.Type));
                }
                else
                {
                    throw new SqlErrorException("IN predicate only supports literal values.");
                }
            }
            var inPredicate = PredicateUtils.ListContains(memberExpression, memberExpression.Type, list);
            AddExpressionToStack(inPredicate);
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
