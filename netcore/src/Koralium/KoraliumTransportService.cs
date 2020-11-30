using Koralium.Metadata;
using Koralium.Models;
using Koralium.Shared;
using Koralium.SqlToExpression;
using Koralium.Transport;
using Koralium.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koralium
{
    class KoraliumTransportService : IKoraliumTransportService
    {
        private readonly SqlExecutor _sqlExecutor;
        private readonly IServiceProvider _serviceProvider;
        private readonly MetadataStore _metadataStore;
        public KoraliumTransportService(SqlExecutor sqlExecutor, IServiceProvider serviceProvider, MetadataStore metadataStore)
        {
            _sqlExecutor = sqlExecutor;
            _serviceProvider = serviceProvider;
            _metadataStore = metadataStore;
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
            return new Transport.Column(tableColumn.Name, tableColumn.ColumnType, tableColumn.PropertyAccessor, childrenList.ToImmutable(), ColumnTypeHelper.GetKoraliumType(tableColumn.ColumnType));
        }

        public async ValueTask<Transport.QueryResult> Execute(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            CustomMetadataStore customMetadataStore = new CustomMetadataStore();
            var result = await _sqlExecutor.Execute(sql, sqlParameters, new TableResolverData(
                httpContext, 
                _serviceProvider, 
                new Dictionary<string, object>(), 
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

                columnsBuilder.Add(new Transport.Column(column.Name, column.Type, column.GetFunction, childrenList.ToImmutable(), ColumnTypeHelper.GetKoraliumType(column.Type)));
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
                new Dictionary<string, object>(),
                customMetadataStore));
        }

        public IImmutableList<Transport.Column> GetSchema(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            var resultColumns = _sqlExecutor.GetSchema(sql, sqlParameters);

            var columnsBuilder = ImmutableList.CreateBuilder<Transport.Column>();
            foreach (var column in resultColumns)
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

                columnsBuilder.Add(new Transport.Column(column.Name, column.Type, column.GetFunction, childrenList.ToImmutable(), ColumnTypeHelper.GetKoraliumType(column.Type)));
            }

            return columnsBuilder.ToImmutable();
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
