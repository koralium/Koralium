using Koralium.Interfaces;
using Koralium.Shared;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Statements;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Core.RowLevelSecurity
{
    internal static class RowLevelSecurityHelper
    {
        public static Task<BooleanExpression> GetRowLevelSecurityQuery(string tableName, HttpContext httpContext, MetadataStore metadataStore, IServiceProvider serviceProvider)
        {
            if(!metadataStore.TryGetTable(tableName, out var table))
            {
                throw new SqlErrorException($"Table {tableName} does not exist.");
            }

            var resolver = (ITableResolver)serviceProvider.GetRequiredService(table.Resolver);

            return resolver.GetRowLevelSecurity(httpContext);
        }

        public static async Task ApplyRowLevelSecurity(StatementList statementList, HttpContext httpContext, MetadataStore metadataStore, IServiceProvider serviceProvider)
        {
            var tableFinder = new TableLocatorVisitor();
            tableFinder.Visit(statementList);
            string tableName = tableFinder.TableName;

            if (tableName == null)
            {
                throw new SqlErrorException("Could not find any table in the select statement");
            }

            var filter = await GetRowLevelSecurityQuery(tableName, httpContext, metadataStore, serviceProvider);

            if (filter == null)
            {
                return;
            }

            LocateFilterVisitor locateFilterVisitor = new LocateFilterVisitor(filter);
            locateFilterVisitor.Visit(statementList);

            // Check if the filter is already applied on the query, if so, do nothing
            if (locateFilterVisitor.Exists)
            {
                return;
            }

            var addFilterVisitor = new AddFilterVisitor(filter);
            addFilterVisitor.Visit(statementList);
        }
    }
}
