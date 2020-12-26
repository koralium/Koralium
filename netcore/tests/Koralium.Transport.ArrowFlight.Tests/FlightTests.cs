using Apache.Arrow;
using Apache.Arrow.Flight;
using Apache.Arrow.Flight.Client;
using Apache.Arrow.Types;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace Koralium.Transport.ArrowFlight.Tests
{
    public class FlightTests
    {
        FlightClient client;
        TestWebFactory testWebFactory;
        [OneTimeSetUp]
        public void Setup()
        {
            testWebFactory = new TestWebFactory();
            client = new Apache.Arrow.Flight.Client.FlightClient(testWebFactory.GetChannel());
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            testWebFactory.Stop();
        }

        [Test]
        public async Task Test1()
        {
            var flights = client.ListFlights();

            while (await flights.ResponseStream.MoveNext(default))
            {
                
            }
            Assert.Pass();
        }

        [Test]
        public async Task TestGetInfoOrdersAllColumns()
        {
            var expectedDescriptor = FlightDescriptor.CreateCommandDescriptor("select * from orders");
            var actualFlightInfo = await client.GetInfo(expectedDescriptor);

            var expectedSchema = new Schema.Builder()
                .Field(new Field("orderkey", Int64Type.Default, false))
                .Field(new Field("custkey", Int64Type.Default, false))
                .Field(new Field("orderstatus", StringType.Default, true))
                .Field(new Field("totalprice", DoubleType.Default, false))
                .Field(new Field("orderdate", TimestampType.Default, false))
                .Field(new Field("orderpriority", StringType.Default, true))
                .Field(new Field("clerk", StringType.Default, true))
                .Field(new Field("shippriority", Int32Type.Default, false))
                .Field(new Field("comment", StringType.Default, true))
                .Build();

            var expectedEndpoints = new List<FlightEndpoint>()
            {
                new FlightEndpoint(new FlightTicket("SELECT * FROM orders"), new List<FlightLocation>(){
                })
            };

            var expectedFlightInfo = new FlightInfo(expectedSchema, expectedDescriptor, expectedEndpoints);

            FlightInfoComparer.Compare(expectedFlightInfo, actualFlightInfo);

            Assert.Pass(); //add pass here to skip warning, assertions are done in flight info comparer
        }

        [Test]
        public async Task TestGetInfoOrdersSingleColumn()
        {
            var expectedDescriptor = FlightDescriptor.CreateCommandDescriptor("select orderkey from orders");
            var actualFlightInfo = await client.GetInfo(expectedDescriptor);

            var expectedSchema = new Schema.Builder()
                .Field(new Field("orderkey", Int64Type.Default, false))
                .Build();

            var expectedEndpoints = new List<FlightEndpoint>()
            {
                new FlightEndpoint(new FlightTicket("SELECT orderkey FROM orders"), new List<FlightLocation>(){
                })
            };

            var expectedFlightInfo = new FlightInfo(expectedSchema, expectedDescriptor, expectedEndpoints);

            FlightInfoComparer.Compare(expectedFlightInfo, actualFlightInfo);

            Assert.Pass(); //add pass here to skip warning, assertions are done in flight info comparer
        }

        [Test]
        public async Task TestGetPartitions()
        {
            var expectedDescriptor = FlightDescriptor.CreateCommandDescriptor("select orderkey from orders");

            Metadata metadata = new Metadata();
            metadata.Add("enable-partitions", "true");

            var actualFlightInfo = await client.GetInfo(expectedDescriptor, metadata);

            var expectedSchema = new Schema.Builder()
                .Field(new Field("orderkey", Int64Type.Default, false))
                .Build();

            var expectedEndpoints = new List<FlightEndpoint>()
            {
                new FlightEndpoint(new FlightTicket("SELECT orderkey FROM orders WHERE Orderkey < 16001"), new List<FlightLocation>()),
                new FlightEndpoint(new FlightTicket("SELECT orderkey FROM orders WHERE (Orderkey >= 16001) AND (Orderkey < 32001)"), new List<FlightLocation>()),
                new FlightEndpoint(new FlightTicket("SELECT orderkey FROM orders WHERE Orderkey >= 48001"), new List<FlightLocation>())
            };

            var expectedFlightInfo = new FlightInfo(expectedSchema, expectedDescriptor, expectedEndpoints);

            FlightInfoComparer.Compare(expectedFlightInfo, actualFlightInfo);

            Assert.Pass(); //add pass here to skip warning, assertions are done in flight info comparer
        }

        [Test]
        public async Task TestGetStream()
        {
            Metadata headers = new Metadata();
            headers.Add("P_p1", "1");
            var getStream = client.GetStream(new FlightTicket("select * from orders where orderkey > @p1"), headers);

            await foreach(var recordBatch in getStream.ResponseStream)
            {

            }
        }
    }
}