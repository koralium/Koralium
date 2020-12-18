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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium
{
    public abstract class TableResolver<T> : ITableResolver
    {
        private ICustomMetadataStore _customMetadataStore;

        protected HttpContext HttpContext { get; private set; }

        protected IQueryOptions<T> QueryOptions { get; private set; }

        /// <summary>
        /// Add custom metadata that will be returned to the caller
        /// 
        /// This is useful to provide information such as total results if that is already collected from the backend database.
        /// </summary>
        /// <typeparam name="T">Must be a primitive or string</typeparam>
        /// <param name="name">Name of the custom metadata</param>
        /// <param name="value">The value of the custom metadata</param>
        protected void AddCustomMetadata<T>(string name, T value)
        {
            _customMetadataStore.AddMetadata<T>(name, value);
        }

        public async Task<IQueryable> GetQueryable(
            HttpContext httpContext, 
            IQueryOptions queryOptions,
            ICustomMetadataStore customMetadataStore)
        {
            var genericQueryOptions = queryOptions.CreateGeneric<T>();
            HttpContext = httpContext;
            QueryOptions = genericQueryOptions;
            _customMetadataStore = customMetadataStore;
            return await GetQueryableData();
        }

        protected abstract Task<IQueryable<T>> GetQueryableData();
    }
}
