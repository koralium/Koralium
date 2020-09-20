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
using Koralium.Interfaces;
using Koralium.SqlToExpression;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium
{
    public abstract class TableResolver<T> : ITableResolver
    {
        protected HttpContext HttpContext { get; private set; }

        protected IQueryOptions<T> QueryOptions { get; private set; }

        public async Task<IQueryable> GetQueryable(HttpContext httpContext, IQueryOptions queryOptions)
        {
            var genericQueryOptions = queryOptions.CreateGeneric<T>();
            HttpContext = httpContext;
            QueryOptions = genericQueryOptions;
            return await GetQueryableData();
        }

        protected abstract Task<IQueryable<T>> GetQueryableData();
    }
}
