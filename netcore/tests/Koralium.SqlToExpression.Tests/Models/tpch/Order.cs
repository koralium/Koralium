using Newtonsoft.Json;
using System;

namespace Koralium.SqlToExpression.Tests.tpch
{
    public class Order
    {
        public long Orderkey { get; set; }

        public long Custkey { get; set; }

        public string Orderstatus { get; set; }

        public double Totalprice { get; set; }

        public DateTime Orderdate { get; set; }

        public string Orderpriority { get; set; }

        public string Clerk { get; set; }

        public int Shippriority { get; set; }

        public string Comment { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Order o)
            {
                return Orderkey.Equals(o.Orderkey) &&
                    Custkey.Equals(o.Custkey) &&
                    Orderstatus.Equals(o.Orderstatus) &&
                    Totalprice.Equals(o.Totalprice) &&
                    Orderdate.Equals(o.Orderdate) &&
                    Orderpriority.Equals(o.Orderpriority) &&
                    Clerk.Equals(o.Clerk) &&
                    Shippriority.Equals(o.Shippriority) &&
                    Comment.Equals(o.Comment);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Orderkey, Custkey, Orderstatus, Totalprice, Orderdate, Orderpriority, Clerk, Shippriority);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
