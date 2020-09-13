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
using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Koralium.SqlToExpression.Tests
{
    public class QueryComparer : IEqualityComparer<IQueryable>
    {
        public bool Equals([AllowNull] IQueryable expectedQuery, [AllowNull] IQueryable actualQuery)
        {
            var expectedEnumerator = expectedQuery.GetEnumerator();
            var actualEnumerator = actualQuery.GetEnumerator();

            //The first step is done manually, since we need to read type information
            bool expectedMoveNext = expectedEnumerator.MoveNext();
            bool actualMoveNext = actualEnumerator.MoveNext();

            //One set does not contain anything, return
            if(expectedMoveNext != actualMoveNext)
            {
                return false;
            }

            //None of the sets contain anything, they are equal
            if(!expectedMoveNext)
            {
                return true;
            }

            var expectedObj = expectedEnumerator.Current;
            var actualObj = actualEnumerator.Current;

            var expectedType = expectedObj.GetType();
            var actualType = actualObj.GetType();

            if (!CheckIfAnonymousType(expectedType))
            {
                throw new NotSupportedException("Only anonymous types can be used for the expected value");
            }

            if (!actualType.Equals(typeof(AnonType)))
            {
                throw new NotSupportedException("'Actual' queryables can only be from the executor");
            }

            var expectedProperties = expectedType.GetProperties();
            var actualProperties = actualType.GetProperties();

            List<(MethodInfo, MethodInfo)> propertyMethods = new List<(MethodInfo, MethodInfo)>();

            var actualMethodRestList = actualProperties.Select(x => x.GetGetMethod()).ToList();

            for(int i = 0; i < expectedProperties.Length; i++)
            {
                propertyMethods.Add((expectedProperties[i].GetGetMethod(), actualProperties[i].GetGetMethod()));
            }

            do
            {
                expectedObj = expectedEnumerator.Current;
                actualObj = actualEnumerator.Current;

                foreach(var propertyMethod in propertyMethods)
                {
                    if(!propertyMethod.Item1.Invoke(expectedObj, null).Equals(propertyMethod.Item2.Invoke(actualObj, null)))
                    {
                        return false;
                    }
                }
                //Check that all other properties are null
                for(int i = expectedProperties.Length; i < actualMethodRestList.Count; i++)
                {
                    if(actualMethodRestList[i].Invoke(actualObj, null) != null)
                    {
                        return false;
                    }
                }

            } while (expectedEnumerator.MoveNext() && actualEnumerator.MoveNext());

            //Check so there are no elements remaining on either side
            if (expectedEnumerator.MoveNext() != actualEnumerator.MoveNext())
                return false;

            return true;
        }

        public int GetHashCode([DisallowNull] IQueryable obj)
        {
            throw new NotImplementedException();
        }

        //https://stackoverflow.com/questions/2483023/how-to-test-if-a-type-is-anonymous
        private static bool CheckIfAnonymousType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            // HACK: The only way to detect anonymous types right now.
            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                && type.IsGenericType && type.Name.Contains("AnonymousType")
                && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                && type.Attributes.HasFlag(TypeAttributes.NotPublic);
        }
    }
}
