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

namespace Koralium.SqlToExpression.Tests.tpch
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
