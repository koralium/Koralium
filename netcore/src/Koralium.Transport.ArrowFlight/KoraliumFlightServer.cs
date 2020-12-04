using Apache.Arrow;
using Apache.Arrow.Flight;
using Apache.Arrow.Flight.Server;
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
        private readonly IKoraliumTransportService _koraliumTransportService;
        public KoraliumFlightServer(IKoraliumTransportService koraliumTransportService)
        {
            _koraliumTransportService = koraliumTransportService;
        }

        public override async Task DoGet(FlightTicket ticket, FlightServerRecordBatchStreamWriter responseStream, ServerCallContext context)
        {
            try
            {
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
                    if (encoders.Select(x => x.Size()).Sum() > 1000000)
                    {
                        await responseStream.WriteAsync(new RecordBatch(schema, encoders.Select(x => x.BuildArray()), count));
                        foreach (var encoder in encoders)
                        {
                            encoder.NewBatch();
                        }
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
        }

        public override async Task ListFlights(FlightCriteria request, IAsyncStreamWriter<FlightInfo> responseStream, ServerCallContext context)
        {
            var tables = _koraliumTransportService.GetTables();

            var httpContext = context.GetHttpContext();
            foreach(var table in tables)
            {
                var selectAllSql = table.SelectAllColumnsStatement();
                await responseStream.WriteAsync(GetFlightInfo(selectAllSql, httpContext));
            }
        }

        private FlightInfo GetFlightInfo(FlightDescriptor flightDescriptor, HttpContext httpContext)
        {
            return GetFlightInfo(flightDescriptor.Command.ToStringUtf8(), httpContext);
        }

        private FlightInfo GetFlightInfo(string sql, HttpContext httpContext)
        {
            var schema = _koraliumTransportService.GetSchema(sql, new Shared.SqlParameters(), httpContext);

            var schemaBuilder = new Schema.Builder();

            
            foreach(var column in schema)
            {
                schemaBuilder.Field(new Field(column.Name, TypeConverter.Convert(column), column.IsNullable));
            }
            var descriptor = FlightDescriptor.CreateCommandDescriptor(sql);

            var endpoint = new FlightEndpoint(new FlightTicket(sql), new List<FlightLocation>()
            {
                new FlightLocation($"grpc+tcp://{httpContext.Request.Host}")
            });
            var endpoints = new List<FlightEndpoint>() { endpoint };
            return new FlightInfo(schemaBuilder.Build(), descriptor, endpoints);
        }

        private Schema GetSchema(string sql, HttpContext httpContext)
        {
            var schema = _koraliumTransportService.GetSchema(sql, new Shared.SqlParameters(), httpContext);

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
            return Task.FromResult(GetFlightInfo(request, context.GetHttpContext()));
        }

        public override Task<Schema> GetSchema(FlightDescriptor request, ServerCallContext context)
        {
            return Task.FromResult(GetSchema(request.Command.ToStringUtf8(), context.GetHttpContext()));
        }

        public override Task ListActions(IAsyncStreamWriter<FlightActionType> responseStream, ServerCallContext context)
        {
            return Task.CompletedTask;
        }
    }
}
