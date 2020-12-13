using Koralium.SqlParser.Statements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Models
{
    public class Partition
    {
        /// <summary>
        /// The locations that the data can be collected from.
        /// If left null they are assumed to be collected from the current location.
        /// </summary>
        public IReadOnlyList<ServiceLoction> Locations { get; }

        /// <summary>
        /// The sql that is used to query the partition.
        /// This should not modify other the query so it returns a different result than the user requested.
        /// Instead it should only add the required info to get data from a specific partition.
        /// </summary>
        public StatementList SqlTree { get; }

        public Partition(IReadOnlyList<ServiceLoction> locations, StatementList sqlTree)
        {
            Locations = locations;
            SqlTree = sqlTree;
        }
    }
}
