using Apache.Arrow.Flight.Protocol;
using Grpc.Core;

namespace Apache.Arrow.Flight.Server
{
    public class FlightServerRecordBatchStreamWriter : FlightRecordBatchStreamWriter, IServerStreamWriter<RecordBatch>
    {
        internal FlightServerRecordBatchStreamWriter(IServerStreamWriter<FlightData> clientStreamWriter) : base(clientStreamWriter, null)
        {
        }
    }
}
