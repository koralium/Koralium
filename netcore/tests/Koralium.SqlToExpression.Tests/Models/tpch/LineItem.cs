using System;

namespace Koralium.SqlToExpression.Tests.tpch
{
    public class LineItem
    {
        public long Orderkey { get; set; }

        public long Partkey { get; set; }

        public long Suppkey { get; set; }

        public int Linenumber { get; set; }

        public double Quantity { get; set; }

        public double Extendedprice { get; set; }

        public double Discount { get; set; }

        public double Tax { get; set; }

        public string Returnflag { get; set; }

        public string Linestatus { get; set; }

        public DateTime Shipdate { get; set; }

        public DateTime Commitdate { get; set; }

        public DateTime Receiptdate { get; set; }

        public string Shipinstruct { get; set; }

        public string Shipmode { get; set; }

        public string Comment { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is LineItem l)
            {
                return l.Comment == Comment &&
                    l.Commitdate == Commitdate &&
                    l.Discount == Discount &&
                    l.Extendedprice == Extendedprice &&
                    l.Linenumber == Linenumber &&
                    l.Linestatus == Linestatus &&
                    l.Orderkey == Orderkey &&
                    l.Partkey == Partkey &&
                    l.Quantity == Quantity &&
                    l.Receiptdate == Receiptdate &&
                    l.Returnflag == Returnflag &&
                    l.Shipdate == Shipdate &&
                    l.Shipinstruct == Shipinstruct &&
                    l.Shipmode == Shipmode &&
                    l.Suppkey == Suppkey &&
                    l.Tax == Tax;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Orderkey, Partkey, Suppkey, Linenumber);
        }
    }
}
