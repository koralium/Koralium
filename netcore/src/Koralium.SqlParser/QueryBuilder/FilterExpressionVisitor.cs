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
using Koralium.SqlParser.Literals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Koralium.Shared.Utils;
using System.Reflection;

namespace Koralium.SqlParser
{
    internal class FilterExpressionVisitor : ExpressionVisitor
    {
        private readonly Stack<SqlNode> _stack = new Stack<SqlNode>();
        private bool _inNot;

        public FilterExpressionVisitor(string tableAlias = null)
        {
            _tableAlias = tableAlias;
        }

        internal Expressions.BooleanExpression BooleanExpression => GetBooleanExpression();

        private Expressions.BooleanExpression GetBooleanExpression()
        {
            if (_stack.Peek() is Expressions.BooleanExpression expr)
            {
                return expr;
            }
            else if (_stack.Peek() is Expressions.ScalarExpression scalarExpr)
            {
                return new Expressions.BooleanScalarExpression()
                {
                    ScalarExpression = scalarExpr
                };
            }
            return null;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                    VisitBooleanComparisonExpression(node);
                    break;
                case ExpressionType.AndAlso:
                case ExpressionType.OrElse:
                    VisitBooleanBinaryExpression(node);
                    break;
                case ExpressionType.Add:
                case ExpressionType.Subtract:
                case ExpressionType.Multiply:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.Or:
                case ExpressionType.ExclusiveOr:
                    VisitBinaryExpression(node);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return node;
        }
        protected override Expression VisitUnary(UnaryExpression node)
        {
            if(node.NodeType == ExpressionType.Not)
            {
                bool previousValue = _inNot;
                if (_inNot)
                {
                    _inNot = false;
                }
                else
                {
                    _inNot = true;
                }
                Visit(node.Operand);
                _inNot = previousValue;

                return node;
            }
            throw new NotSupportedException();
        }

        private void VisitBinaryExpression(BinaryExpression binaryExpression)
        {
            var left = VisitPop<Expressions.ScalarExpression>(binaryExpression.Left);
            var right = VisitPop<Expressions.ScalarExpression>(binaryExpression.Right);
            Expressions.BinaryType binaryType;
            switch (binaryExpression.NodeType)
            {
                case ExpressionType.Add:
                    binaryType = Expressions.BinaryType.Add;
                    break;
                case ExpressionType.Subtract:
                    binaryType = Expressions.BinaryType.Subtract;
                    break;
                case ExpressionType.Multiply:
                    binaryType = Expressions.BinaryType.Multiply;
                    break;
                case ExpressionType.Divide:
                    binaryType = Expressions.BinaryType.Divide;
                    break;
                case ExpressionType.Modulo:
                    binaryType = Expressions.BinaryType.Modulo;
                    break;
                case ExpressionType.And:
                    binaryType = Expressions.BinaryType.BitwiseAnd;
                    break;
                case ExpressionType.Or:
                    binaryType = Expressions.BinaryType.BitwiseOr;
                    break;
                case ExpressionType.ExclusiveOr:
                    binaryType = Expressions.BinaryType.BitwiseXor;
                    break;
                default:
                    throw new NotImplementedException();
            }

            _stack.Push(new Expressions.BinaryExpression()
            {
                Left = left,
                Right = right,
                Type = binaryType
            });
        }

        private void VisitBooleanBinaryExpression(BinaryExpression binaryExpression)
        {
            var left = VisitPop<Expressions.BooleanExpression>(binaryExpression.Left);
            var right = VisitPop<Expressions.BooleanExpression>(binaryExpression.Right);

            Expressions.BooleanBinaryType booleanBinaryType;
            switch (binaryExpression.NodeType)
            {
                case ExpressionType.AndAlso:
                    //DeMorgans law
                    if (_inNot)
                    {
                        booleanBinaryType = Expressions.BooleanBinaryType.OR;
                    }
                    else
                    {
                        booleanBinaryType = Expressions.BooleanBinaryType.AND;
                    }
                    break;
                case ExpressionType.OrElse:
                    //DeMorgans law
                    if (_inNot)
                    {
                        booleanBinaryType = Expressions.BooleanBinaryType.AND;
                    }
                    else
                    {
                        booleanBinaryType = Expressions.BooleanBinaryType.OR;
                    }
                    break;
                default:
                    throw new NotSupportedException();
            }
            _stack.Push(new Expressions.BooleanBinaryExpression()
            {
                Left = left,
                Right = right,
                Type = booleanBinaryType
            });
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            var columnReference = new Expressions.ColumnReference() { Identifiers = new List<string>() { node.Name } };
            _stack.Push(columnReference);
            return base.VisitParameter(node);
        }

        private void VisitBooleanComparisonExpression(BinaryExpression binaryExpression)
        {
            //Check if it is a string compareTo
            if(FilterUtils.CheckIfStringCompareTo(binaryExpression, _inNot, out var stringComparison))
            {
                _stack.Push(stringComparison);
                return;
            }

            var left = VisitPop<Expressions.ScalarExpression>(binaryExpression.Left);
            var right = VisitPop<Expressions.ScalarExpression>(binaryExpression.Right);

            Expressions.BooleanComparisonType booleanComparisonType = FilterUtils.ConvertNot(FilterUtils.ParseBooleanComparisonType(binaryExpression.NodeType), _inNot);

            _stack.Push(new Expressions.BooleanComparisonExpression()
            {
                Type = booleanComparisonType,
                Left = left,
                Right = right
            });
        }

        private T VisitPop<T>(Expression expression)
            where T : SqlNode
        {
            Visit(expression);
            return _stack.Pop() as T;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if(node.Method.Name == "Contains")
            {
                if (TryStringContains(node))
                {
                    return node;
                }
                if (TryListContains(node))
                {
                    return node;
                }
            }
            else if (node.Method.Name == "StartsWith")
            {
                if (TryStringStartsWith(node))
                {
                    return node;
                }
            }
            else if(node.Method.Name == "EndsWith")
            {
                if (TryStringEndsWith(node))
                {
                    return node;
                }
            }
            else if (node.Method.Name == "Any" &&
                TryListAny(node))
            {
                return node;
            }

            throw new NotImplementedException($"The method {node.Method.Name} is not yet supported for type {node.Object.Type.Name}.");
        }

        // https://stackoverflow.com/questions/1846671/determine-if-collection-is-of-type-ienumerablet
        private static Type GetEnumerableType(Type type)
        {
            if (type.IsInterface && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return type.GetGenericArguments()[0];
            foreach (Type intType in type.GetInterfaces())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return intType.GetGenericArguments()[0];
                }
            }
            return null;
        }

        private static Expression IgnoreConvert(Expression expression)
        {
            if(expression is UnaryExpression unaryExpression)
            {
                if(unaryExpression.NodeType == ExpressionType.Convert)
                {
                    return IgnoreConvert(unaryExpression.Operand);
                }
            }
            return expression;
        }

        private Expressions.LambdaExpression VisitLambdaExpression(LambdaExpression lambdaExpression)
        {
            List<string> parameters = new List<string>();
            foreach(var parameter in lambdaExpression.Parameters)
            {
                parameters.Add(parameter.Name);
            }
            
            var body = VisitPop<Expressions.SqlExpression>(lambdaExpression.Body);

            return new Expressions.LambdaExpression()
            {
                Parameters = parameters,
                Expression = body
            };
        }

        private bool TryListAny(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Arguments.Count == 2 &&
                methodCallExpression.Arguments[0] is MemberExpression memberExpression &&
                memberExpression.Member is PropertyInfo propertyInfo &&
                ArrayUtils.IsArray(propertyInfo.PropertyType) &&
                methodCallExpression.Arguments[1] is LambdaExpression lambdaExpression)
            {
                var columnRef = VisitPop<Expressions.ColumnReference>(memberExpression);
                var lambda = VisitLambdaExpression(lambdaExpression);
                _stack.Push(new Expressions.FunctionCall()
                {
                    FunctionName = "any_match",
                    Parameters = new List<Expressions.SqlExpression>()
                    {
                        columnRef,
                        lambda
                    }
                });
                return true;
            }
            return false;
        }

        private bool TryListContains(MethodCallExpression methodCallExpression)
        {
            if(methodCallExpression.Object is ConstantExpression constantExpression &&
                methodCallExpression.Arguments.Count == 1 &&
                IgnoreConvert(methodCallExpression.Arguments.First()) is MemberExpression memberExpression)
            {
                var enumerableType = GetEnumerableType(methodCallExpression.Object.Type);
                if (enumerableType != null)
                {
                    var member = VisitPop<Expressions.ScalarExpression>(memberExpression);
                    if (enumerableType.Equals(typeof(string)))
                    {
                        var stringvalues = constantExpression.Value as IEnumerable<string>;

                        List<Expressions.ScalarExpression> values = new List<Expressions.ScalarExpression>();

                        foreach (var value in stringvalues)
                        {
                            values.Add(new StringLiteral() { Value = value });
                        }

                        _stack.Push(new Expressions.InExpression()
                        {
                            Values = values,
                            Expression = member,
                            Not = _inNot
                        });
    
                        return true;
                    }
                    else if (enumerableType.IsPrimitive)
                    {
                        var listvalues = constantExpression.Value as IEnumerable;
                        List<Expressions.ScalarExpression> values = new List<Expressions.ScalarExpression>();

                        switch (Type.GetTypeCode(enumerableType))
                        {
                            case TypeCode.Int32:
                            case TypeCode.Int64:
                            case TypeCode.UInt16:
                            case TypeCode.Int16:
                            case TypeCode.Byte:
                            case TypeCode.UInt32:
                            case TypeCode.UInt64:

                                foreach(var value in listvalues)
                                {
                                    var convertedValue = (long)Convert.ChangeType(value, typeof(long));
                                    values.Add(new IntegerLiteral()
                                    {
                                        Value = convertedValue
                                    });
                                }

                                break;
                            case TypeCode.Single:
                            case TypeCode.Double:
                            case TypeCode.Decimal:
                                foreach (var value in listvalues)
                                {
                                    var convertedValue = (decimal)Convert.ChangeType(value, typeof(decimal));
                                    values.Add(new NumericLiteral()
                                    {
                                        Value = convertedValue
                                    });
                                }
                                break;
                        }

                        _stack.Push(new Expressions.InExpression()
                        {
                            Values = values,
                            Expression = member,
                            Not = _inNot
                        });

                        return true;
                    }
                }
                return false;
            }



            
            var typeCode = Type.GetTypeCode(methodCallExpression.Object.Type);
            return false;
        }

        private bool TryStringEndsWith(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Object != null &&
                methodCallExpression.Object.Type.Equals(typeof(string)) &&
                methodCallExpression.Object is MemberExpression memberExpression &&
                methodCallExpression.Arguments.Count == 1)
            {
                if (_inNot)
                {
                    throw new NotImplementedException("EndsWith does not yet supported negation");
                }
                var left = VisitPop<Expressions.ScalarExpression>(methodCallExpression.Object);
                var right = VisitPop<Expressions.ScalarExpression>(methodCallExpression.Arguments.First());

                if (left == null || right == null)
                {
                    return false;
                }

                if (right is StringLiteral stringLiteral)
                {
                    stringLiteral.Value = $"%{stringLiteral.Value}";
                }
                else
                {
                    //If it is not a string literal, we add the wildcards outside and concatinate them
                    right = new Expressions.BinaryExpression()
                    {
                        Left = new StringLiteral() { Value = "%" },
                        Right = right,
                        Type = Expressions.BinaryType.Add
                    };
                }

                Expressions.LikeExpression likeExpression = new Expressions.LikeExpression()
                {
                    Left = left,
                    Right = right
                };

                _stack.Push(likeExpression);

                return true;
            }
            return false;
        }

        private bool TryStringStartsWith(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Object != null &&
                methodCallExpression.Object.Type.Equals(typeof(string)) &&
                methodCallExpression.Object is MemberExpression memberExpression &&
                methodCallExpression.Arguments.Count == 1)
            {
                if (_inNot)
                {
                    throw new NotImplementedException("StartsWith does not yet supported negation");
                }

                var left = VisitPop<Expressions.ScalarExpression>(methodCallExpression.Object);
                var right = VisitPop<Expressions.ScalarExpression>(methodCallExpression.Arguments.First());

                if (left == null || right == null)
                {
                    return false;
                }

                if (right is StringLiteral stringLiteral)
                {
                    stringLiteral.Value = $"{stringLiteral.Value}%";
                }
                else
                {
                    //If it is not a string literal, we add the wildcards outside and concatinate them
                    right = new Expressions.BinaryExpression()
                    {
                        Left = right,
                        Right = new StringLiteral() { Value = "%" },
                        Type = Expressions.BinaryType.Add
                    };
                }

                Expressions.LikeExpression likeExpression = new Expressions.LikeExpression()
                {
                    Left = left,
                    Right = right
                };

                _stack.Push(likeExpression);

                return true;
            }
            return false;
        }

        private bool TryStringContains(MethodCallExpression methodCallExpression)
        {
            if(methodCallExpression.Object != null && 
                methodCallExpression.Object.Type.Equals(typeof(string)) &&
                methodCallExpression.Object is MemberExpression memberExpression &&
                methodCallExpression.Arguments.Count == 1)
            {
                if (_inNot)
                {
                    throw new NotImplementedException("Contains does not yet supported negation");
                }

                var left = VisitPop<Expressions.ScalarExpression>(methodCallExpression.Object);
                var right = VisitPop<Expressions.ScalarExpression>(methodCallExpression.Arguments.First());

                if(left == null || right == null)
                {
                    return false;
                }

                if(right is StringLiteral stringLiteral)
                {
                    stringLiteral.Value = $"%{stringLiteral.Value}%";
                }
                else
                {
                    //If it is not a string literal, we add the wildcards outside and concatinate them
                    right = new Expressions.BinaryExpression()
                    {
                        Left = new StringLiteral() { Value = "%" },
                        Right = new Expressions.BinaryExpression()
                        {
                            Left = right,
                            Right = new StringLiteral() { Value = "%" },
                            Type = Expressions.BinaryType.Add
                        },
                        Type = Expressions.BinaryType.Add
                    };
                }

                Expressions.LikeExpression likeExpression = new Expressions.LikeExpression()
                {
                    Left = left,
                    Right = right
                };

                _stack.Push(likeExpression);

                return true;
            }
            return false;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != null && node.Expression.NodeType == ExpressionType.Parameter)
            {
                var columnReference = new Expressions.ColumnReference() { Identifiers = new List<string>() { node.Member.Name } };
                _stack.Push(columnReference);
                return node;
            }

            throw new NotSupportedException(string.Format("The member '{0}' is not supported", node.Member.Name));
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if(node.Value == null)
            {
                _stack.Push(new NullLiteral());
            }
            else
            {
                switch (Type.GetTypeCode(node.Value.GetType()))
                {
                    case TypeCode.Boolean:
                        _stack.Push(new BooleanLiteral()
                        {
                            Value = (bool)node.Value
                        });
                        return node;
                    case TypeCode.String:
                        _stack.Push(new StringLiteral()
                        {
                            Value = (string)node.Value
                        });
                        return node;
                    case TypeCode.Int64:
                        _stack.Push(new IntegerLiteral()
                        {
                            Value = (long)node.Value
                        });
                        return node;
                    case TypeCode.Int32:
                        _stack.Push(new IntegerLiteral()
                        {
                            Value = (int)node.Value
                        });
                        return node;
                    case TypeCode.Int16:
                        _stack.Push(new IntegerLiteral()
                        {
                            Value = (short)node.Value
                        });
                        return node;
                    case TypeCode.UInt16:
                        _stack.Push(new IntegerLiteral()
                        {
                            Value = (ushort)node.Value
                        });
                        return node;
                    case TypeCode.UInt32:
                        _stack.Push(new IntegerLiteral()
                        {
                            Value = (uint)node.Value
                        });
                        return node;
                    case TypeCode.UInt64:
                        var v = (ulong)node.Value;

                        if(v > long.MaxValue)
                        {
                            throw new Exception($"cant use integer values larger than '{long.MaxValue}'");
                        }
                        _stack.Push(new IntegerLiteral()
                        {
                            Value = (long)v
                        });
                        return node;
                    case TypeCode.Single:
                        _stack.Push(new NumericLiteral()
                        {
                            Value = (decimal)(float)node.Value
                        });
                        return node;
                    case TypeCode.Double:
                        _stack.Push(new NumericLiteral()
                        {
                            Value = (decimal)(double)node.Value
                        });
                        return node;
                    case TypeCode.Decimal:
                        _stack.Push(new NumericLiteral()
                        {
                            Value = (decimal)node.Value
                        });
                        return node;
                    default:
                        throw new NotSupportedException($"The type {node.Value.GetType().Name} is not supported");
                }
            }
                return base.VisitConstant(node);
        }
    }
}
