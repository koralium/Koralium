using Google.Protobuf;

namespace Apache.Arrow.Flight
{
    public class FlightPutResult
    {
        public static readonly FlightPutResult Empty = new FlightPutResult();

        private readonly Protocol.PutResult _putResult;

        public FlightPutResult()
        {
            _putResult = new Protocol.PutResult();
        }

        public FlightPutResult(ByteString applicationMetadata)
        {
            _putResult = new Protocol.PutResult()
            {
                AppMetadata = applicationMetadata
            };
        }

        public FlightPutResult(byte[] applicationMetadata)
            : this(ByteString.CopyFrom(applicationMetadata))
        {
        }

        public FlightPutResult(string applicationMetadata)
            : this(ByteString.CopyFromUtf8(applicationMetadata))
        {
        }

        internal FlightPutResult(Protocol.PutResult putResult)
        {
            _putResult = putResult;
        }

        public ByteString ApplicationMetadata => _putResult.AppMetadata;

        internal Protocol.PutResult ToProtocol()
        {
            return _putResult;
        }
    }
}
