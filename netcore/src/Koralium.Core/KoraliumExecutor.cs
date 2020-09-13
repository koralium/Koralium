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
using Koralium.Core.Models;
using Koralium.SqlToExpression;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Core
{
    public class KoraliumExecutor
    {
        private readonly SqlExecutor _sqlExecutor;
        private readonly IServiceProvider _serviceProvider;
        public KoraliumExecutor(SqlExecutor sqlExecutor, IServiceProvider serviceProvider)
        {
            _sqlExecutor = sqlExecutor;
            _serviceProvider = serviceProvider;
        }

        public ValueTask<QueryResult> Execute(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            return _sqlExecutor.Execute(sql, sqlParameters, new TableResolverData(httpContext, _serviceProvider));
        }

        public ValueTask<object> ExecuteScalar(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            return _sqlExecutor.ExecuteScalar(sql, sqlParameters, new TableResolverData(httpContext, _serviceProvider));
        }
    }
}
