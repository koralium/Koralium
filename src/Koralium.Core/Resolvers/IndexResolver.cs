using Grpc.Core;
using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Core.Utils;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium.Core.Resolvers
{
    public abstract class IndexResolver<Entity> : IIndexResolver
    {
        public async Task GetData(IndexRequest dataRequest, KoraliumTable table, TableIndex index, ServerCallContext context, ChannelWriter<Page> channelWriter)
        {
            var selectExpression = SelectExpressionHelper.CreateSelectExpression<Entity>(table, dataRequest.Fields.ToList(), true);
            var query = await GetData(dataRequest.Records, dataRequest, table, index, selectExpression);

            IEncoder[] encoders = new IEncoder[dataRequest.Fields.Count];
            Func<object, object>[] propertyGetters = new Func<object, object>[dataRequest.Fields.Count];

            Page page = new Page();

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

                encoders[i] = EncoderHelper.GetEncoder(column.ColumnType, columnMetadata, column.Children);
                propertyGetters[i] = column.PropertyAccessor;
                page.Metadata.Add(columnMetadata);
            }

            await EncoderHelper.ReadData(page, encoders, propertyGetters, query.GetEnumerator(), dataRequest.MaxBatchSize, channelWriter);
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
            var decoder = column.Decoder.Create(column.Metadata.ColumnId, column);

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
}
