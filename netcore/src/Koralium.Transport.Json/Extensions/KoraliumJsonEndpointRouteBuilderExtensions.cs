
using Koralium.Transport.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.Builder
{
    public static class KoraliumJsonEndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapKoraliumJsonPost(this IEndpointRouteBuilder endpointRouteBuilder, string pattern)
        {
            return endpointRouteBuilder.MapPost(pattern, JsonExecutor.PostMethod);
        }

        public static IEndpointConventionBuilder MapKoraliumJsonGet(this IEndpointRouteBuilder endpointRouteBuilder, string pattern)
        {
            return endpointRouteBuilder.MapGet(pattern, JsonExecutor.GetMethod);
        }
    }
}
