using Google.Protobuf.WellKnownTypes;
using Koralium.Grpc;
using System;

namespace Koralium.Transport.LegacyGrpc.Encoders
{
    static class ScalarEncoder
    {
        public static Scalar EncodeScalarResult(object value)
        {
            System.Type type = value.GetType();

            Scalar scalar = new Scalar();
            if (type.Equals(typeof(int)))
            {
                scalar.Int = (int)value;
            }
            else if (type.Equals(typeof(long)))
            {
                scalar.Long = (long)value;
            }
            else if (type.Equals(typeof(bool)))
            {
                scalar.Bool = (bool)value;
            }
            else if (type.Equals(typeof(double)))
            {
                scalar.Double = (double)value;
            }
            else if (type.Equals(typeof(float)))
            {
                scalar.Float = (float)value;
            }
            else if (type.Equals(typeof(string)))
            {
                scalar.String = (string)value;
            }
            else if (type.Equals(typeof(DateTime)))
            {
                scalar.Timestamp = Timestamp.FromDateTime((DateTime)value);
            }
            else
            {
                throw new NotSupportedException($"Scalar result can not return {type.Name}");
            }
            return scalar;
        }
    }
}
