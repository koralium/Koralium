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
using Koralium.WebTests.Entities.tpch;
using Microsoft.EntityFrameworkCore;

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
