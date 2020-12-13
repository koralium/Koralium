using Koralium.SqlParser.Statements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium
{
    public class PartitionsBuilder
    {
        internal PartitionsBuilder(StatementList sqlTree)
        {
            SqlTree = sqlTree;
        }

        public StatementList SqlTree { get; }

        public PartitionBuilder NewPartition()
        {
            return new PartitionBuilder(SqlTree.Clone() as StatementList);
        }
    }
}
