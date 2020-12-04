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
            }

            throw new NotImplementedException();
        }
    }
}
