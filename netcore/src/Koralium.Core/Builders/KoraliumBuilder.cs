using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Core.Resolvers;
using Koralium.Core.Utils;
using Koralium.Grpc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Koralium.Core.Builders
{
    public class KoraliumBuilder : IKoraliumBuilder
    {
        private readonly Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup = new Dictionary<Type, IReadOnlyList<TableColumn>>();
        private readonly ImmutableList<KoraliumTable>.Builder tables = ImmutableList.CreateBuilder<KoraliumTable>();
        private int tableIdCounter = 0;

        public IServiceCollection Services { get; }

        internal ImmutableList<KoraliumTable> Tables => tables.ToImmutable();

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

            var tableMetadata = new TableMetadata()
            {
                Name = opt.TableName,
                TableId = tableIdCounter++
            };

            foreach (var index in opt.Indicies)
            {
                tableMetadata.Indicies.Add(index.IndexMetadata);
                Services.AddScoped(index.Resolver);
            }

            foreach (var column in columns)
            {
                tableMetadata.Columns.Add(column.Metadata);
            }

            tables.Add(new KoraliumTable(tableMetadata, tableMetadata.TableId, opt.TableName, typeof(Resolver), typeof(T), columns, securityPolicy, opt.Indicies));

            return this;
        }

        internal MetadataStore Build()
        {
            return new MetadataStore(tables.ToImmutable(), typeLookup);
        }
    }
}
