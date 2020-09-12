using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Client.Decoders
{
    /// <summary>
    /// Special decoder that takes care of scalars
    /// </summary>
    public static class ScalarDecoder
    {
        public static object DecodeScalar(Scalar scalar)
        {
            switch (scalar.ValueCase)
            {
                case Scalar.ValueOneofCase.Bool:
                    return scalar.Bool;
                case Scalar.ValueOneofCase.Double:
                    return scalar.Double;
                case Scalar.ValueOneofCase.Float:
                    return scalar.Float;
                case Scalar.ValueOneofCase.Int:
                    return scalar.Int;
                case Scalar.ValueOneofCase.Long:
                    return scalar.Long;
                case Scalar.ValueOneofCase.None:
                    return null;
                case Scalar.ValueOneofCase.String:
                    return scalar.String;
                case Scalar.ValueOneofCase.Timestamp:
                    return scalar.Timestamp.ToDateTime();
            }
            throw new NotSupportedException();
        }
    }
}
