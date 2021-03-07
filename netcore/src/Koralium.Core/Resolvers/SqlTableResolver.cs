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
using Koralium.Core.Utils;
using Koralium.Interfaces;
using Koralium.Models;
using Koralium.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.Resolvers
{
    internal class SqlTableResolver : SqlToExpression.ISqlTableResolver
    {
        private readonly MetadataStore _metadataStore;
        public SqlTableResolver(MetadataStore metadataStore)
        {
            _metadataStore = metadataStore;
        }

        public async ValueTask<IQueryable> ResolveTableName(string name, object additionalData, IQueryOptions queryOptions)
        {
            if(!(additionalData is TableResolverData tableResolverData))
            {
                throw new Exception();
            }

            if(_metadataStore.TryGetTable(name, out var table))
            {
                await AuthorizationHelper.CheckAuthorization(tableResolverData.ServiceProvider, table.SecurityPolicy, tableResolverData.HttpContext);

                var resolver = (ITableResolver)tableResolverData.ServiceProvider.GetRequiredService(table.Resolver);

                return await resolver.GetQueryable(tableResolverData.HttpContext, queryOptions, tableResolverData.CustomMetadataStore);
            }
            else
            {
                //TODO: Fix exceptions
                throw new SqlErrorException($"Table {name} does not exist");
            }
        }
    }
}
