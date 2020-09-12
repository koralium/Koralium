using Koralium.Core.Metadata;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Koralium.Core.Services;

namespace Microsoft.AspNetCore.Builder
{
    public static class EndpointRouteBuilderExtensions
    {
        public static GrpcServiceEndpointConventionBuilder AddKoraliumGrpcEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder.MapGrpcService<KoraliumGrpcService>();
        }
    }
}
