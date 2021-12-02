using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Entities
{
    public class SpecialCharactersTest
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is SpecialCharactersTest c)
            {
                return Name.Equals(c.Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
