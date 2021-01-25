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
using Koralium.SqlParser.Expressions;
using Microsoft.AspNetCore.Http;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Koralium.Transport
{
    /// <summary>
    /// Service that transport protocols can use to talk with Koralium core
    /// </summary>
    public interface IKoraliumTransportService
    {
        ValueTask<QueryResult> Execute(
            string sql,
            SqlParameters sqlParameters,
            HttpContext httpContext);

        ValueTask<object> ExecuteScalar(
            string sql,
            SqlParameters sqlParameters,
            HttpContext httpContext);

        IImmutableList<Column> GetSchema(
            string sql,
            SqlParameters sqlParameters,
            HttpContext httpContext);

        IImmutableList<Table> GetTables();

        Task<TransportPartitionsResult> GetPartitions(bool canHandlePartitions, string sql, SqlParameters sqlParameters, HttpContext httpContext);

        /// <summary>
        /// Retrieves the filter that should be applied to a query based on the current user
        /// </summary>
        /// <param name="tableName">The table to retrieve the filters for</param>
        /// <returns></returns>
        Task<BooleanExpression> GetTableRowLevelSecurityFilter(string tableName, string tableAlias, HttpContext httpContext);
    }
}
