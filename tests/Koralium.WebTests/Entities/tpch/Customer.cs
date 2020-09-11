using System;

namespace Koralium.WebTests.Entities.tpch
{
    public class Customer
    {
        public long Custkey { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public long Nationkey { get; set; }

        public string Phone { get; set; }

        public double Acctbal { get; set; }

        public string Mktsegment { get; set; }

        public string Comment { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Customer c)
            {
                return Custkey.Equals(c.Custkey) &&
                    Name.Equals(c.Name) &&
                    Address.Equals(c.Address) &&
                    Nationkey.Equals(c.Nationkey) &&
                    Phone.Equals(c.Phone) &&
                    Acctbal.Equals(c.Acctbal) &&
                    Mktsegment.Equals(c.Mktsegment) &&
                    Comment.Equals(c.Comment);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                Custkey,
                Name,
                Address,
                Nationkey, 
                Phone, 
                Acctbal, 
                Mktsegment, 
                Comment);
        }
    }
}
