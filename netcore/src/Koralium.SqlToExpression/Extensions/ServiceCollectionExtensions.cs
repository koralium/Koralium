/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Executors.AggregateFunction;
using Koralium.SqlToExpression.Executors.Offset;
using Koralium.SqlToExpression.Interfaces;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Providers;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddSingleton<ISearchExpressionProvider, DefaultSearchExpressionProvider>();
            services.AddSingleton<IStringOperationsProvider, DefaultStringOperationsProvider>();
            services.AddSingleton<IAggregateFunctionExecutorFactory, DefaultAggregateFunctionFactory>();

            services.AddScoped<SqlExecutor>();

            return services;
        }
    }
}
