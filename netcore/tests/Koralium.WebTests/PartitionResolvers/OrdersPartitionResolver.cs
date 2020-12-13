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
                partitionFilters.Add(QueryBuilder.BooleanExpression<Order>(x => x.Orderkey < keys.First()));

                //Middle partitions contains both start and end
                for(int i = 1; i < keys.Count - 1; i++)
                {
                    partitionFilters.Add(QueryBuilder.BooleanExpression<Order>(x => x.Orderkey >= keys[i - 1] && x.Orderkey < keys[i]));
                }

                partitionFilters.Add(QueryBuilder.BooleanExpression<Order>(x => x.Orderkey >= keys.Last()));
                //Last partition only contains a start
            }

            _partitionFilters = partitionFilters;

            return Task.CompletedTask;
        }
    }
}
