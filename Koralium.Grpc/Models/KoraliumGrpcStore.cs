using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Grpc.Models
{
    /// <summary>
    /// Internal store for grpc specific data
    /// </summary>
    public class KoraliumGrpcStore
    {
        internal TableMetadataResponse TableMetadataResponse { get; set; }

        public KoraliumGrpcStore()
        {

        }
    }
}
