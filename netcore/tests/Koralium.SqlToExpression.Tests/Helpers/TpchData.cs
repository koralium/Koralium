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
using CsvHelper;
using Koralium.SqlToExpression.Tests.tpch;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Koralium.SqlToExpression.Tests
{
    public class TpchData
    {
        public List<Customer> Customers { get; set; }
        public List<LineItem> LineItem { get; set; }
        public List<Nation> Nation { get; set; }
        public List<Order> Orders { get; set; }
        public List<Part> Part { get; set; }
        public List<Partsupp> Partsupp { get; set; }
        public List<Region> Region { get; set; }
        public List<Supplier> Supplier { get; set; }

        public Dictionary<long, Customer> CustomerKeyIndex { get; set; }

        public TpchData()
        {
            LoadTables();
            FixDates();
            BuildIndices();
        }

        private void BuildIndices()
        {
            CustomerKeyIndex = Customers.ToDictionary(x => x.Custkey);
        }

        private void LoadTables()
        {
            Customers = LoadData<Customer>("./Data/customer.csv");
            LineItem = LoadData<LineItem>("./Data/lineitem.csv");
            Nation = LoadData<Nation>("./Data/nation.csv");
            Orders = LoadData<Order>("./Data/orders.csv");
            Part = LoadData<Part>("./Data/part.csv");
            Partsupp = LoadData<Partsupp>("./Data/partsupp.csv");
            Region = LoadData<Region>("./Data/region.csv");
            Supplier = LoadData<Supplier>("./Data/supplier.csv");
        }


        private List<T> LoadData<T>(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

            return csv.GetRecords<T>().ToList();
        }

        private void FixDates()
        {
            Orders.ForEach(x =>
            {
                x.Orderdate = FixDate(x.Orderdate);
            });

            LineItem.ForEach(x =>
            {
                x.Commitdate = FixDate(x.Commitdate);
                x.Receiptdate = FixDate(x.Receiptdate);
                x.Shipdate = FixDate(x.Shipdate);
            });
        }

        private DateTime FixDate(DateTime time)
        {
            var utc = time.ToUniversalTime();
            TimeSpan diff = time.Subtract(utc);
            return utc.Add(diff);
        }
    }
}
