using System.Collections.Generic;
using Apache.Arrow.Flight.Internal;

namespace Apache.Arrow.Flight
{
    public class FlightInfo
    {
        internal FlightInfo(Protocol.FlightInfo flightInfo)
        {
            Schema = FlightMessageSerializer.DecodeSchema(flightInfo.Schema.Memory);
            Descriptor = new FlightDescriptor(flightInfo.FlightDescriptor);

            var endpoints = new List<FlightEndpoint>();
            foreach(var endpoint in flightInfo.Endpoint)
            {
                endpoints.Add(new FlightEndpoint(endpoint));
            }
            Endpoints = endpoints;

            TotalBytes = flightInfo.TotalBytes;
            TotalRecords = flightInfo.TotalRecords;
        }

        public FlightInfo(Schema schema, FlightDescriptor descriptor, IReadOnlyList<FlightEndpoint> endpoints, long totalRecords = 0, long totalBytes = 0)
        {
            Schema = schema;
            Descriptor = descriptor;
            Endpoints = endpoints;
            TotalBytes = totalBytes;
            TotalRecords = totalRecords;
        }

        public FlightDescriptor Descriptor { get; }

        public Schema Schema { get; }

        public long TotalBytes { get; }

        public long TotalRecords { get; }

        public IReadOnlyList<FlightEndpoint> Endpoints { get; }

        internal Protocol.FlightInfo ToProtocol()
        {
            var serializedSchema = SchemaWriter.SerializeSchema(Schema);
            var response = new Protocol.FlightInfo()
            {
                Schema = serializedSchema,
                FlightDescriptor = Descriptor.ToProtocol()
            };

            foreach(var endpoint in Endpoints)
            {
                response.Endpoint.Add(endpoint.ToProtocol());
            }

            return response;
        }
    }
}
