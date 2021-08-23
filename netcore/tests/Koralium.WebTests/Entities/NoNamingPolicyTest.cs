using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Entities
{
    public class NoPolicyInner
    {
        public string Name { get; set; }
    }
    public class NoNamingPolicyTest
    {
        public NoPolicyInner Object { get; set; }
    }
}
