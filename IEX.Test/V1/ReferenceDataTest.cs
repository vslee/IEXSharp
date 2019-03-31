using IEXClient;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace IEX.Test.V1
{
    public class ReferenceDataTest
    {
        private IEXRestV1Client prodClient;

        [SetUp]
        public void Setup()
        {
            prodClient = new IEXRestV1Client();
        }

        [Test]
        public async Task SymbolsAsyncTest()
        {
            var resposne = await prodClient.ReferenceData.SymbolsAsync();

            Assert.IsNotNull(resposne);
            Assert.GreaterOrEqual(resposne.Count(), 1);
        }

        [Test]
        public async Task IEXCorporateActionsAsyncTest()
        {
            var resposne = await prodClient.ReferenceData.IEXCorporateActionsAsync();

            Assert.IsNotNull(resposne);
            Assert.GreaterOrEqual(resposne.Count(), 1);
        }

        [Test]
        public async Task IEXDividentsAsyncTest()
        {
            var resposne = await prodClient.ReferenceData.IEXDividentsAsync();

            Assert.IsNotNull(resposne);
            Assert.GreaterOrEqual(resposne.Count(), 1);
        }

        [Test]
        public async Task IEXNextDayExDateAsyncTest()
        {
            var resposne = await prodClient.ReferenceData.IEXNextDayExDateAsync();

            Assert.IsNotNull(resposne);
            Assert.GreaterOrEqual(resposne.Count(), 1);
        }

        [Test]
        public async Task IEXListedSymbolDirectoryAsyncTest()
        {
            var resposne = await prodClient.ReferenceData.IEXListedSymbolDirectoryAsync();

            Assert.IsNotNull(resposne);
            Assert.GreaterOrEqual(resposne.Count(), 1);
        }
    }
}