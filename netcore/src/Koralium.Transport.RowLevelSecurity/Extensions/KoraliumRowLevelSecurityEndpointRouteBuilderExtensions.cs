using Koralium.Transport.RowLevelSecurity.Services;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Builder
{
    public static class KoraliumRowLevelSecurityEndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapKoraliumRowLevelSecurityEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder.MapGrpcService<RowLevelSecurityService>();
        }
    }
}
