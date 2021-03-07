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
using Koralium.EntityFrameworkCore.ArrowFlight.Infrastructure;
using Koralium.EntityFrameworkCore.ArrowFlight.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Microsoft.EntityFrameworkCore
{
    public static class KoraliumDbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseKoralium(
           this DbContextOptionsBuilder optionsBuilder,
           Action<KoraliumDbContextOptionsBuilder> prestoOptionsAction = null)
        {

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(GetOrCreateExtension(optionsBuilder));

            prestoOptionsAction?.Invoke(new KoraliumDbContextOptionsBuilder(optionsBuilder));

            return optionsBuilder;
        }

        public static DbContextOptionsBuilder UseKoralium(
              this DbContextOptionsBuilder optionsBuilder,
              string connectionString,
            Action<KoraliumDbContextOptionsBuilder> sqliteOptionsAction = null)
        {
            var extension = (KoraliumOptionsExtension)GetOrCreateExtension(optionsBuilder).WithConnectionString(connectionString);
            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            sqliteOptionsAction?.Invoke(new KoraliumDbContextOptionsBuilder(optionsBuilder));

            return optionsBuilder;
        }

        private static KoraliumOptionsExtension GetOrCreateExtension(DbContextOptionsBuilder options)
            => options.Options.FindExtension<KoraliumOptionsExtension>()
                ?? new KoraliumOptionsExtension();
    }
}
