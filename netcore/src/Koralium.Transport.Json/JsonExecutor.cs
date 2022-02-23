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
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Koralium.Transport.Json.Encoders;
using System.Text.Json;
using Koralium.Shared;
using Microsoft.Extensions.Logging;
using Koralium.Transport.Exceptions;

namespace Koralium.Transport.Json
{
    static class JsonExecutor
    {
        private static JsonEncodedText _valuesText = JsonEncodedText.Encode("values");

        internal static async Task GetMethod(HttpContext context)
        {
            var queryValue = context.Request.Query["query"];

            if (queryValue.Count > 1)
            {
                await WriteError(context, StatusCodes.Status400BadRequest, "Only one parameter named 'query' can be sent in");
                return;
            }

            if (queryValue.Count == 0)
            {
                await WriteError(context, StatusCodes.Status400BadRequest, "Missing paramter 'query'");
                return;
            }

            var sql = queryValue[0];

            await Execute(sql, context);
        }

        private static async Task WriteError(HttpContext context, int statusCode, string error)
        {
            var errorWriter = context.RequestServices.GetService<IErrorWriter>();
            if (errorWriter != null)
            {
                await errorWriter.WriteAsync(context, statusCode, error);
            }
            else
            {
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(error);
            }
        }

        private static async Task Execute(string sql, HttpContext context)
        {
            context.Response.Headers.Add("Content-Type", "application/json");

            var koraliumService = context.RequestServices.GetService<IKoraliumTransportService>();
            var logger = context.RequestServices.GetService<ILogger<IKoraliumTransportService>>();


            QueryResult result = null;
            try
            {
                result = await koraliumService.Execute(sql, new Shared.SqlParameters(), context);
            }
            catch (SqlErrorException error)
            {
                logger.LogWarning(error.Message);
                await WriteError(context, 400, error.Message);
                return;
            }
            catch (AuthorizationFailedException authFailed)
            {
                logger.LogWarning(authFailed.Message, authFailed);
                await WriteError(context, 401, authFailed.Message);
                return;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Unexpected exception thrown");
                await WriteError(context, 500, "Internal error");
                return;
            }

            var responseStream = new System.Text.Json.Utf8JsonWriter(context.Response.Body);

            IJsonEncoder[] encoders = new IJsonEncoder[result.Columns.Count];
            JsonEncodedText[] names = new JsonEncodedText[result.Columns.Count];

            for (int i = 0; i < encoders.Length; i++)
            {
                encoders[i] = EncoderHelper.GetEncoder(result.Columns[i]);
                names[i] = JsonEncodedText.Encode(result.Columns[i].Name);
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
                    responseStream.WritePropertyName(names[i]);
                    encoders[i].Encode(in responseStream, in row);
                }
                responseStream.WriteEndObject();
            }
            responseStream.WriteEndArray();
            responseStream.WriteEndObject();

            encodingWatch.Stop();

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
