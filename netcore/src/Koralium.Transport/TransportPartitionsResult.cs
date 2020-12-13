using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Koralium.Transport
{
    public class TransportPartitionsResult
    {
        public IImmutableList<Column> Columns { get; }

        public IImmutableList<TransportPartition> Partitions { get; }

        public TransportPartitionsResult(IImmutableList<Column> columns, IImmutableList<TransportPartition> partitions)
        {
            Columns = columns;
            Partitions = partitions;
        }
    }
}
