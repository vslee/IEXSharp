using IEX.V2.Model.Account;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class AccountTest
    {
        private IEX.V2.IEXClient client;

        [SetUp]
        public void Setup()
        {
            client = new IEX.V2.IEXClient(Environment.GetEnvironmentVariable("PublicToken"), 
                Environment.GetEnvironmentVariable("SecretToken"));
        }

        [Test]
        public void MetadataTest()
        {
            MetadataResponse response = client.Account.Metadata();

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task MetadataAsyncTest()
        {
            MetadataResponse response = await client.Account.MetadataAsync();

            Assert.IsNotNull(response);
        }
    }
}