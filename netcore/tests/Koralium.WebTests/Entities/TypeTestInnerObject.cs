using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Entities
{
    public class TypeTestInnerObject
    {
        public string StringValue { get; set; }

        public List<int> IntList { get; set; }

        public TypeTestInnerInnerObject Object { get; set; }
    }
}
