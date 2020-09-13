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
