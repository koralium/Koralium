using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Entities
{
    public class Secure
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Secure s)
            {
                return Name.Equals(s.Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
