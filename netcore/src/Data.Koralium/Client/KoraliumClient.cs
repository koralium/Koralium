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
using Data.Koralium.Client.Decoders;
using Data.Koralium.Client.Utils;
using Data.Koralium.Utils;
using Grpc.Net.Client;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Data.Koralium.Client
{
    public class KoraliumClient
    {
        private readonly CancellationToken _cancellationToken;
        private readonly KoraliumService.KoraliumServiceClient _client;
        private ColumnDecoder[] decoders;

        private readonly DummyTask gotMetadataTask;

        private string[] columnNames;
        private readonly Dictionary<string, int> nameToOrdinal = new Dictionary<string, int>(); 

        public KoraliumClient(GrpcChannel grpcChannel, CancellationToken cancellationToken)
        {
            _client = new KoraliumService.KoraliumServiceClient(grpcChannel);
            gotMetadataTask = new DummyTask();
            _cancellationToken = cancellationToken;
        }

        public Task MetadataCollected => gotMetadataTask;

        public object QueryScalar(string sql)
        {
            var scalar = _client.QueryScalar(new QueryRequest()
            {
                Query = sql
            });

            return ScalarDecoder.DecodeScalar(scalar);
        }

        public Task Query(string sql, ChannelWriter<KoraliumRow> writer)
        {
            return Task.Run(async () =>
            {
                try
                {
                    var stream = _client.Query(new QueryRequest()
                    {
                        Query = sql,
                        MaxBatchSize = 1000000
                    });

                    while (await stream.ResponseStream.MoveNext(_cancellationToken))
                    {
                        var page = stream.ResponseStream.Current;
                        await ParsePage(page, writer);
                    }
                    writer.Complete();
                }
                catch (Exception e)
                {
                    writer.Complete(e);
                    gotMetadataTask.Fail(e);
                }
            });
            
        }

        private KoraliumRow[] CreateRows(uint rowCount, int columnCount)
        {
            KoraliumRow[] rows = new KoraliumRow[rowCount];

            for(int i = 0; i < rowCount; i++)
            {
                rows[i] = new KoraliumRow(columnCount);
            }
            return rows;
        }

        private async Task ParsePage(Page page, ChannelWriter<KoraliumRow> writer)
        {
            //First page should contain metadata
            if (page.Metadata != null)
            {
                //Build up the decoders
                decoders = new ColumnDecoder[page.Metadata.Columns.Count];
                for(int i = 0; i < page.Metadata.Columns.Count; i++)
                {
                    decoders[i] = DecoderUtils.GetDecoder(i, page.Metadata.Columns[i]);
                }

                //add the metadata info
                columnNames = page.Metadata.Columns.Select(x => x.Name).ToArray();
                for(int i = 0; i < columnNames.Length; i++)
                {
                    nameToOrdinal.Add(columnNames[i], i);
                }

                gotMetadataTask.Finish();
            }
            
            var rows = CreateRows(page.RowCount, decoders.Length);
            for(int i = 0; i < decoders.Length; i++)
            {
                decoders[i].NewPage(page);
                decoders[i].ReadBlock(page.Columns.Blocks[i], rows);
            }

            for(int i = 0; i < rows.Length; i++)
            {
                await writer.WriteAsync(rows[i]);
            }
        }

        public int GetNumberOfColumns()
        {
            return decoders.Length;
        }

        public virtual string GetName(int ordinal)
        {
            Debug.Assert(columnNames.Length > ordinal);
            return columnNames[ordinal];
        }

        public virtual string GetName(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            throw new NotImplementedException();
        }


        public virtual int GetOrdinal(string name)
        {
            if(nameToOrdinal.TryGetValue(name, out var ordinal))
            {
                return ordinal;
            }
            return -1;
        }

        public virtual bool GetBoolean(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetBoolean(row);
        }

        public virtual byte GetByte(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetByte(row);
        }

        public virtual long GetBytes(int ordinal, KoraliumRow row, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetBytes(row, dataOffset, buffer, bufferOffset, length);
        }

        public virtual char GetChar(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetChar(row);
        }

        public virtual long GetChars(int ordinal, KoraliumRow row, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetChars(row, dataOffset, buffer, bufferOffset, length);
        }

        public virtual string GetDataTypeName(int ordinal)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetDataTypeName();
        }

        public virtual DateTime GetDateTime(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetDateTime(row);
        }

        public virtual decimal GetDecimal(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetDecimal(row);
        }

        public virtual double GetDouble(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetDouble(row);
        }

        public virtual Type GetFieldType(int ordinal)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetFieldType();
        }

        public virtual float GetFloat(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetFloat(row);
        }

        public virtual Guid GetGuid(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetGuid(row);
        }

        public virtual short GetInt16(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetInt16(row);
        }

        public virtual int GetInt32(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetInt32(row);
        }

        public virtual long GetInt64(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetInt64(row);
        }
        
        public virtual string GetString(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetString(row);
        }

        public virtual object GetValue(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetValue(row);
        }

        public virtual bool IsDBNull(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].IsDBNull(row);
        }

        public virtual T GetFieldValue<T>(int ordinal, KoraliumRow row)
        {
            Debug.Assert(ordinal < decoders.Length);
            return decoders[ordinal].GetFieldValue<T>(row);
        }
    }
}
