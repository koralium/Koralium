using Koralium.Core.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.Core.Interfaces
{
    public interface ITableResolverBuilder<T>
    {
        string TableName { get; }

        ITableResolverBuilder<T> AddIndexResolver<Resolver, Key1>(
            Expression<Func<T, Key1>> property,
            string indexName = null) where Resolver : IndexResolver<T, Key1>;
    }
}
