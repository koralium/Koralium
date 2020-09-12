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
