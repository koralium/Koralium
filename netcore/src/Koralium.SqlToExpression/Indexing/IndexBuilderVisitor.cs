using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Indexing
{
    class IndexBuilderVisitor : ExpressionVisitor
    {
        private readonly Dictionary<string, List<object>> filters = new Dictionary<string, List<object>>();

        public IReadOnlyDictionary<string, List<Object>> Filters => filters;

        internal static string GetStringFromMemberExpression(MemberExpression memberExpression)
        {
            if (memberExpression.Expression is MemberExpression inner)
            {
                return GetStringFromMemberExpression(inner) + "." + memberExpression.Member.Name;
            }
            else if(memberExpression.Expression is ParameterExpression)
            {
                return memberExpression.Member.Name;
            }
            return null;
        }

        private void AddFilter(MemberExpression member, object val)
        {
            var memberKey = GetStringFromMemberExpression(member);
            if (memberKey == null) //Do nothing if it is not a simple member
            {
                return;
            }
            if (!filters.TryGetValue(memberKey, out var values))
            {
                values = new List<object>();
                filters.Add(memberKey, values);
            }
            values.Add(val);
        }

        private void VisitBooleanBinaryExpression(BinaryExpression binaryExpression)
        {
            switch (binaryExpression.NodeType)
            {
                case ExpressionType.AndAlso:
                    base.VisitBinary(binaryExpression);
                    break;
                case ExpressionType.OrElse:
                    //Do nothing
                    break;
                default:
                    throw new NotSupportedException();
            }
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
                    return node; //Do nothing for add subtract etc
                default:
                    throw new NotImplementedException();
            }
            return node;
        }

        private void VisitBooleanComparisonExpression(BinaryExpression binaryExpression)
        {
            if (binaryExpression.NodeType == ExpressionType.Equal)
            {
                MemberExpression memberExpression = null;
                ConstantExpression constantExpression = null;
                if (binaryExpression.Left is MemberExpression member &&
                    binaryExpression.Right is ConstantExpression constant)
                {
                    memberExpression = member;
                    constantExpression = constant;
                }
                else if (binaryExpression.Right is MemberExpression memberRight &&
                    binaryExpression.Left is ConstantExpression constantLeft)
                {
                    memberExpression = memberRight;
                    constantExpression = constantLeft;
                }

                HandleBooleanComparision(memberExpression, constantExpression);
            }
        }

        private void HandleBooleanComparision(MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            if (memberExpression != null && constantExpression != null)
            {
                AddFilter(memberExpression, constantExpression.Value);
            }
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Contains")
            {
                if (TryListContains(node))
                {
                    return node;
                }
            }
            // In memory case insensitive string equals
            else if (node.Method.Name == "InternalStringEquals" &&
                node.Arguments.Count == 2 &&
                node.Arguments[0] is MemberExpression memberExpression &&
                node.Arguments[1] is ConstantExpression constantExpression)
            {
                HandleBooleanComparision(memberExpression, constantExpression);
            }

            return node;
        }

        private static Expression IgnoreConvert(Expression expression)
        {
            if (expression is UnaryExpression unaryExpression)
            {
                if (unaryExpression.NodeType == ExpressionType.Convert)
                {
                    return IgnoreConvert(unaryExpression.Operand);
                }
            }
            return expression;
        }

        private bool TryListContains(MethodCallExpression methodCallExpression)
        {
            if(methodCallExpression.Arguments.Count == 2 &&
                methodCallExpression.Arguments[0] is ConstantExpression constantList &&
                methodCallExpression.Arguments[1] is MemberExpression memb)
            {
                var values = constantList.Value as IEnumerable;
                if (values != null)
                {
                    foreach (var val in values)
                    {
                        AddFilter(memb, val);
                    }
                    return true;
                }
            }
            else if (methodCallExpression.Object is ConstantExpression constantExpression &&
                methodCallExpression.Arguments.Count == 1 &&
                IgnoreConvert(methodCallExpression.Arguments.First()) is MemberExpression memberExpression)
            {
                var values = constantExpression.Value as IEnumerable;
                if (values != null)
                {
                    foreach (var val in values)
                    {
                        AddFilter(memberExpression, val);
                    }
                    return true;
                }
                
            }
            else if (methodCallExpression.Object is MemberExpression member &&
                member.Member.MemberType == MemberTypes.Field &&
                member.Expression is ConstantExpression constant &&
                methodCallExpression.Arguments.Count == 1 &&
                IgnoreConvert(methodCallExpression.Arguments.First()) is MemberExpression memberExpression1)
            {
                var values = ((FieldInfo)member.Member).GetValue(constant.Value) as IEnumerable;
                
                if (values != null)
                {
                    foreach (var val in values)
                    {
                        AddFilter(memberExpression1, val);
                    }
                    return true;
                }
            }

            return false;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Not)
            {
                // Do not go further when it is a not
                return node;
            }
            return base.VisitUnary(node);
        }
    }
}
