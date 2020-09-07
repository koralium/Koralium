using Koralium.Core.Resolvers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Interfaces
{
    public interface IKoraliumBuilder
    {
        IKoraliumBuilder AddTableResolver<Resolver, T>(Action<ITableResolverBuilder<T>> options = null)
            where Resolver : TableResolver<T>;

        IServiceCollection Services { get; }
    }
}
