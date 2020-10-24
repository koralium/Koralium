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
using Koralium.Grpc;
using System;

namespace Data.Koralium.Client.Utils
{
    public static class DecoderUtils
    {
        public static ColumnDecoder GetDecoder(int ordinal, ColumnMetadata columnMetadata)
        {
            switch (columnMetadata.Type)
            {
                case KoraliumType.Object:
                    return new ObjectDecoder(ordinal, columnMetadata);
                case KoraliumType.Array:
                    return new ArrayDecoder(ordinal, columnMetadata);
                case KoraliumType.String:
                    return new StringDecoder(ordinal, columnMetadata);
                case KoraliumType.Bool:
                    return new BoolDecoder(ordinal);
                case KoraliumType.Double:
                    return new DoubleDecoder(ordinal);
                case KoraliumType.Float:
                    return new FloatDecoder(ordinal);
                case KoraliumType.Int32:
                    return new Int32Decoder(ordinal);
                case KoraliumType.Int64:
                    return new Int64Decoder(ordinal);
                case KoraliumType.Timestamp:
                    return new TimestampDecoder(ordinal);
            }

            throw new NotSupportedException();
        }
    }
}
