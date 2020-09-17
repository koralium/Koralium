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
using Koralium.WebTests;
using Koralium.WebTests.Entities.specific;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EntityFrameworkCore.Koralium.Tests.Db
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<AutoMapperCustomer> AutoMapperCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(opt =>
            {
                opt.ToTable("project")
                    .HasKey(x => x.Id);

                opt.Property(x => x.Company).IsObjectType();
            });

            modelBuilder.Entity<AutoMapperCustomer>(opt =>
            {
                opt.ToTable("automappercustomer")
                    .HasKey(x => x.Custkey);

                opt.Property(x => x.OrderKeys).IsArrayType();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
