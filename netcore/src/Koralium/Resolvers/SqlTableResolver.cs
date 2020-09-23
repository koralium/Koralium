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
using Grpc.Core;
using Koralium.Interfaces;
using Koralium.Metadata;
using Koralium.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

        public async ValueTask<IQueryable> ResolveTableName(string name, object additionalData, SqlToExpression.IQueryOptions queryOptions)
        {
            if(!(additionalData is TableResolverData tableResolverData))
            {
                throw new Exception();
            }

            if(_metadataStore.TryGetTable(name, out var table))
            {
                await CheckAuthorization(tableResolverData.ServiceProvider, table.SecurityPolicy, tableResolverData.HttpContext);

                var resolver = (ITableResolver)tableResolverData.ServiceProvider.GetRequiredService(table.Resolver);

                return await resolver.GetQueryable(tableResolverData.HttpContext, queryOptions, tableResolverData.ExtraData, tableResolverData.CustomMetadataStore);
            }
            else
            {
                //TODO: Fix exceptions
                throw new Exception();
            }
        }

        private async Task CheckAuthorization(IServiceProvider serviceProvider, string securityPolicy, HttpContext context)
        {
            //Check authentication and authorization
            if (securityPolicy != null)
            {
                var authorizationPolicyProvider = serviceProvider.GetRequiredService<IAuthorizationPolicyProvider>();
                var authorizationHandlerProvider = serviceProvider.GetRequiredService<IAuthorizationHandlerProvider>();
                var user = context.User;
                AuthorizationPolicy policy = null;
                if (securityPolicy.Equals("default"))
                {
                    policy = await authorizationPolicyProvider.GetDefaultPolicyAsync();
                }
                else
                {
                    policy = await authorizationPolicyProvider.GetPolicyAsync(securityPolicy);
                }
                var authContext = new AuthorizationHandlerContext(policy.Requirements, user, null);
                var authHandlers = await authorizationHandlerProvider.GetHandlersAsync(authContext);

                foreach (var authHandler in authHandlers)
                {
                    await authHandler.HandleAsync(authContext);
                }
                if (!authContext.HasSucceeded)
                {
                    throw new RpcException(new Status(StatusCode.Unauthenticated, "Authorization failed"));
                }
            }
        }
    }
}
