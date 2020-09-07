using Koralium.Core.Metadata;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Koralium.Grpc.Models;
using System.Linq;
using Koralium.Grpc.Extensions;

namespace Microsoft.AspNetCore.Builder
{
    public static class EndpointRouteBuilderExtensions
    {
        public static GrpcServiceEndpointConventionBuilder AddKoraliumGrpcEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var metadataStore = endpointRouteBuilder.ServiceProvider.GetService<MetadataStore>();
            var grpcStore = endpointRouteBuilder.ServiceProvider.GetService<KoraliumGrpcStore>();

            grpcStore.TableMetadataResponse = metadataStore.ToTableMetadataResponse();

            return null; // endpointRouteBuilder.MapGrpcService<KoraliumGrpcService>();
        }
    }
}
