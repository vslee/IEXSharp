using NUnit.Framework;
using System;
using System.Threading.Tasks;
using IEXClient;

namespace IEX.Test
{
    public class AlternativeDataTest
    {
        private IEXRestV2Client sandBoxClient;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEXRestV2Client(TestGlobal.pk, TestGlobal.sk, false, true);
        }

        [Test]
        [TestCase("BTCUSDT")]
        public async Task CryptoAsyncTest(string symbol)
        {
            var response = await sandBoxClient.AlternativeData.CryptoAsync(symbol);

            Assert.IsNotNull(response);
        }

        // Not supported for free account
        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task SocialSentimentDailyAsyncTest(string symbol)
        {
            var response = await sandBoxClient.AlternativeData.SocialSentimentDailyAsync(symbol);

            Assert.IsNotNull(response);
        }

        // Not supported for free account
        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task SocialSentimentDailyDateAsyncTest(string symbol)
        {
            DateTime date = new DateTime(2019, 03, 30);
            var response = await sandBoxClient.AlternativeData.SocialSentimentDailyAsync(symbol, date);

            Assert.IsNotNull(response);
        }

        // Not supported for free account
        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task SocialSentimentMinuteAsyncTest(string symbol)
        {
            var response = await sandBoxClient.AlternativeData.SocialSentimentMinuteAsync(symbol);

            Assert.IsNotNull(response);
        }

        // Not supported for free account
        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task SocialSentimentMinuteDateAsyncTest(string symbol)
        {
            DateTime date = new DateTime(2019, 03, 30);
            var response = await sandBoxClient.AlternativeData.SocialSentimentMinuteAsync(symbol, date);

            Assert.IsNotNull(response);
        }

        // Not supported for free account
        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task CEOCompensationAsyncTest(string symbol)
        {
            var response = await sandBoxClient.AlternativeData.CEOCompensationAsync(symbol);

            Assert.IsNotNull(response);
        }
    }
}