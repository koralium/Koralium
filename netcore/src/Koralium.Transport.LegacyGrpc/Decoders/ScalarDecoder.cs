using Koralium.Grpc;
using System;

namespace Koralium.Transport.LegacyGrpc.Decoders
{
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
                case Scalar.ValueOneofCase.String:
                    return scalar.String;
                case Scalar.ValueOneofCase.Timestamp:
                    return scalar.Timestamp.ToDateTime();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
