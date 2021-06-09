using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Tests.Models
{
    public class InnerObject
    {
        public string Name { get; set; }
    }
    public class ObjectTest
    {
        public InnerObject InnerObject { get; set; }
    }
}
