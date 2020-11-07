using EntityFrameworkCore.Koralium.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.TestFramework
{
    public class TestDbContext<TEntity> : DbContext where TEntity: class
    {
        private readonly TestContextSettings _testContextSettings;
        public DbSet<TEntity> Entities { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext<TEntity>> options, TestContextSettings testContextSettings) : base(options)
        {
            _testContextSettings = testContextSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Data.Koralium.KoraliumConnectionStringBuilder koraliumConnectionStringBuilder = new Data.Koralium.KoraliumConnectionStringBuilder();
            koraliumConnectionStringBuilder.DataSource = _testContextSettings.Url;
            if(_testContextSettings.AccessToken != null)
            {
                koraliumConnectionStringBuilder.AccessToken = _testContextSettings.AccessToken;
            }

            optionsBuilder.UseKoralium(koraliumConnectionStringBuilder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEntity>(opt =>
            {
                opt.ToTable(_testContextSettings.TableName)
                    .HasNoKey();
            });
        }
    }
}
