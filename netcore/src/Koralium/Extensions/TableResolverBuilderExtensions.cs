﻿using Koralium.Interfaces;
using Koralium.SqlToExpression.Providers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TableResolverBuilderExtensions
    {
        public static ITableResolverBuilder<T> UseInMemoryCaseInsensitiveStringOperations<T>(this ITableResolverBuilder<T> tableResolverBuilder)
        {
            tableResolverBuilder.SetStringOperationsProvider(new CaseInsensitiveStringOperationsProvider());
            return tableResolverBuilder;
        }
    }
}