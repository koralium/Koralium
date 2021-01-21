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
        public static Task<BooleanExpression> GetRowLevelSecurityQuery(
            string tableName, 
            HttpContext httpContext, 
            MetadataStore metadataStore, 
            IServiceProvider serviceProvider, 
            string tableAlias = null)
        {
            if(!metadataStore.TryGetTable(tableName, out var table))
            {
                throw new SqlErrorException($"Table {tableName} does not exist.");
            }

            return GetRowLevelSecurityQuery(table, httpContext, metadataStore, serviceProvider, tableAlias);
        }

        public static async Task<BooleanExpression> GetRowLevelSecurityQuery(
            KoraliumTable table,
            HttpContext httpContext,
            MetadataStore metadataStore,
            IServiceProvider serviceProvider,
            string tableAlias = null)
        {
            var resolver = (ITableResolver)serviceProvider.GetRequiredService(table.Resolver);

            var filter = await resolver.GetRowLevelSecurity(httpContext);

            //If there is a filter and table alias is set, add the tableAlias in front of all columns
            if (filter != null && !string.IsNullOrEmpty(tableAlias))
            {
                var visitor = new AddAliasVisitor(tableAlias);
                visitor.Visit(filter);
            }

            return filter;
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

            var filter = await GetRowLevelSecurityQuery(tableName, httpContext, metadataStore, serviceProvider, tableFinder.Alias);

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
