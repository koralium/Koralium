using Koralium.WebTests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Tests.Db
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(opt =>
            {
                opt.ToTable("project")
                    .HasKey(x => x.Id);

                opt.Property(x => x.Company).IsObjectType();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
