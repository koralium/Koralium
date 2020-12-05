using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Extensions
{
    public static class KoraliumFlightEndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapKoraliumArrowFlight(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder.MapFlightEndpoint();
        }
    }
}
