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
using Koralium.Shared;
using Koralium.SqlToExpression.Interfaces;
using Koralium.SqlToExpression.Metadata;
using System.Diagnostics;

namespace Koralium.SqlToExpression.Visitors
{
    internal class VisitorMetadata
    {
        public SqlParameters Parameters { get; }

        public TablesMetadata TablesMetadata { get; }

        public ISearchExpressionProvider SearchExpressionProvider { get; }

        public IOperationsProvider OperationsProvider { get; set; }

        public VisitorMetadata(
            SqlParameters sqlParameters, 
            TablesMetadata tablesMetadata, 
            ISearchExpressionProvider searchExpressionProvider,
            IOperationsProvider operationsProvider)
        {
            Debug.Assert(tablesMetadata != null);

            if(sqlParameters != null)
            {
                Parameters = sqlParameters;
            }
            else
            {
                Parameters = new SqlParameters();
            }
            TablesMetadata = tablesMetadata;
            SearchExpressionProvider = searchExpressionProvider;
            OperationsProvider = operationsProvider;
        }
    }
}
