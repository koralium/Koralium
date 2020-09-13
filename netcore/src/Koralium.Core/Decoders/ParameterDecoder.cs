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
using Koralium.SqlToExpression;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Decoders
{
    public static class ParameterDecoder
    {

        public static SqlParameters DecodeParameters(IEnumerable<Parameter> parameters)
        {
            SqlParameters sqlParameters = new SqlParameters();

            foreach(var parameter in parameters)
            {
                sqlParameters.Add(DecodeParameter(parameter));
            }

            return sqlParameters;
        }

        public static SqlParameter DecodeParameter(Parameter parameter)
        {
            return SqlParameter.Create(parameter.Name, ScalarDecoder.DecodeScalar(parameter.Value));
            //var scalar = parameter.Value;
            //switch (scalar.ValueCase)
            //{
            //    case Scalar.ValueOneofCase.Bool:
            //        return new SqlParameter<bool>(parameter.Name, scalar.Bool);
            //    case Scalar.ValueOneofCase.Double:
            //        return new SqlParameter<double>(parameter.Name, scalar.Double);
            //    case Scalar.ValueOneofCase.Float:
            //        return new SqlParameter<float>(parameter.Name, scalar.Float);
            //    case Scalar.ValueOneofCase.Int:
            //        return new SqlParameter<int>(parameter.Name, scalar.Int);
            //    case Scalar.ValueOneofCase.Long:
            //        return new SqlParameter<long>(parameter.Name, scalar.Long);
            //    case Scalar.ValueOneofCase.String:
            //        return new SqlParameter<string>(parameter.Name, scalar.String);
            //    case Scalar.ValueOneofCase.Timestamp:
            //        return new SqlParameter<DateTime>(parameter.Name, scalar.Timestamp.ToDateTime());
            //    default:
            //        throw new NotSupportedException();
            //}
        }
    }
}
