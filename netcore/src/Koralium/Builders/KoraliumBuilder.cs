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
using Koralium.Interfaces;
using Koralium.Metadata;
using Koralium.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Koralium.SqlToExpression;

namespace Koralium.Builders
{
    public class KoraliumBuilder : IKoraliumBuilder
    {
        private readonly Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup = new Dictionary<Type, IReadOnlyList<TableColumn>>();
        private readonly ImmutableList<KoraliumTable>.Builder tables = ImmutableList.CreateBuilder<KoraliumTable>();
        private int tableIdCounter = 0;

        public IServiceCollection Services { get; }

        internal ImmutableList<KoraliumTable> Tables => tables.ToImmutable();

        internal Type SearchProviderType { get; set; }

        internal KoraliumBuilder(IServiceCollection services)
        {
            Services = services;
        }

        

        public IKoraliumBuilder AddTableResolver<Resolver, T>(Action<ITableResolverBuilder<T>> options = null) 
            where Resolver : TableResolver<T>
        {
            var columns = MetadataHelper.CollectMetadata(typeof(T), typeLookup);

            TableResolverBuilder<T> opt = new TableResolverBuilder<T>(columns);

            options?.Invoke(opt);

            if (opt.TableName == null)
            {
                opt.TableName = MetadataHelper.CreateTableName(typeof(T));
            }

            var securityPolicy = MetadataHelper.GetSecurityPolicy<Resolver, T>();

            Services.AddScoped<Resolver>();

            tables.Add(new KoraliumTable(
                opt.TableName, 
                typeof(Resolver), 
                typeof(T), 
                columns, 
                securityPolicy, 
                opt.Indicies,
                opt.StringOperationsProvider));

            return this;
        }

        internal MetadataStore Build()
        {
            return new MetadataStore(tables.ToImmutable(), typeLookup);
        }

        public IKoraliumBuilder AddSearchProvider<T>() where T : ISearchExpressionProvider
        {
            SearchProviderType = typeof(T);
            return this;
        }
    }
}
