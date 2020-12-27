using Google.Protobuf;

namespace Apache.Arrow.Flight
{
    public class FlightCriteria
    {
        internal static readonly FlightCriteria Empty = new FlightCriteria();

        private readonly Protocol.Criteria _criteria;

        internal FlightCriteria(Protocol.Criteria criteria)
        {
            _criteria = criteria;
        }

        public FlightCriteria()
        {
            _criteria = new Protocol.Criteria();
        }

        public FlightCriteria(string expression)
        {
            _criteria = new Protocol.Criteria()
            {
                Expression = ByteString.CopyFromUtf8(expression)
            };
        }

        public FlightCriteria(byte[] bytes)
        {
            _criteria = new Protocol.Criteria()
            {
                Expression = ByteString.CopyFrom(bytes)
            };
        }

        public FlightCriteria(ByteString byteString)
        {
            _criteria = new Protocol.Criteria()
            {
                Expression = byteString
            };
        }

        public ByteString Expression => _criteria.Expression;

        internal Protocol.Criteria ToProtocol()
        {
            return _criteria;
        }
    }
}
