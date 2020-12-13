using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport
{
    public class TransportPartition
    {
        /// <summary>
        /// The locations that the data can be collected from.
        /// If left null they are assumed to be collected from the current location.
        /// </summary>
        public IReadOnlyList<TransportServiceLocation> Locations { get; }

        /// <summary>
        /// The sql that is used to query the partition.
        /// </summary>
        public string Sql { get; }

        public TransportPartition(IReadOnlyList<TransportServiceLocation> locations, string sql)
        {
            Locations = locations;
            Sql = sql;
        }
    }
}
