using Koralium.Data.ArrowFlight;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Tests
{
    public class TypeTests
    {
        private TestWebFactory webFactory;
        [OneTimeSetUp]
        public void Setup()
        {
            webFactory = new TestWebFactory();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            webFactory.Stop();
        }

        [Test]
        public void TestGetDecimalValueGetFieldValue()
        {
            KoraliumConnectionStringBuilder builder = new KoraliumConnectionStringBuilder();
            builder.DataSource = webFactory.GetUrl();

            KoraliumConnection connection = new KoraliumConnection();
            connection.ConnectionString = builder.ConnectionString;
            connection.Open();

            var cmd = connection.CreateCommand();

            cmd.CommandText = "select decimalvalue from typetest";

            var reader = cmd.ExecuteReader();

            var decimalordinal = reader.GetOrdinal("decimalvalue");

            List<decimal> actual = new List<decimal>();
            while (reader.Read())
            {
                var val = reader.GetFieldValue<decimal>(decimalordinal);
                actual.Add(val);
            }

            List<decimal> expected = new List<decimal>
            {
                1,
                3,
                17,
                1,
                3
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetDecimalValueGetValue()
        {
            KoraliumConnectionStringBuilder builder = new KoraliumConnectionStringBuilder();
            builder.DataSource = webFactory.GetUrl();

            KoraliumConnection connection = new KoraliumConnection();
            connection.ConnectionString = builder.ConnectionString;
            connection.Open();

            var cmd = connection.CreateCommand();

            cmd.CommandText = "select decimalvalue from typetest";

            var reader = cmd.ExecuteReader();

            var decimalordinal = reader.GetOrdinal("decimalvalue");

            List<object> actual = new List<object>();
            while (reader.Read())
            {
                var val = reader.GetValue(decimalordinal);
                actual.Add(val);
            }

            List<decimal> expected = new List<decimal>
            {
                1,
                3,
                17,
                1,
                3
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDecimalValueGetDataTypeName()
        {
            KoraliumConnectionStringBuilder builder = new KoraliumConnectionStringBuilder();
            builder.DataSource = webFactory.GetUrl();

            KoraliumConnection connection = new KoraliumConnection();
            connection.ConnectionString = builder.ConnectionString;
            connection.Open();

            var cmd = connection.CreateCommand();

            cmd.CommandText = "select decimalvalue from typetest";

            var reader = cmd.ExecuteReader();

            string actual = reader.GetDataTypeName(0);

            Assert.AreEqual("decimal", actual);
        }
    }
   
}
