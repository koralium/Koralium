using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Tests.Models
{
    public class ColumnTest
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

        public object P11 { get; set; }

        public object P12 { get; set; }

        public object P13 { get; set; }

        public object P14 { get; set; }

        public object P15 { get; set; }

        public object P16 { get; set; }

        public object P17 { get; set; }

        public object P18 { get; set; }

        public object P19 { get; set; }

        public object P20 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ColumnTest o)
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
                    Equals(P10, o.P10) &&
                    Equals(P11, o.P11) &&
                    Equals(P12, o.P12) &&
                    Equals(P13, o.P13) &&
                    Equals(P14, o.P14) &&
                    Equals(P15, o.P15) &&
                    Equals(P16, o.P16) &&
                    Equals(P17, o.P17) &&
                    Equals(P18, o.P18) &&
                    Equals(P19, o.P19) &&
                    Equals(P20, o.P20);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return P0.GetHashCode();
        }
    }
}
