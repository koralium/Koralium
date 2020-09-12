using System;

namespace Koralium.WebTests.Entities
{
    public class OtherObject
    {
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override bool Equals(object obj)
        {
            if (obj is OtherObject otherObject)
            {
                return otherObject.Name == Name;
            }
            return this.Equals(obj);
        }
    }
}
