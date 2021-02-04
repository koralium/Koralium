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
using Koralium.Transport.ArrowFlight.Encoders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Utils
{
    internal static class EncoderHelper
    {
        public static IArrowEncoder GetEncoder(Column column)
        {
            switch (column.ColumnType)
            {
                case ColumnType.Bool:
                    return new BooleanEncoder(column);
                case ColumnType.DateTime:
                    return new DateTimeEncoder(column);
                case ColumnType.Double:
                    return new DoubleEncoder(column);
                case ColumnType.Float:
                    return new FloatEncoder(column);
                case ColumnType.Int32:
                    return new Int32Encoder(column);
                case ColumnType.Int64:
                    return new Int64Encoder(column);
                case ColumnType.String:
                    return new StringEncoder(column);
                case ColumnType.List:
                    return new ListEncoder(column);
                case ColumnType.Object:
                    return new ObjectEncoder(column);
                case ColumnType.Short:
                    return new Int16Encoder(column);
                case ColumnType.UInt32:
                    return new UInt32Encoder(column);
                case ColumnType.UInt64:
                    return new UInt64Encoder(column);
                case ColumnType.Byte:
                    return new UInt8Encoder(column);
                case ColumnType.Binary:
                    return new BinaryEncoder(column);
                case ColumnType.Enum:
                    return new EnumEncoder(column);
            }

            throw new NotImplementedException();
        }
    }
}
