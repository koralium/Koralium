using Data.Koralium.Client;
using Data.Koralium.Client.Decoders;
using Koralium.WebTests;
using Koralium.WebTests.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Data.Koralium.Tests
{
    public class ClientTests
    {
        private TestWebFactory webFactory;
        [SetUp]
        public void Setup()
        {
            webFactory = new TestWebFactory();
        }

        [Test]
        public void TestSelectString()
        {
            KoraliumConnectionStringBuilder builder = new KoraliumConnectionStringBuilder();
            builder.DataSource = webFactory.GetUrl();

            KoraliumConnection connection = new KoraliumConnection();
            connection.ConnectionString = builder.ConnectionString;
            connection.Open();

            var cmd = connection.CreateCommand();

            cmd.CommandText = "select * from project";

            var reader = cmd.ExecuteReader();

            var nameOrdinal = reader.GetOrdinal("name");
            while (reader.Read())
            {
                var company = reader.GetFieldValue<Company>(0);
            }
        }

        [Test]
        public void TestExecuteScalarCount()
        {
            KoraliumConnectionStringBuilder builder = new KoraliumConnectionStringBuilder();
            builder.DataSource = webFactory.GetUrl();

            KoraliumConnection connection = new KoraliumConnection();
            connection.ConnectionString = builder.ConnectionString;
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "select count(*) from project";
            var value = cmd.ExecuteScalar();

            Assert.AreEqual(2, value);
        }
    }
}