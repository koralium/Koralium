using Koralium.Shared;
using Koralium.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Koralium.Core.Utils
{
    internal static class CircularDependencyHelper
    {
        public static void CheckCircularDependency(Type type)
        {
            var (result, path) = CheckCircularDependency(type, new HashSet<Type>());

            if (result)
            {
                //Create a list of the entire path for the circular dependency
                var splittedPath = path.Split(';').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
                var circularDependencyPath = string.Join(" -> ", splittedPath);

                throw new InvalidOperationException($"Circular dependency found in type: '{type.Name}', path: '{circularDependencyPath}'");
            }
        }

        private static (bool, string) CheckCircularDependency(Type type, HashSet<Type> visitedTypes)
        {
            var (columnType, _) = ColumnTypeHelper.GetKoraliumType(type);
            
            if (columnType == Transport.ColumnType.Object)
            {
                return CheckObjectCircularDependency(type, visitedTypes);
            }
            else if (columnType == Transport.ColumnType.List)
            {
                return CheckListCircularDependency(type, visitedTypes);
            }
            return (false, string.Empty);
        }

        private static (bool, string) CheckObjectCircularDependency(Type type, HashSet<Type> visitedTypes)
        {
            if (visitedTypes.Contains(type))
            {
                return (true, string.Empty);
            }

            visitedTypes.Add(type);

            var properties = type.GetProperties();

            foreach(var property in properties)
            {
                if (property.GetCustomAttribute<KoraliumIgnoreAttribute>() != null)
                {
                    continue;
                }
                var (result, path) = CheckCircularDependency(property.PropertyType, visitedTypes);
                if (result)
                {
                    return (true, $"{property.Name} ({property.PropertyType.Name});" + path);
                }
            }

            visitedTypes.Remove(type);

            return (false, string.Empty);
        }

        private static (bool, string) CheckListCircularDependency(Type type, HashSet<Type> visitedTypes)
        {
            Type innerType = type.GetGenericArguments()[0];
            return CheckCircularDependency(innerType, visitedTypes);
        }
    }
}
