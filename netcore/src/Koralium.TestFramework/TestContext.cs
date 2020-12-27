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
using EntityFrameworkCore.Koralium.Extensions;
using Microsoft.EntityFrameworkCore;

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
