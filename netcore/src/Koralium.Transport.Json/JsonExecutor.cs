using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Koralium.Transport.Json.Encoders;
using System.Text.Json;
using Grpc.Core;

namespace Koralium.Transport.Json
{
    static class JsonExecutor
    {
        private static JsonEncodedText _valuesText = JsonEncodedText.Encode("values");

        internal static async Task GetMethod(HttpContext context)
        {
            var queryValue = context.Request.Query["query"];

            if(queryValue.Count > 1)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Only one parameter named 'query' can be sent in");
                return;
            }

            if(queryValue.Count == 0)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Missing parameter 'query'");
                return;
            }

            var sql = queryValue[0];

            await Execute(sql, context);
        }

        private static async Task Execute(string sql, HttpContext context)
        {
            context.Response.Headers.Add("Content-Type", "application/json");

            var koraliumService = context.RequestServices.GetService<IKoraliumTransportService>();

            var result = await koraliumService.Execute(sql, new Shared.SqlParameters(), context);

            var responseStream = new System.Text.Json.Utf8JsonWriter(context.Response.Body);

            IJsonEncoder[] encoders = new IJsonEncoder[result.Columns.Count];

            for (int i = 0; i < encoders.Length; i++)
            {
                encoders[i] = EncoderHelper.GetEncoder(result.Columns[i]);
            }

            System.Diagnostics.Stopwatch encodingWatch = new System.Diagnostics.Stopwatch();
            encodingWatch.Start();
            responseStream.WriteStartObject();

            responseStream.WriteStartArray(_valuesText);
            foreach (var row in result.Result)
            {
                responseStream.WriteStartObject();
                for (int i = 0; i < encoders.Length; i++)
                {
                    encoders[i].Encode(in responseStream, in row);
                }
                responseStream.WriteEndObject();
            }
            responseStream.WriteEndArray();
            responseStream.WriteEndObject();

            encodingWatch.Stop();
            Console.WriteLine("Encoding time:" + encodingWatch.ElapsedMilliseconds);

            await responseStream.FlushAsync();
        }

        internal static async Task PostMethod(HttpContext context)
        {
            using StreamReader streamReader = new StreamReader(context.Request.Body);
            var sql = await streamReader.ReadToEndAsync();

            await Execute(sql, context);
        }
    }
}
