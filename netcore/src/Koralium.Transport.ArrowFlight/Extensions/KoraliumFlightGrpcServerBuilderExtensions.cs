using Grpc.AspNetCore.Server;
using Koralium.Transport.ArrowFlight;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.Json.Extensions
{
    public static class KoraliumFlightGrpcServerBuilderExtensions
    {
        public static IGrpcServerBuilder AddKoraliumFlightServer(this IGrpcServerBuilder grpcServerBuilder)
        {
            grpcServerBuilder.AddFlightServer<KoraliumFlightServer>();
            return grpcServerBuilder;
        }
    }
}
