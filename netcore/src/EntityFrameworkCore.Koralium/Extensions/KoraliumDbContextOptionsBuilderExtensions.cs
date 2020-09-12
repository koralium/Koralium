using EntityFrameworkCore.Koralium.Infrastructure;
using EntityFrameworkCore.Koralium.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Extensions
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
