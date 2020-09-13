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
using Google.Protobuf.WellKnownTypes;
using Koralium.Grpc;
using System;
using System.Text;

namespace Koralium.Encoders
{
    /// <summary>
    /// Special encoder that encodes scalar values
    /// This only encodes primitives
    /// </summary>
    public static class ScalarEncoder
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
