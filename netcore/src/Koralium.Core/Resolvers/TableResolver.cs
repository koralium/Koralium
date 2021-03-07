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
using Koralium.SqlParser.Expressions;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium
{
    public abstract class TableResolver<T> : ITableResolver
    {
        protected HttpContext HttpContext { get; private set; }

        protected abstract Task<IQueryable<T>> GetQueryableData(IQueryOptions<T> queryOptions, ICustomMetadata customMetadata);

        /// <summary>
        /// Override to create an expression given the current user in the http context that will limit the users visibility.
        /// 
        /// This does not contain query information since it can be called standalone without a query.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        protected virtual Task ApplyRowLevelSecurity(RowLevelSecurityContext<T> context)
        {
            return Task.CompletedTask;
        }

        async Task<BooleanExpression> ITableResolver.GetRowLevelSecurity(HttpContext httpContext)
        {
            HttpContext = httpContext;

            //Create the builder
            var builder = RowLevelSecurityContext.Create<T>();

            //Allow user to add their expressions
            await ApplyRowLevelSecurity(builder);

            //Build the sql tree with the expressions
            return builder.Build();
        }

        async Task<IQueryable> ITableResolver.GetQueryable(HttpContext httpContext, IQueryOptions queryOptions, ICustomMetadata customMetadataStore)
        {
            var genericQueryOptions = queryOptions.CreateGeneric<T>();
            HttpContext = httpContext;
            return await GetQueryableData(genericQueryOptions, customMetadataStore);
        }
    }
}
