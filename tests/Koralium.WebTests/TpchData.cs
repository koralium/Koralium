using CsvHelper;
using Koralium.WebTests.Entities.tpch;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Koralium.WebTests
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
