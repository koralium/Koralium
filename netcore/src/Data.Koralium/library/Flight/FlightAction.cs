using Google.Protobuf;

namespace Apache.Arrow.Flight
{
    public class FlightAction
    {
        private readonly Protocol.Action _action;
        internal FlightAction(Protocol.Action action)
        {
            _action = action;
        }

        public FlightAction(string type, ByteString body)
        {
            _action = new Protocol.Action()
            {
                Body = body,
                Type = type
            };
        }

        public FlightAction(string type, string body)
        {
            _action = new Protocol.Action()
            {
                Body = ByteString.CopyFromUtf8(body),
                Type = type
            };
        }

        public FlightAction(string type, byte[] body)
        {
            _action = new Protocol.Action()
            {
                Body = ByteString.CopyFrom(body),
                Type = type
            };
        }

        public FlightAction(string type)
        {
            _action = new Protocol.Action()
            {
                Type = type
            };
        }

        public string Type => _action.Type;

        public ByteString Body => _action.Body;

        internal Protocol.Action ToProtocol()
        {
            return _action;
        }
    }
}
