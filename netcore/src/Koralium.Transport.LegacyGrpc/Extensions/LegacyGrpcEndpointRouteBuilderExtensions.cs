using Koralium.Transport.LegacyGrpc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System.Text;

namespace Koralium.Transport.LegacyGrpc.Extensions
{
    public static class LegacyGrpcEndpointRouteBuilderExtensions
    {
        public static GrpcServiceEndpointConventionBuilder AddKoraliumLegacyGrpcEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder.MapGrpcService<LegacyGrpcService>();
        }
    }
}
