using System;

namespace Koralium.Transport.Json.Encoders
{
    static class EncoderHelper
    {
        public static IJsonEncoder GetEncoder(Column column)
        {
            switch (column.ColumnType)
            {
                case ColumnType.Bool:
                    return new BooleanEncoder(column);
                case ColumnType.Double:
                    return new DoubleEncoder(column);
                case ColumnType.Float:
                    return new FloatEncoder(column);
                case ColumnType.Int32:
                    return new Int32Encoder(column);
                case ColumnType.Int64:
                    return new Int64Encoder(column);
                case ColumnType.List:
                    return new ListEncoder(column);
                case ColumnType.Object:
                    return new ObjectEncoder(column);
                case ColumnType.String:
                    return new StringEncoder(column);
                case ColumnType.DateTime:
                    return new DateTimeEncoder(column);
                case ColumnType.Short:
                    return new Int16Encoder(column);
                case ColumnType.UInt32:
                    return new UInt32Encoder(column);
            }
            throw new NotImplementedException();
        }
    }
}
