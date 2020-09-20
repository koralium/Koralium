using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Utils
{
    internal static class ListUtils
    {
        private static Dictionary<Type, Func<IList>> newListFunctions = new Dictionary<Type, Func<IList>>();

        public static Func<IList> GetNewListFunction(Type type)
        {
            if(!newListFunctions.TryGetValue(type, out var func))
            {
                func = CreateNewListDelegate(type);
                newListFunctions.Add(type, func);
            }
            return func;
        }

        static Func<IList> CreateNewListDelegate(Type objectType)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(ListUtils).GetMethod("CreateNewListDelegateHelper",
                BindingFlags.Static | BindingFlags.NonPublic);
#pragma warning restore S3011

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (objectType);

            object ret = constructedHelper.Invoke(null, null);

            // Cast the result to the right kind of delegate and return it
            return (Func<IList>)ret;
        }

#pragma warning disable S1144 // Unused private types or members should be removed
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used through reflection")]
        static Func<IList> CreateNewListDelegateHelper<TTarget>()
        {
            return () => new List<TTarget>();
        }
    }
}
