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
