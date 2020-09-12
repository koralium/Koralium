using Koralium.Core;
using Koralium.Core.Builders;
using Koralium.Core.Interfaces;
using Koralium.Core.Resolvers;
using Koralium.SqlToExpression;
using Koralium.SqlToExpression.Extensions;
using Koralium.SqlToExpression.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddKoralium(this IServiceCollection services, Action<IKoraliumBuilder> builder)
        {
            KoraliumBuilder koraliumBuilder = new KoraliumBuilder(services);
            builder?.Invoke(koraliumBuilder);

            services.AddSingleton(koraliumBuilder.Build());

            TablesMetadata tablesMetadata = new TablesMetadata();

            foreach(var table in koraliumBuilder.Tables)
            {
                tablesMetadata.AddTable(new TableMetadata(table.Name, table.EntityType));
            }

            services.AddSqlToExpression(tablesMetadata);
            services.AddScoped<KoraliumExecutor>();
            services.AddScoped<GrpcExecutor>();
            services.AddScoped<Koralium.SqlToExpression.ITableResolver, SqlTableResolver>();

            return services;
        }
    }
}
