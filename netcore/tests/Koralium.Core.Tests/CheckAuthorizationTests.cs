using Koralium.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Core.Tests
{
    public class CheckAuthorizationTests
    {
        [Test]
        public void TestMissingPolicy()
        {
            Mock<IAuthorizationPolicyProvider> authorizationPolicyMock = new Mock<IAuthorizationPolicyProvider>();

            authorizationPolicyMock.Setup(x => x.GetPolicyAsync(It.IsAny<string>()))
                .Returns(() =>
                {
                    return Task.FromResult<AuthorizationPolicy>(null);
                });

            Mock<IAuthorizationHandlerProvider> authorizationHandlerMock = new Mock<IAuthorizationHandlerProvider>();
            Mock<HttpContext> httpContextMock = new Mock<HttpContext>();
            
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton(authorizationPolicyMock.Object);
            services.AddSingleton(authorizationHandlerMock.Object);

            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await AuthorizationHelper.CheckAuthorization(services.BuildServiceProvider(), "test", httpContextMock.Object),
                "No security policy found named 'test'."
                );
        }
    }
}
