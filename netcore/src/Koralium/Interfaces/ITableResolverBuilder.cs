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
using System;
using System.Linq.Expressions;

namespace Koralium.Interfaces
{
    public interface ITableResolverBuilder<T>
    {
        string TableName { get; set; }

        ITableResolverBuilder<T> AddIndexResolver<Resolver, Key1>(
            Expression<Func<T, Key1>> property,
            string indexName = null) where Resolver : IndexResolver<T, Key1>;

        ITableResolverBuilder<T> AddIndexResolver<Resolver, Key1, Key2>(
            Expression<Func<T, Key1>> property1,
            Expression<Func<T, Key2>> property2,
            string indexName = null) where Resolver : IndexResolver<T, Key1, Key2>;
    }
}
