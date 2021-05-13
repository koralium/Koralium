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

        private static MethodInfo GetAnyMethod()
        {
            var methods = typeof(Enumerable).GetMethods().Where(x => x.Name == "Any" && x.IsGenericMethod && x.GetParameters().Length == 2);
            return methods.FirstOrDefault();
        }

        internal static Expression CallAny(Type elementType, Expression array, Expression lambda)
        {
            var method = anyMethod.MakeGenericMethod(elementType);
            return Expression.Call(method, array, lambda);
        }
    }
}
