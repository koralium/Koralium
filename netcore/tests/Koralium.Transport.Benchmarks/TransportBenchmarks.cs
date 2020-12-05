using Apache.Arrow;
using Apache.Arrow.Flight;
using Apache.Arrow.Flight.Client;
using Apache.Arrow.Types;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Grpc.Net.Client;
using Koralium.WebTests.Entities.tpch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Transport.Benchmarks
{
    public class TransportBenchmarks
    {
        FlightClient flightClient;

        HttpClient httpClient;
        string jsonUrl;

        string jsonBaselineUrl;


        Grpc.KoraliumService.KoraliumServiceClient legacyClient;

        [ParamsSource(nameof(SqlQueries))]
        public string Sql { get; set; }

        public IEnumerable<string> SqlQueries => new List<string>()
        {
            "select orderkey from orders",
            "select * from orders",
            "select comment from orders",
            "select * from lineitem"
        };

        public TransportBenchmarks()
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            flightClient = new FlightClient(GrpcChannel.ForAddress("http://127.0.0.1:5016"));
            

            httpClient = new HttpClient();
            jsonUrl = "http://127.0.0.1:5015/sql";

            jsonBaselineUrl = "http://127.0.0.1:5015/api/orders";

            legacyClient = new Grpc.KoraliumService.KoraliumServiceClient(GrpcChannel.ForAddress("http://127.0.0.1:5016"));
        }

        [Benchmark]
        public async Task ArrowFlight()
        {
            var flightTicket = new FlightTicket(Sql);
            var stream = flightClient.GetStream(flightTicket);

            await foreach(var recordBatch in stream.ResponseStream)
            {
                for(int i = 0; i < recordBatch.ColumnCount; i++)
                {
                    var array = recordBatch.Arrays.ElementAt(i);
                    switch (recordBatch.Schema.GetFieldByIndex(i).DataType.TypeId)
                    {
                        case ArrowTypeId.Int64:
                            Int64Array int64Array = (Int64Array)array;
                            Sum(int64Array);
                            break;
                        case ArrowTypeId.String:
                            StringArray stringArray = (StringArray)array;
                            for(int z = 0; z < stringArray.Length; z++)
                            {
                                stringArray.GetString(z);
                            }
                            break;
                        case ArrowTypeId.Timestamp:
                            TimestampArray timestampArray = (TimestampArray)array;

                            for(int z = 0; z < timestampArray.Length; z++)
                            {
                                timestampArray.GetTimestamp(z);
                            }
                            break;
                    }
                }
                
                //nop
            }
        }

        public static long Sum(Int64Array int64Array)
        {
            long sum = 0;
            ReadOnlySpan<long> values = int64Array.Values;
            for (int valueIndex = 0; valueIndex < values.Length; valueIndex++)
            {
                sum += values[valueIndex];
            }
            return sum;
        }


        public class JsonResponse<T>
        {
            public List<T> Values { get; set; }
        }

        [Benchmark]
        public async Task Json()
        {
            var jsonSelect = new StringContent(Sql);
            var result = await httpClient.PostAsync(jsonUrl, jsonSelect);
            var text = await result.Content.ReadAsStringAsync();
            System.Text.Json.JsonSerializer.Deserialize<JsonResponse<Order>>(text);
        }

        [Benchmark]
        public async Task Legacy()
        {
            var queryRequest = new Grpc.QueryRequest()
            {
                Query = Sql
            };
            var stream = legacyClient.Query(queryRequest);

            while (await stream.ResponseStream.MoveNext(default))
            {
                for(int i = 0; i < stream.ResponseStream.Current.Columns.Blocks.Count; i++)
                {
                    switch (stream.ResponseStream.Current.Columns.Blocks[i].BlockCase)
                    {
                        case Grpc.Block.BlockOneofCase.Strings:
                            foreach(var stringId in stream.ResponseStream.Current.Columns.Blocks[i].Strings.StringId)
                            {

                            }
                            break;
                        case Grpc.Block.BlockOneofCase.Longs:
                            long sum = 0;
                            foreach(var val in stream.ResponseStream.Current.Columns.Blocks[i].Longs.Values)
                            {
                                sum += val;
                            }
                            break;
                    }
                }
                //stream.ResponseStream.Current.
                //nop
            }
        }
    }
}
