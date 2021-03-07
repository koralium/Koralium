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
using Koralium.Transport.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Core.Utils
{
    internal static class AuthorizationHelper
    {
        public static async Task CheckAuthorization(IServiceProvider serviceProvider, string securityPolicy, HttpContext context)
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
                    throw new AuthorizationFailedException("Authorization failed");
                }
            }
        }
    }
}
