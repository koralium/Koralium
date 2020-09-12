using Data.Koralium.Client.Decoders;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

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
