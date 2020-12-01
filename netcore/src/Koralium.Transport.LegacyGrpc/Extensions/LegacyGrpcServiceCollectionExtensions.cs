﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.LegacyGrpc.Extensions
{
    public static class LegacyGrpcServiceCollectionExtensions
    {
        public static IServiceCollection AddKoraliumLegacyGrpcTransport(this IServiceCollection services)
        {
            services.AddScoped<LegacyGrpcExecutor>();

            return services;
        }
    }
}