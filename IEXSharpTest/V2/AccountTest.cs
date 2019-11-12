using NUnit.Framework;
using System.Threading.Tasks;
using IEXClient;
using IEXClient.Model.Account.Request;
using IEXClient.Model.Account.Response;

namespace IEXSharpTest.V2
{
    public class AccountTest
    {
        private IEXRestV2Client sandBoxClient;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEXRestV2Client(TestGlobal.pk, TestGlobal.sk, false, true);
        }

        [Test]
        public async Task MetadataAsyncTest()
        {
            MetadataResponse response = await sandBoxClient.Account.MetadataAsync();

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase(UsageType.All)]
        public async Task UsageAsyncTest(UsageType type)
        {
            UsageResponse response = await sandBoxClient.Account.UsageAsync(type);

            Assert.IsNotNull(response);
        }
    }
}