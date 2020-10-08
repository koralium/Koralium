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
using Koralium.Encoders;
using Koralium.Interfaces;
using Koralium.Metadata;
using Koralium.Grpc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium.Utils
{
    public static class EncoderHelper
    {
        public static IEncoder GetEncoder(Type type, ColumnMetadata columnMetadata, IReadOnlyList<TableColumn> children)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return GetEncoder(Nullable.GetUnderlyingType(type), columnMetadata, children);
            }
            if (type.Equals(typeof(int)))
            {
                return new Int32Encoder();
            }
            if (type.Equals(typeof(long)))
            {
                return new Int64Encoder();
            }
            if (type.Equals(typeof(string)))
            {
                return new StringEncoder((uint)columnMetadata.ColumnId);
            }
            if (type.Equals(typeof(bool)))
            {
                return new BoolEncoder();
            }
            if (type.Equals(typeof(float)))
            {
                return new FloatEncoder();
            }
            if (type.Equals(typeof(double)))
            {
                return new DoubleEncoder();
            }
            if (type.Equals(typeof(DateTime)))
            {
                return new TimestampEncoder();
            }
            if (IsArray(type))
            {
                return new ArrayEncoder(children, columnMetadata);
            }
            if (!IsBaseType(type))
            {
                return new ObjectEncoder(children, columnMetadata);
            }
            throw new NotSupportedException();
        }

        private static bool IsArray(Type type)
        {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>));
        }

        private static bool IsBaseType(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return IsBaseType(Nullable.GetUnderlyingType(type));
            }
            if (type.IsPrimitive ||
                type.Equals(typeof(string)) ||
                type.Equals(typeof(DateTime)))
                return true;
            return false;
        }

        internal static Columns CreateBlocks(Page page, IEncoder[] encoders)
        {
            Columns columns = new Columns();
            foreach (var encoder in encoders)
            {
                columns.Blocks.Add(encoder.CreateBlock(page));
            }
            return columns;
        }

        public static async Task ReadData(
            ILogger logger,
            Page page,
            IEncoder[] encoders,
            Func<object, object>[] propertyGetters,
            IEnumerator enumerator,
            int maxBatchSize,
            ChannelWriter<Page> channelWriter)
        {
            var columns = CreateBlocks(page, encoders);
            page.Columns = columns;

            uint count = 0;
            int rowNumber = 0;

            //Call enumerator move next first alone, since that might trigger database calls etc
            //This is used for timing and debugging only
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            if (!enumerator.MoveNext())
            {
                await channelWriter.WriteAsync(page);
                channelWriter.Complete();
                return;
            }
            stopwatch.Stop();
            logger.LogTrace($"Getting first entry took {stopwatch.ElapsedMilliseconds} ms");

            do
            {
                if (count >= maxBatchSize)
                {
                    page.RowCount = (uint)rowNumber;
                    for (int i = 0; i < encoders.Length; i++)
                    {
                        encoders[i].Finish();
                    }
                    await channelWriter.WriteAsync(page);
                    page = new Page();
                    columns = CreateBlocks(page, encoders);
                    page.Columns = columns;
                    count = 0;
                    rowNumber = 0;
                }

                var currentObject = enumerator.Current;

                for (int i = 0; i < encoders.Length; i++)
                {
                    var encoder = encoders[i];
                    var getter = propertyGetters[i];

                    var data = getter(currentObject);

                    if (data == null)
                    {
                        columns.Blocks[i].Nulls.Add((uint)rowNumber);
                        continue;
                    }

                    count += encoder.Encode(in data, columns.Blocks[i], in rowNumber);
                }

                rowNumber++;
            } while (enumerator.MoveNext());

            if (count > 0)
            {
                page.RowCount = (uint)rowNumber;
                for (int i = 0; i < encoders.Length; i++)
                {
                    encoders[i].Finish();
                }
                await channelWriter.WriteAsync(page);
            }

            channelWriter.Complete();
        }
    }
}
