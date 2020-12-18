using Koralium.Interfaces;
using Koralium.Models;
using Koralium.Resolvers;
using Koralium.Shared;
using Koralium.SqlParser;
using Koralium.SqlToExpression;
using Koralium.Transport;
using Koralium.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Koralium
{
    class KoraliumTransportService : IKoraliumTransportService
    {
        private readonly SqlExecutor _sqlExecutor;
        private readonly IServiceProvider _serviceProvider;
        private readonly MetadataStore _metadataStore;
        private readonly ISqlParser _sqlParser;
        public KoraliumTransportService(
            SqlExecutor sqlExecutor, 
            IServiceProvider serviceProvider, 
            MetadataStore metadataStore,
            ISqlParser sqlParser)
        {
            _sqlExecutor = sqlExecutor;
            _serviceProvider = serviceProvider;
            _metadataStore = metadataStore;
            _sqlParser = sqlParser;
        }

        private Transport.Column GetTransportColumn(TableColumn tableColumn)
        {
            var childrenList = ImmutableList.CreateBuilder<Transport.Column>();
            if(tableColumn.Children != null)
            {
                foreach(var child in tableColumn.Children)
                {
                    childrenList.Add(GetTransportColumn(child));
                }
            }
            var (columnType, nullable) = ColumnTypeHelper.GetKoraliumType(tableColumn.ColumnType);
            return new Transport.Column(tableColumn.Name, tableColumn.ColumnType, tableColumn.PropertyAccessor, childrenList.ToImmutable(), columnType, nullable);
        }

        public async ValueTask<Transport.QueryResult> Execute(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            CustomMetadataStore customMetadataStore = new CustomMetadataStore();
            var result = await _sqlExecutor.Execute(sql, sqlParameters, new TableResolverData(
                httpContext, 
                _serviceProvider, 
                customMetadataStore)).ConfigureAwait(false);

            var columnsBuilder = ImmutableList.CreateBuilder<Transport.Column>();
            foreach(var column in result.Columns)
            {
                if (!_metadataStore.TryGetTypeColumns(column.Type, out var columns))
                {
                    columns = new List<TableColumn>();
                }

                var childrenList = ImmutableList.CreateBuilder<Transport.Column>();
                foreach (var child in columns)
                {
                    childrenList.Add(GetTransportColumn(child));
                }

                var (columnType, nullable) = ColumnTypeHelper.GetKoraliumType(column.Type);
                columnsBuilder.Add(new Transport.Column(column.Name, column.Type, column.GetFunction, childrenList.ToImmutable(), columnType, nullable));
            }

            return new Transport.QueryResult(
                result.Result, 
                columnsBuilder.ToImmutable(), 
                customMetadataStore.GetMetadataValues().Select(x => new KeyValuePair<string, string>(x.Key, x.Value.ToString()))
                );
        }

        public ValueTask<object> ExecuteScalar(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            CustomMetadataStore customMetadataStore = new CustomMetadataStore();

            return _sqlExecutor.ExecuteScalar(sql, sqlParameters, new TableResolverData(
                httpContext,
                _serviceProvider,
                customMetadataStore));
        }


        public async Task<Transport.TransportPartitionsResult> GetPartitions(bool canHandlePartitions, string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            var sqlTree = _sqlParser.Parse(sql, out var errors);

            if(errors.Count > 0)
            {
                throw new SqlErrorException(errors.First().Message);
            }

            var schema = _sqlExecutor.GetSchema(sqlTree, sqlParameters);

            //Take table name and get the partition resolver
            if(!_metadataStore.TryGetTable(schema.TableName, out var table))
            {
                throw new SqlErrorException($"The table {schema.TableName} was not found.");
            }

            //Get the partitions
            var discoveryService = _serviceProvider.GetService<IDiscoveryService>();
            var partitionsBuilder = new PartitionsBuilder(sqlTree);
            var partitions = await table.PartitionResolver.GetPartitions(canHandlePartitions, partitionsBuilder, httpContext, new PartitionOptions(_serviceProvider, discoveryService));

            var partitionListBuilder = ImmutableList.CreateBuilder<Transport.TransportPartition>();

            foreach(var partition in partitions)
            {
                List<TransportServiceLocation> locations = new List<TransportServiceLocation>(); 
                foreach(var location in partition.Locations)
                {
                    locations.Add(new TransportServiceLocation(location.Host, location.Tls));
                }
                partitionListBuilder.Add(new Transport.TransportPartition(locations, partition.SqlTree.Print()));
            }

            return new Transport.TransportPartitionsResult(ConvertColumns(schema.Columns), partitionListBuilder.ToImmutable());
        }

        private IImmutableList<Transport.Column> ConvertColumns(IImmutableList<ColumnMetadata> columnMetadatas)
        {
            var columnsBuilder = ImmutableList.CreateBuilder<Transport.Column>();
            foreach (var column in columnMetadatas)
            {
                if (!_metadataStore.TryGetTypeColumns(column.Type, out var columns))
                {
                    columns = new List<TableColumn>();
                }

                var childrenList = ImmutableList.CreateBuilder<Transport.Column>();
                foreach (var child in columns)
                {
                    childrenList.Add(GetTransportColumn(child));
                }

                var (columnType, nullable) = ColumnTypeHelper.GetKoraliumType(column.Type);
                columnsBuilder.Add(new Transport.Column(column.Name, column.Type, column.GetFunction, childrenList.ToImmutable(), columnType, nullable));
            }

            return columnsBuilder.ToImmutable();
        }

        public IImmutableList<Transport.Column> GetSchema(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            var resultColumns = _sqlExecutor.GetSchema(sql, sqlParameters).Columns;

            return ConvertColumns(resultColumns);
        }

        public IImmutableList<Table> GetTables()
        {
            var builder = ImmutableList.CreateBuilder<Table>();
            foreach(var table in _metadataStore.Tables)
            {
                builder.Add(new Table(table.Name));
            }
            return builder.ToImmutable();
        }
    }
}
