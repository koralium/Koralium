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
using Koralium.SqlToExpression.Interfaces;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression
{
    /// <summary>
    /// This interface allows for specific implementations of full text search
    /// </summary>
    public interface ISearchExpressionProvider
    {
        /// <summary>
        /// Returns the expression that implements the functionality of full text search
        /// </summary>
        /// <returns></returns>
        Expression GetSearchExpression(ISearchParameters searchParameters);
    }
}
