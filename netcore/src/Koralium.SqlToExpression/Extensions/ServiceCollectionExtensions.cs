using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Executors.Offset;
using Koralium.SqlToExpression.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlToExpression(this IServiceCollection services, TablesMetadata tablesMetadata)
        {
            services.AddSingleton(tablesMetadata);

            services.AddScoped<IQueryExecutor, QueryExecutor>();
            services.AddSingleton<IFromTableExecutorFactory, DefaultFromTableExecutorFactory>();
            services.AddSingleton<IWhereExecutorFactory, DefaultWhereExecutorFactory>();
            services.AddSingleton<IGroupByExecutorFactory, DefaultGroupByExecutorFactory>();
            services.AddSingleton<ISelectExecutorFactory, DefaultSelectExecutorFactory>();
            services.AddSingleton<IOrderByExecutorFactory, DefaultOrderByExecutorFactory>();
            services.AddSingleton<IOffsetExecutorFactory, DefaultOffsetExecutorFactory>();
            services.AddSingleton<IDistinctExecutorFactory, DefaultDistinctExecutorFactory>();

            services.AddScoped<SqlExecutor>();

            return services;
        }
    }
}
