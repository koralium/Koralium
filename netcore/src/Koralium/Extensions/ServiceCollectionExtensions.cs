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
using Koralium;
using Koralium.Builders;
using Koralium.Interfaces;
using Koralium.Resolvers;
using Koralium.SqlToExpression;
using Koralium.SqlToExpression.Extensions;
using Koralium.SqlToExpression.Metadata;
using System;
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
