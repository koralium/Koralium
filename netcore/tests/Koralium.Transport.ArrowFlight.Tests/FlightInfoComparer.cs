using Apache.Arrow.Flight;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Tests
{
    public static class FlightInfoComparer
    {
        public static void Compare(FlightInfo expected, FlightInfo actual)
        {
            //Check endpoints
            Assert.AreEqual(expected.Endpoints, actual.Endpoints);

            //Check flight descriptor
            Assert.AreEqual(expected.Descriptor, actual.Descriptor);

            //Check schema
            SchemaComparer.Compare(expected.Schema, actual.Schema);

            Assert.AreEqual(expected.TotalBytes, actual.TotalBytes);

            Assert.AreEqual(expected.TotalRecords, actual.TotalRecords);
        }
    }
}
