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
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Koralium.TestFramework
{
    public abstract class QueryTestBase<TEntity> where TEntity : class
    {
        public abstract string TableName { get; }

        protected IServiceProvider ServiceProvider { get; private set; }

        protected TestDbContext<TEntity> Context => ServiceProvider.GetRequiredService<TestDbContext<TEntity>>();

        public abstract string GetTestWebUrl();

        [OneTimeSetUp]
        public void OnSetup_Internal()
        {
            

            ServiceCollection services = new ServiceCollection();

            OnSetup(services);

            services.AddSingleton(new TestContextSettings()
            {
                TableName = TableName,
                Url = GetTestWebUrl()
            });
            services.AddDbContext<TestDbContext<TEntity>>();
            
            ServiceProvider = services.BuildServiceProvider();
        }

        [OneTimeTearDown]
        public void OnTeardown_Internal()
        {
            OnTeardown();
        }

        protected void SetAccessToken(string accessToken)
        {
            ServiceProvider.GetService<TestContextSettings>().AccessToken = accessToken;
        }

        protected virtual void OnSetup(IServiceCollection services)
        {
            
        }

        protected virtual void OnTeardown()
        {

        }
    }
}
