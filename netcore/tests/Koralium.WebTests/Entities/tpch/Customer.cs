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
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [KoraliumIgnore]
        [Ignore]
        [NotMapped]
        public List<Order> Orders { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Customer c)
            {
                return Custkey.Equals(c.Custkey) &&
                    Equals(Name, c.Name) &&
                    Equals(Address, c.Address) &&
                    Nationkey.Equals(c.Nationkey) &&
                    Equals(Phone, c.Phone) &&
                    Acctbal.Equals(c.Acctbal) &&
                    Equals(Mktsegment, c.Mktsegment) &&
                    Equals(Comment, c.Comment);
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
