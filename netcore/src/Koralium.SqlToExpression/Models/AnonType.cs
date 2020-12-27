/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;

namespace Koralium.SqlToExpression.Models
{
    public class AnonType
    {

    }

    public class AnonType<P_0>
    {
        public P_0 P0 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0> o)
            {
                return Equals(P0, o.P0);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(P0);
        }
    }

    public class AnonType<P_0, P_1>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1> o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0, 
                P1);
        }
    }

    public class AnonType<P_0, P_1, P_2>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2> o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1) &&
                    Equals(P2, o.P2);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3> o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1) &&
                    Equals(P2, o.P2) &&
                    Equals(P3, o.P3);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4> o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1) &&
                    Equals(P2, o.P2) &&
                    Equals(P3, o.P3) &&
                    Equals(P4, o.P4);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5> o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1) &&
                    Equals(P2, o.P2) &&
                    Equals(P3, o.P3) &&
                    Equals(P4, o.P4) &&
                    Equals(P5, o.P5);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6> o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1) &&
                    Equals(P2, o.P2) &&
                    Equals(P3, o.P3) &&
                    Equals(P4, o.P4) &&
                    Equals(P5, o.P5) &&
                    Equals(P6, o.P6);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7> o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1) &&
                    Equals(P2, o.P2) &&
                    Equals(P3, o.P3) &&
                    Equals(P4, o.P4) &&
                    Equals(P5, o.P5) &&
                    Equals(P6, o.P6) &&
                    Equals(P7, o.P7);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8> o)
            {
                return Equals(P0, o.P0) &&
                    Equals(P1, o.P1) &&
                    Equals(P2, o.P2) &&
                    Equals(P3, o.P3) &&
                    Equals(P4, o.P4) &&
                    Equals(P5, o.P5) &&
                    Equals(P6, o.P6) &&
                    Equals(P7, o.P7) &&
                    Equals(P8, o.P8);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9> o)
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
                    Equals(P9, o.P9);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10> o)
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
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11> o)
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
                    Equals(P11, o.P11);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12> o)
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
                    Equals(P12, o.P12);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13> o)
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
                    Equals(P13, o.P13);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14> o)
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
                    Equals(P14, o.P14);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public P_15 P15 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15> o)
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
                    Equals(P15, o.P15);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public P_15 P15 { get; set; }

        public P_16 P16 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16> o)
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
                    Equals(P16, o.P16);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public P_15 P15 { get; set; }

        public P_16 P16 { get; set; }

        public P_17 P17 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17> o)
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
                    Equals(P17, o.P17);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public P_15 P15 { get; set; }

        public P_16 P16 { get; set; }

        public P_17 P17 { get; set; }

        public P_18 P18 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18> o)
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
                    Equals(P18, o.P18);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public P_15 P15 { get; set; }

        public P_16 P16 { get; set; }

        public P_17 P17 { get; set; }

        public P_18 P18 { get; set; }

        public P_19 P19 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19> o)
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
                    Equals(P19, o.P19);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19, P_20>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public P_15 P15 { get; set; }

        public P_16 P16 { get; set; }

        public P_17 P17 { get; set; }

        public P_18 P18 { get; set; }

        public P_19 P19 { get; set; }

        public P_20 P20 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19, P_20> o)
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
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19, P_20, P_21>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public P_15 P15 { get; set; }

        public P_16 P16 { get; set; }

        public P_17 P17 { get; set; }

        public P_18 P18 { get; set; }

        public P_19 P19 { get; set; }

        public P_20 P20 { get; set; }

        public P_21 P21 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19, P_20, P_21> o)
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
                    Equals(P20, o.P20) &&
                    Equals(P21, o.P21);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }

    public class AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19, P_20, P_21, P_22>
    {
        public P_0 P0 { get; set; }

        public P_1 P1 { get; set; }

        public P_2 P2 { get; set; }

        public P_3 P3 { get; set; }

        public P_4 P4 { get; set; }

        public P_5 P5 { get; set; }

        public P_6 P6 { get; set; }

        public P_7 P7 { get; set; }

        public P_8 P8 { get; set; }

        public P_9 P9 { get; set; }

        public P_10 P10 { get; set; }

        public P_11 P11 { get; set; }

        public P_12 P12 { get; set; }

        public P_13 P13 { get; set; }

        public P_14 P14 { get; set; }

        public P_15 P15 { get; set; }

        public P_16 P16 { get; set; }

        public P_17 P17 { get; set; }

        public P_18 P18 { get; set; }

        public P_19 P19 { get; set; }

        public P_20 P20 { get; set; }

        public P_21 P21 { get; set; }

        public P_22 P22 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AnonType<P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19, P_20, P_21, P_22> o)
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
                    Equals(P20, o.P20) &&
                    Equals(P21, o.P21) &&
                    Equals(P22, o.P22);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P0,
                P1,
                P2,
                P3,
                P4,
                P5,
                P6,
                P7);
        }
    }
}
