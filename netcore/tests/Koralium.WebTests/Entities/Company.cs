using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Entities
{
    public class Company
    {
        public string CompanyId { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Company other)
            {
                return CompanyId == other.CompanyId &&
                    Name == other.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CompanyId, Name);
        }
    }
}
