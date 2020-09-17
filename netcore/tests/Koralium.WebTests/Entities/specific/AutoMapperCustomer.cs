using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Entities.specific
{
    /// <summary>
    /// This is used to test scenarios where automapper maps a list in entity framework into a class.
    /// This causes problems with aggregations.
    /// </summary>
    public class AutoMapperCustomer
    {
        public long Custkey { get; set; }

        public string Name { get; set; }

        public List<long> OrderKeys { get; set; }
    }
}
