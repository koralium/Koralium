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
using Koralium.SqlToExpression.Tests.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests
{
    public class TableResolver : ISqlTableResolver
    {
        private readonly TpchData _tpchData;
        public TableResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        private IQueryable GetQueryable(string name)
        {
            switch (name.ToLower())
            {
                case "customer":
                    return _tpchData.Customers.AsQueryable();
                case "lineitem":
                    return _tpchData.LineItem.AsQueryable();
                case "order":
                    return _tpchData.Orders.AsQueryable();
                case "Part":
                    return _tpchData.Part.AsQueryable();
                case "partsupp":
                    return _tpchData.Partsupp.AsQueryable();
                case "region":
                    return _tpchData.Region.AsQueryable();
                case "supplier":
                    return _tpchData.Supplier.AsQueryable();
                case "columntest":
                    return TestData.GetColumnTestData();
                case "nulltest":
                    return TestData.GetNullTestData();
            }
            throw new NotImplementedException();
        }

        public ValueTask<IQueryable> ResolveTableName(string name, object additionalData, IQueryOptions queryOptions)
        {
            return new ValueTask<IQueryable>(GetQueryable(name));
        }
    }
}
