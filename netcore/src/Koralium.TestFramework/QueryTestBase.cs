using EntityFrameworkCore.Koralium.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
