using Koralium.WebTests.Entities.tpch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Database
{
    /// <summary>
    /// This is a test context to test entity framework related issues
    /// </summary>
    public class TestContext : DbContext
    {
        private static bool _created = false;

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public TestContext(DbContextOptions<TestContext> dbContextOptions) 
            : base(dbContextOptions)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(x => x.Orderkey);

                //o.HasOne(x => x.Customer)
                //    .WithMany(x => x.Orders)
                //    .HasForeignKey(x => x.Custkey)
                //    .HasPrincipalKey(x => x.Custkey);
            });

            modelBuilder.Entity<Customer>(c =>
            {
                c.HasKey(x => x.Custkey);

                c.HasMany(x => x.Orders)
                    .WithOne(x => x.Customer)
                    .HasForeignKey(x => x.Custkey)
                    .HasPrincipalKey(x => x.Custkey);
            });

        }
    }
}
