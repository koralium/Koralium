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
using Koralium.Models;
using Koralium.SqlParser.Statements;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser;
using Koralium.WebTests.Entities.tpch;

namespace Koralium.WebTests.PartitionResolvers
{
    public class OrdersPartitionResolver : PartitionResolver
    {
        private const int PartitionLength = 4000;

        List<BooleanExpression> _partitionFilters;

        public OrdersPartitionResolver()
        {
        }

        public override Task<IImmutableList<Partition>> GetPartitions(bool canHandleMultiplePartitions, PartitionsBuilder partitionsBuilder, HttpContext httpContext, PartitionOptions partitionOptions)
        {
            if (!canHandleMultiplePartitions)
            {
                return base.GetPartitions(canHandleMultiplePartitions, partitionsBuilder, httpContext, partitionOptions);
            }

            if(_partitionFilters == null)
            {
                GeneratPartitionMetadata(partitionOptions);
            }

            var builder = ImmutableList.CreateBuilder<Partition>();
            foreach(var filter in _partitionFilters)
            {
                builder.Add(partitionsBuilder.NewPartition().AddFilter(filter).Build());
            }

            return Task.FromResult<IImmutableList<Partition>>(builder.ToImmutable());
        }

        public override TimeSpan? GenerateMetadataTimespan => TimeSpan.FromMinutes(5);

        public override Task GeneratPartitionMetadata(PartitionOptions partitionOptions)
        {
            var tpchData = partitionOptions.ServiceProvider.GetService<TpchData>();
            var orders = tpchData.Orders.OrderBy(x => x.Orderkey).ToList();

            List<long> keys = new List<long>();
            for(int i = PartitionLength; i < orders.Count; i += PartitionLength)
            {
                keys.Add(orders[i].Orderkey);
            }
            keys = keys.OrderBy(x => x).ToList();

            List<BooleanExpression> partitionFilters = new List<BooleanExpression>();


            if (keys.Count > 0)
            {
                var firstData = tpchData.Orders.Where(x => x.Orderkey < keys.First()).ToList();
                partitionFilters.Add(QueryBuilder.BooleanExpression<Order>(x => x.Orderkey < keys.First()));

                //Middle partitions contains both start and end
                for(int i = 1; i < keys.Count; i++)
                {
                    var middleData = tpchData.Orders.Where(x => x.Orderkey >= keys[i - 1] && x.Orderkey < keys[i]).ToList();
                    partitionFilters.Add(QueryBuilder.BooleanExpression<Order>(x => x.Orderkey >= keys[i - 1] && x.Orderkey < keys[i]));
                    
                }
                var lastData = tpchData.Orders.Where(x => x.Orderkey >= keys.Last()).ToList();
                partitionFilters.Add(QueryBuilder.BooleanExpression<Order>(x => x.Orderkey >= keys.Last()));
                //Last partition only contains a start
            }

            _partitionFilters = partitionFilters;

            return Task.CompletedTask;
        }
    }
}
