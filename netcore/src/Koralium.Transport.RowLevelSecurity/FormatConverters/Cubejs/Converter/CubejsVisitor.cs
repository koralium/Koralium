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
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Visitor;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Converter
{
    class CubejsVisitor : KoraliumSqlVisitor
    {
        private readonly CubeJsOptions _options;
        private readonly Stack<BaseQueryFilter> _stack = new Stack<BaseQueryFilter>();

        public CubejsVisitor(CubeJsOptions options)
        {
            _options = options;
        }

        public BaseQueryFilter GetFilter()
        {
            if (_stack.Count == 0)
            {
                return null;
            }
            else
            {
                return _stack.Peek();
            }
        }

        private string WriteColumnName(string columnName)
        {
            if (_options.LowerCaseFirstMemberCharacter && columnName.Length > 0)
            {
                columnName  = char.ToLower(columnName[0]) + columnName.Substring(1);
            }
            if (!string.IsNullOrEmpty(_options.CubeName))
            {
                return $"{_options.CubeName}.{columnName}";
            }
            return columnName;
        }

        private BaseQueryFilter VisitPop(SqlNode sqlNode)
        {
            Visit(sqlNode);
            return _stack.Pop();
        }

        private void Push(BaseQueryFilter queryFilter)
        {
            _stack.Push(queryFilter);
        }

        public override void VisitBooleanBinaryExpression(BooleanBinaryExpression booleanBinaryExpression)
        {
            var left = VisitPop(booleanBinaryExpression.Left);
            var right = VisitPop(booleanBinaryExpression.Right);

            var binaryFilter = new BinaryQueryFilter();
            switch (booleanBinaryExpression.Type)
            {
                case BooleanBinaryType.AND:
                    binaryFilter.And = new List<BaseQueryFilter>()
                    {
                        left,
                        right
                    };
                    break;
                case BooleanBinaryType.OR:
                    binaryFilter.Or = new List<BaseQueryFilter>()
                    {
                        left,
                        right
                    };
                    break;
            }
            Push(binaryFilter);
        }

        private (string fieldName, object value) CheckComparisonArguments(ScalarExpression left, ScalarExpression right)
        {
            ColumnReference columnReference = null;
            object value = null;
            if (left is ColumnReference leftColumn)
            {
                columnReference = leftColumn;
            }
            if (right is ColumnReference rightColumn)
            {
                if (columnReference != null)
                {
                    //TODO: Fix exception
                    throw new System.Exception("CubeJS filter can not compare two columns");
                }
                columnReference = rightColumn;
            }
            if (left is Literal leftLiteral)
            {
                value = leftLiteral.GetValue();
            }
            if (right is Literal rightLiteral)
            {
                value = rightLiteral.GetValue();
            }
            if (columnReference == null || value == null)
            {
                throw new System.Exception("Comparisions for CubeJS filter must contain only a column and a value");
            }
            return (string.Join(".", columnReference.Identifiers), value);
        }

        public override void VisitBooleanComparisonExpression(BooleanComparisonExpression booleanComparisonExpression)
        {
            var (fieldName, value) = CheckComparisonArguments(booleanComparisonExpression.Left, booleanComparisonExpression.Right);
            fieldName = WriteColumnName(fieldName);
            var val = value.ToString();

            switch (booleanComparisonExpression.Type)
            {
                case BooleanComparisonType.Equals:
                    Push(new QueryFilter()
                    {
                        Member = fieldName,
                        Operator = ComparisonOperator.Equals,
                        Values = new List<string>()
                        {
                            val
                        }
                    });
                    break;
                case BooleanComparisonType.GreaterThan:
                    Push(new QueryFilter()
                    {
                        Member = fieldName,
                        Operator = ComparisonOperator.GreaterThan,
                        Values = new List<string>()
                        {
                            val
                        }
                    });
                    break;
                case BooleanComparisonType.GreaterThanOrEqualTo:
                    Push(new QueryFilter()
                    {
                        Member = fieldName,
                        Operator = ComparisonOperator.GreaterThanOrEqual,
                        Values = new List<string>()
                        {
                            val
                        }
                    });
                    break;
                case BooleanComparisonType.LessThan:
                    Push(new QueryFilter()
                    {
                        Member = fieldName,
                        Operator = ComparisonOperator.LessThan,
                        Values = new List<string>()
                        {
                            val
                        }
                    });
                    break;
                case BooleanComparisonType.LessThanOrEqualTo:
                    Push(new QueryFilter()
                    {
                        Member = fieldName,
                        Operator = ComparisonOperator.LessThanOrEqual,
                        Values = new List<string>()
                        {
                            val
                        }
                    });
                    break;
                case BooleanComparisonType.NotEqualTo:
                    Push(new QueryFilter()
                    {
                        Member = fieldName,
                        Operator = ComparisonOperator.NotEquals,
                        Values = new List<string>()
                        {
                            val
                        }
                    });
                    break;
            }
        }

        public override void VisitInExpression(InExpression inExpression)
        {
            if (!(inExpression.Expression is ColumnReference column))
            {
                //TODO: Fix exception
                throw new System.Exception("In expressions can only be done on columns for CubeJS filters");
            }

            List<string> values = new List<string>();
            foreach (var val in inExpression.Values)
            {
                if (!(val is Literal literal))
                {
                    throw new System.Exception("In expression can only have literals as valeus for CubeJS filters");
                }
                values.Add(literal.GetValue().ToString());
            }
            Push(new QueryFilter()
            {
                Member = WriteColumnName(string.Join(".", column.Identifiers)),
                Operator = ComparisonOperator.Equals,
                Values = values
            });
        }

        public override void VisitNotExpression(NotExpression notExpression)
        {
            throw new Exception("Not expression is not yet supported for CubeJS filter export.");
        }

        public override void VisitBinaryExpression(BinaryExpression binaryExpression)
        {
            throw new System.Exception("Binary expressions are not supported in CubeJS filters");
        }
    }
}
