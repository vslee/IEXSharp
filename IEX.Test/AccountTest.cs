using IEX.V2.Model.Account.Request;
using IEX.V2.Model.Account.Response;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace IEX.Test
{
    public class AccountTest
    {
        private IEX.V2.IEXClient sandBoxClient;
        private IEX.V2.IEXClient prodClient;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEX.V2.IEXClient("Tpk_d1e87a5a345b434d8f151269fb62071b",
                "Tsk_73e92cf1e5b1432699f90a17c25f0f88", true);
            prodClient = new IEX.V2.IEXClient("pk_7c46062bc0aa4a8698a550dcbd788e3c",
                "sk_45d242d9d05a4f238082d6113c49529f", false);
        }

        [Test]
        public void MetadataTest()
        {
            MetadataResponse response = prodClient.Account.Metadata();

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task MetadataAsyncTest()
        {
            MetadataResponse response = await prodClient.Account.MetadataAsync();

            Assert.IsNotNull(response);
        }

        [Test]
        public void UsageTest()
        {
            UsageResponse allResponse = sandBoxClient.Account.Usage(UsageType.All);
            UsageResponse messageResponse = sandBoxClient.Account.Usage(UsageType.Messages);

            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.Usage(UsageType.AlertRecords));
            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.Usage(UsageType.Alerts));
            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.Usage(UsageType.RuleRecords));
            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.Usage(UsageType.Rules));
            Assert.IsNotNull(allResponse);
            Assert.IsNotNull(messageResponse);
            Assert.IsNotNull(messageResponse.messages);
        }

        [Test]
        public async Task UsageAsyncTest()
        {
            UsageResponse allResponse = await sandBoxClient.Account.UsageAsync(UsageType.All);
            UsageResponse messageResponse = await sandBoxClient.Account.UsageAsync(UsageType.Messages);

            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.UsageAsync(UsageType.AlertRecords));
            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.UsageAsync(UsageType.Alerts));
            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.UsageAsync(UsageType.RuleRecords));
            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.UsageAsync(UsageType.Rules));
            Assert.IsNotNull(allResponse);
            Assert.IsNotNull(messageResponse);
            Assert.IsNotNull(messageResponse.messages);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void PayAsYouGoTest(bool allow)
        {
            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.PayAsYouGo(allow));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task PayAsYouGoAsyncTest(bool allow)
        {
            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.PayAsYouGoAsync(allow));
        }
    }
}