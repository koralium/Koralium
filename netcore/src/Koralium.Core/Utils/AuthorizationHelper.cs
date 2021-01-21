using Grpc.Core;
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
                    throw new RpcException(new Status(StatusCode.Unauthenticated, "Authorization failed"));
                }
            }
        }
    }
}
