using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Utils
{
    internal static class AnonTypeUtils
    {
        private static Type[] anonTypes = new Type[]
            {
                typeof(AnonType),
                typeof(AnonType<>),
                typeof(AnonType<,>),
                typeof(AnonType<,,>),
                typeof(AnonType<,,,>),
                typeof(AnonType<,,,,>),
                typeof(AnonType<,,,,,>),
                typeof(AnonType<,,,,,,>),
                typeof(AnonType<,,,,,,,>),
                typeof(AnonType<,,,,,,,,>),
                typeof(AnonType<,,,,,,,,,>),
                typeof(AnonType<,,,,,,,,,,>),
                typeof(AnonType<,,,,,,,,,,,>),
                typeof(AnonType<,,,,,,,,,,,,>),
                typeof(AnonType<,,,,,,,,,,,,,>)
            };

        private static ConcurrentDictionary<Type, Func<object, object>[]> typeToGetDelegates = new ConcurrentDictionary<Type, Func<object, object>[]>();

        public static Type GetAnonType(params Type[] propertyTypes)
        {
            return anonTypes[propertyTypes.Length].MakeGenericType(propertyTypes);
        }

        public static Func<object, object>[] GetDelegates(Type anonType)
        {
            if(!typeToGetDelegates.TryGetValue(anonType, out var delegates))
            {
                delegates = BuildGetDeletages(anonType);
                typeToGetDelegates.TryAdd(anonType, delegates);
            }
            return delegates;
        }

        private static Func<object, object>[] BuildGetDeletages(Type type)
        {
            var properties = type.GetProperties();
            Func<object, object>[] output = new Func<object, object>[properties.Length];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = CreateGetDelegate(type, properties[i].GetGetMethod());
            }
            return output;
        }

        static Func<object, object> CreateGetDelegate(Type objectType, MethodInfo method)
        {
            return CreateGetDelegateInternal(objectType, method);
        }

        static Func<object, object> CreateGetDelegateInternal(Type objectType, MethodInfo method)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(AnonTypeUtils).GetMethod("CreateGetDelegateHelper",
                BindingFlags.Static | BindingFlags.NonPublic);
#pragma warning restore S3011

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (objectType, method.ReturnType);

            // Now call it. The null argument is because it's a static method.
            object ret = constructedHelper.Invoke(null, new object[] { method });

            // Cast the result to the right kind of delegate and return it
            return (Func<object, object>)ret;
        }

#pragma warning disable S1144 // Unused private types or members should be removed
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used through reflection")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed", Justification = "Assignment is used")]
        static Func<object, object> CreateGetDelegateHelper<TTarget, TReturn>(MethodInfo method)
            where TTarget : class
        {
            // Convert the slow MethodInfo into a fast, strongly typed, open delegate
            Func<TTarget, TReturn> func = (Func<TTarget, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TReturn>), method);

            // Now create a more weakly typed delegate which will call the strongly typed one
            object ret(object target) => func((TTarget)target);
            return ret;
        }
#pragma warning restore S1144 // Unused private types or members should be removed
    }
}
