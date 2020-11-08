using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Executors.AggregateFunction
{
    internal static class ObjectExtensions
    {
        public static T Cast<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
