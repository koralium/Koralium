using Apache.Arrow;
using Apache.Arrow.Flight;
using Apache.Arrow.Flight.Server;
using Google.Protobuf;
using Grpc.Core;
using Koralium.Shared;
using Koralium.Transport.ArrowFlight.Encoders;
using Koralium.Transport.ArrowFlight.Utils;
using Koralium.Transport.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.Transport.ArrowFlight
{
    internal class KoraliumFlightServer : FlightServer
    {
        private const int DefaultMaxBatchSize = 1000000;

        private readonly IKoraliumTransportService _koraliumTransportService;
        public KoraliumFlightServer(IKoraliumTransportService koraliumTransportService)
        {
            _koraliumTransportService = koraliumTransportService;
        }

        public override async Task DoGet(FlightTicket ticket, FlightServerRecordBatchStreamWriter responseStream, ServerCallContext context)
        {
            try
            {
                int maxBatchSize = DefaultMaxBatchSize;
                var maxBatchSizeMetadata = context.RequestHeaders.Get("max-batch-size");

                if(maxBatchSizeMetadata != null && int.TryParse(maxBatchSizeMetadata.Value, out var parsedMaxBatchSize))
                {
                    maxBatchSize = parsedMaxBatchSize;
                }

                var queryResult = await _koraliumTransportService.Execute(ticket.Ticket.ToStringUtf8(), new Shared.SqlParameters(), context.GetHttpContext());

                //Get the resulting schema
                var schema = GetSchema(queryResult.Columns);

                var encoders = queryResult.Columns.Select(x => EncoderHelper.GetEncoder(x)).ToArray();

                foreach (var encoder in encoders)
                {
                    encoder.NewBatch();
                }

                List<object> list = new List<object>(20000);
                int count = 0;

                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                foreach (var obj in queryResult.Result)
                {
                    count++;
                    for (int i = 0; i < encoders.Length; i++)
                    {
                        encoders[i].Encode(obj);
                    }
                    if (encoders.Select(x => x.Size()).Sum() > maxBatchSize)
                    {
                        await responseStream.WriteAsync(new RecordBatch(schema, encoders.Select(x => x.BuildArray()), count));
                        foreach (var encoder in encoders)
                        {
                            encoder.NewBatch();
                        }
                        count = 0;
                    }
                }
                stopwatch.Stop();

                var batch = new RecordBatch(schema, encoders.Select(x => x.BuildArray()), count);
                await responseStream.WriteAsync(batch);
            }
            catch(SqlErrorException error)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, error.Message));
            }
            catch(Exception e)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Internal error"));
            }
        }

        public override async Task ListFlights(FlightCriteria request, IAsyncStreamWriter<FlightInfo> responseStream, ServerCallContext context)
        {
            var tables = _koraliumTransportService.GetTables();

            var httpContext = context.GetHttpContext();
            foreach(var table in tables)
            {
                var selectAllSql = table.SelectAllColumnsStatement();
                await responseStream.WriteAsync(GetFlightInfo(selectAllSql, context));
            }
        }

        private bool IsPartitionsEnabled(ServerCallContext serverCallContext)
        {
            var enablePartitionsHeader = serverCallContext.RequestHeaders.Get("enable-partitions");
            return enablePartitionsHeader != null && bool.TryParse(enablePartitionsHeader.Value, out var result) && result;
        }

        private FlightInfo GetFlightInfo(string sql, ServerCallContext context)
        {
            var partitionsResult = _koraliumTransportService.GetPartitions(IsPartitionsEnabled(context), sql, new Shared.SqlParameters(), context.GetHttpContext()).Result;

            var schemaBuilder = new Schema.Builder();
            foreach(var column in partitionsResult.Columns)
            {
                schemaBuilder.Field(new Field(column.Name, TypeConverter.Convert(column), column.IsNullable));
            }
            var descriptor = FlightDescriptor.CreateCommandDescriptor(sql);

            List<FlightEndpoint> endpoints = new List<FlightEndpoint>();
            foreach(var partition in partitionsResult.Partitions)
            {
                List<FlightLocation> locations = new List<FlightLocation>();

                foreach(var location in partition.Locations)
                {
                    string uri = null;

                    if (location.Tls)
                    {
                        uri = $"grpc+tls://{location.Host}";
                    }
                    else
                    {
                        uri = $"grpc+tcp://{location.Host}";
                    }

                    locations.Add(new FlightLocation(uri));
                }
                endpoints.Add(new FlightEndpoint(new FlightTicket(partition.Sql), locations));
            }
            return new FlightInfo(schemaBuilder.Build(), descriptor, endpoints);
        }

        private Schema GetSchema(string sql, ServerCallContext context)
        {
            var schema = _koraliumTransportService.GetSchema(sql, new Shared.SqlParameters(), context.GetHttpContext());

            return GetSchema(schema);
        }

        private Schema GetSchema(IImmutableList<Column> columns)
        {
            var schemaBuilder = new Schema.Builder();

            foreach (var column in columns)
            {
                schemaBuilder.Field(new Field(column.Name, TypeConverter.Convert(column), column.IsNullable));
            }

            return schemaBuilder.Build();
        }

        public override Task<FlightInfo> GetFlightInfo(FlightDescriptor request, ServerCallContext context)
        {
            return Task.FromResult(GetFlightInfo(request.Command.ToStringUtf8(), context));
        }

        public override Task<Schema> GetSchema(FlightDescriptor request, ServerCallContext context)
        {
            return Task.FromResult(GetSchema(request.Command.ToStringUtf8(), context));
        }

        public override Task ListActions(IAsyncStreamWriter<FlightActionType> responseStream, ServerCallContext context)
        {
            return Task.CompletedTask;
        }
    }
}
