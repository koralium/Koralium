using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Utils
{
    internal static class ArrayFunctionUtils
    {
        private static readonly MethodInfo anyMethod = GetAnyMethod();
        private static readonly MethodInfo whereMethod = GetWhereMethod();
        private static readonly MethodInfo firstOrDefaultMethodWithLambda = GetFirstOrDefaultMethodWithLambda();
        private static readonly MethodInfo firstOrDefaultMethodWithoutLambda = GetFirstOrDefaultMethodWithoutLambda();

        private static MethodInfo GetAnyMethod()
        {
            var methods = typeof(Enumerable).GetMethods().Where(x => x.Name == "Any" && x.IsGenericMethod && x.GetParameters().Length == 2);
            return methods.FirstOrDefault();
        }

        private static MethodInfo GetWhereMethod()
        {
            var methods = typeof(Enumerable).GetMethods().Where(x => x.Name == "Where" && x.IsGenericMethod && x.GetParameters().Length == 2);
            return methods.FirstOrDefault();
        }

        private static MethodInfo GetFirstOrDefaultMethodWithLambda()
        {
            var methods = typeof(Enumerable).GetMethods().Where(x => x.Name == "FirstOrDefault" && x.IsGenericMethod && x.GetParameters().Length == 2);
            return methods.FirstOrDefault();
        }

        private static MethodInfo GetFirstOrDefaultMethodWithoutLambda()
        {
            var methods = typeof(Enumerable).GetMethods().Where(x => x.Name == "FirstOrDefault" && x.IsGenericMethod && x.GetParameters().Length == 1);
            return methods.FirstOrDefault();
        }

        internal static Expression CallAny(Type elementType, Expression array, Expression lambda)
        {
            var method = anyMethod.MakeGenericMethod(elementType);
            return Expression.Call(method, array, lambda);
        }

        internal static Expression CallWhere(Type elementType, Expression array, Expression lambda)
        {
            var method = whereMethod.MakeGenericMethod(elementType);
            return Expression.Call(method, array, lambda);
        }

        internal static Expression CallFirstOrDefault(Type elementType, Expression array, Expression lambda = null)
        {
            if (lambda == null)
            {
                var method = firstOrDefaultMethodWithoutLambda.MakeGenericMethod(elementType);
                return Expression.Call(method, array);
            }
            else
            {
                var method = firstOrDefaultMethodWithLambda.MakeGenericMethod(elementType);
                return Expression.Call(method, array, lambda);
            }
        }
    }
}
