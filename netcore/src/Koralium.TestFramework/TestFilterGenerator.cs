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
using System;
using System.Globalization;
using System.Threading;

namespace Koralium.TestFramework
{
    internal static class TestFilterGenerator
    {

        public static bool IsPossibleFilter(Type type)
        {
            Type innerType = Nullable.GetUnderlyingType(type);
            if (innerType != null)
            {
                return IsPossibleFilter(innerType);
            }
            return type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) || type.IsEnum;
        }

        public static string GetValue(object value)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var type = value.GetType();
            if (type.IsPrimitive)
                return value.ToString();

            if (type == typeof(string))
            {
                return $"'{value}'";
            }

            throw new NotImplementedException($"The type {type.FullName} is not implemented");
        }
    }
}
