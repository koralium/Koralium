using Koralium.Core.Builders;
using Koralium.Core.Interfaces;
using Koralium.Grpc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class KoraliumBuilderExtensions
    {
        public static IKoraliumBuilder AddGrpc(this IKoraliumBuilder koraliumBuilder)
        {
            koraliumBuilder.Services.AddSingleton(new KoraliumGrpcStore());
            //koraliumBuilder.Services.AddScoped<GrpcExecutor>();
            return koraliumBuilder;
        }
    }
}
