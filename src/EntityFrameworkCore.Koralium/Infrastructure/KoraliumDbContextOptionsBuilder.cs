using EntityFrameworkCore.Koralium.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Infrastructure
{
    public class KoraliumDbContextOptionsBuilder : RelationalDbContextOptionsBuilder<KoraliumDbContextOptionsBuilder, KoraliumOptionsExtension>
    {
        public KoraliumDbContextOptionsBuilder(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder)
        {
        }
    }
}
