namespace Koralium.SqlToExpression.Models
{
    public class AnonType
    {
        public object P0 { get; set; }

        public object P1 { get; set; }

        public object P2 { get; set; }

        public object P3 { get; set; }

        public object P4 { get; set; }

        public object P5 { get; set; }

        public object P6 { get; set; }

        public object P7 { get; set; }

        public object P8 { get; set; }

        public object P9 { get; set; }

        public object P10 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1) &&
                    Equals(P2, o.P2) &&
                    Equals(P3, o.P3) &&
                    Equals(P4, o.P4) &&
                    Equals(P5, o.P5) &&
                    Equals(P6, o.P6) &&
                    Equals(P7, o.P7) &&
                    Equals(P8, o.P8) &&
                    Equals(P9, o.P9) &&
                    Equals(P10, o.P10);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return P0.GetHashCode();
        }
    }
}
