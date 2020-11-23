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
using Grpc.Core;
using Koralium.Interfaces;
using Koralium.Metadata;
using Koralium.Utils;
using Koralium.Grpc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium
{
    public abstract class IndexResolver<Entity> : IIndexResolver
    {
        public async Task GetData(ILogger logger, IndexRequest dataRequest, KoraliumTable table, TableIndex index, ServerCallContext context, ChannelWriter<Page> channelWriter)
        {
            var selectExpression = SelectExpressionHelper.CreateSelectExpression<Entity>(table, dataRequest.Fields.ToList(), true);
            var query = await GetData(dataRequest.Records, dataRequest, table, index, selectExpression);

            IEncoder[] encoders = new IEncoder[dataRequest.Fields.Count];
            Func<object, object>[] propertyGetters = new Func<object, object>[dataRequest.Fields.Count];

            Page page = new Page()
            {
                Metadata = new QueryMetadata()
            };

            //Generate metadata and encoders
            int columnIndex = 0;
            for (int i = 0; i < dataRequest.Fields.Count; i++)
            {
                var column = table.Columns.FirstOrDefault(x => x.Name.Equals(dataRequest.Fields[i], StringComparison.InvariantCultureIgnoreCase));

                if(column == null)
                {
                    throw new Exception("Column does not exist");
                }

                var columnMetadata = column.ToColumnMetadata(ref columnIndex);

                encoders[i] = null; //EncoderHelper.GetEncoder(column.ColumnType, columnMetadata, column.Children);
                propertyGetters[i] = column.PropertyAccessor;
                page.Metadata.Columns.Add(columnMetadata);
            }

            await EncoderHelper.ReadData(logger, page, encoders, propertyGetters, query.GetEnumerator(), dataRequest.MaxBatchSize, channelWriter);
        }

        protected abstract Task<IEnumerable<Entity>> GetData(
            Page records,
            IndexRequest request,
            KoraliumTable table,
            TableIndex index,
            Expression<Func<Entity, Entity>> selectExpression);
    }

    public abstract class IndexResolver<Entity, Key1> : IndexResolver<Entity>
    {
        protected override async Task<IEnumerable<Entity>> GetData(
            Page records,
            IndexRequest request,
            KoraliumTable table,
            TableIndex index,
            Expression<Func<Entity, Entity>> selectExpression)
        {
            var column = index.Columns.FirstOrDefault();
            IDecoder decoder = null;

            Key1[] array = new Key1[records.RowCount];

            if (records.Columns.Blocks.Count != 1)
            {
                //TODO
                throw new Exception();
                //throw new ColumnCountMissmatchException(1, records.Columns.Blocks.Count);
            }

            decoder.NewPage(records);

            decoder.Decode(records.Columns.Blocks[0], (index, val) =>
            {
                if (index > records.RowCount)
                {
                    //TODO
                    throw new Exception();
                    //throw new RowCountMissmatchException((int)records.RowCount, index);
                }

                array[index] = (Key1)val;
            });

            return await GetQueryableData(array, selectExpression);
        }

        protected abstract Task<IEnumerable<Entity>> GetQueryableData(IReadOnlyList<Key1> keys, Expression<Func<Entity, Entity>> selectExpression);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S2436:Types and methods should not have too many generic parameters", Justification = "Required to get the correct data type for indices")]
    public abstract class IndexResolver<Entity, Key1, Key2> : IndexResolver<Entity>
    {
        protected override async Task<IEnumerable<Entity>> GetData(
            Page records,
            IndexRequest request,
            KoraliumTable table,
            TableIndex index,
            Expression<Func<Entity, Entity>> selectExpression)
        {
            IDecoder[] decoders = null; //index.Columns.Select(x => x.Decoder.Create(x.Metadata.ColumnId, x)).ToList();

            (Key1, Key2)[] array = new (Key1, Key2)[records.RowCount];

            if (records.Columns.Blocks.Count != 2)
            {
                //TODO
                throw new Exception();
                //throw new ColumnCountMissmatchException(2, records.Columns.Blocks.Count);
            }

            //decoders.ForEach(x => x.NewPage(records));

            decoders[0].Decode(records.Columns.Blocks[0], (index, val) =>
            {
                if (index > records.RowCount)
                {
                    //TODO
                    throw new Exception();
                    //throw new RowCountMissmatchException((int)records.RowCount, index);
                }
                array[index].Item1 = (Key1)val;
            });

            decoders[1].Decode(records.Columns.Blocks[1], (index, val) =>
            {
                if (index > records.RowCount)
                {
                    //TODO
                    throw new Exception();
                    //throw new RowCountMissmatchException((int)records.RowCount, index);
                }
                array[index].Item2 = (Key2)val;
            });

            return await GetQueryableData(array, selectExpression);
        }

        protected abstract Task<IEnumerable<Entity>> GetQueryableData(IReadOnlyList<(Key1, Key2)> keys, Expression<Func<Entity, Entity>> selectExpression);
    }
}
