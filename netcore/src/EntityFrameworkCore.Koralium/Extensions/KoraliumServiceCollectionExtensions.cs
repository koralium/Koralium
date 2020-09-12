using EntityFrameworkCore.Koralium.Diagnostics.Internal;
using EntityFrameworkCore.Koralium.Infrastructure.Internal;
using EntityFrameworkCore.Koralium.Query.Internal;
using EntityFrameworkCore.Koralium.Storage.Internal;
using EntityFrameworkCore.Koralium.Update.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class KoraliumServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkKoralium(this IServiceCollection serviceCollection)
        {
            var builder = new EntityFrameworkRelationalServicesBuilder(serviceCollection)
                .TryAdd<LoggingDefinitions, KoraliumLoggingDefinitions>()
                .TryAdd<IDatabaseProvider, DatabaseProvider<KoraliumOptionsExtension>>()
                .TryAdd<IRelationalTypeMappingSource, KoraliumTypeMappingSource>()
                .TryAdd<ISqlGenerationHelper, KoraliumSqlGenerationHelper>()
                .TryAdd<IModificationCommandBatchFactory, KoraliumModificationCommandBatchFactory>()
                .TryAdd<IUpdateSqlGenerator, KoraliumUpdateSqlGenerator>()
                .TryAdd<IQuerySqlGeneratorFactory, KoraliumQuerySqlGeneratorFactory>()
                .TryAdd<IQueryableMethodTranslatingExpressionVisitorFactory, KoraliumQueryableMethodTranslatingExpressionVisitorFactory>()
                .TryAdd<IRelationalConnection, KoraliumRelationalConnection>()

                //New query pipeline
                .TryAdd<IRelationalSqlTranslatingExpressionVisitorFactory, KoraliumSqlTranslatingExpressionVisitorFactory>();

            builder.TryAddCoreServices();

            return serviceCollection;
        }
    }
}
