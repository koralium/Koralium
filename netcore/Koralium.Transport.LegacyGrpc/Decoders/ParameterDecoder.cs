using Koralium.Grpc;
using Koralium.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.LegacyGrpc.Decoders
{
    public static class ParameterDecoder
    {

        public static SqlParameters DecodeParameters(IEnumerable<KeyValue> parameters)
        {
            SqlParameters sqlParameters = new SqlParameters();

            foreach (var parameter in parameters)
            {
                sqlParameters.Add(DecodeParameter(parameter));
            }

            return sqlParameters;
        }

        public static SqlParameter DecodeParameter(KeyValue parameter)
        {
            return SqlParameter.Create(parameter.Name, ScalarDecoder.DecodeScalar(parameter.Value));
        }
    }
}
