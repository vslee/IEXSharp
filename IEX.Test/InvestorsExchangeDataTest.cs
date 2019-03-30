using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZH.Code.IEX.V2;

namespace IEX.Test
{
    public class InvestorsExchangeDataTest
    {
        private IEXRestV2Client sandBoxClient;
        private static IEnumerable<string> testSourceAAPL;
        private static IEnumerable<string> testSourceFB;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEXRestV2Client(TestGlobal.pk, TestGlobal.sk, false, true);
            testSourceAAPL = new string[] { "AAPL" };
            testSourceFB = new string[] { "FB" };
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepActionAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepActionAsync(symbols);

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepAsync(symbols);

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepBookAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepBookAsync(symbols);

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepOfficialPriceAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepOfficialPriceAsync(symbols);

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepSecurityEventAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepSecurityEventAsync(symbols);

            Assert.IsNotNull(response);
        }
        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepShortSalePriceTestStatusAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepShortSalePriceTestStatusAsync(symbols);

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task DeepSystemEventAsyncTest()
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepSystemEventAsync();

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepTradeAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepTradeAsync(symbols);

            Assert.IsNotNull(response);
        }


        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepTradeBreaksAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepTradeBreaksAsync(symbols);

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task DeepTradingStatusAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.DeepTradingStatusAsync(symbols);

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task LastAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.LastAsync(symbols);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Count(), 1);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task ListedRegulationSHOThresholdSecuritiesListAsyncTest(string symbol)
        {
            var response = await sandBoxClient.InvestorsExchangeData.ListedRegulationSHOThresholdSecuritiesListAsync(symbol);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Count(), 1);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task ListedShortInterestListAsyncTest(string symbol)
        {
            var response = await sandBoxClient.InvestorsExchangeData.ListedShortInterestListAsync(symbol);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Count(), 1);
        }

        [Test]
        [TestCase("201902")]
        [TestCase("201900225")]
        public async Task StatsHistoricalDailyByDateAsyncTest(string date)
        {
            var response = await sandBoxClient.InvestorsExchangeData.StatsHistoricalDailyByDateAsync(date);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Count(), 1);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public async Task StatsHistoricalDailyByLastAsync(int last)
        {
            var response = await sandBoxClient.InvestorsExchangeData.StatsHistoricalDailyByLastAsync(last);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Count(), 1);
        }

        [Test]
        public async Task StatsHistoricalSummaryAsyncTest()
        {
            var response1 = await sandBoxClient.InvestorsExchangeData.StatsHistoricalSummaryAsync();
            var response2 = await sandBoxClient.InvestorsExchangeData.StatsHistoricalSummaryAsync(new DateTime(2019, 02, 01));

            Assert.IsNotNull(response1);
            Assert.GreaterOrEqual(response1.Count(), 1);
            Assert.IsNotNull(response2);
            Assert.GreaterOrEqual(response2.Count(), 1);
        }

        [Test]
        public async Task StatsIntradayAsyncTest()
        {
            var response = await sandBoxClient.InvestorsExchangeData.StatsIntradayAsync();

            Assert.IsNotNull(response);
        }
        [Test]
        public async Task StatsRecentAsyncTest()
        {
            var response = await sandBoxClient.InvestorsExchangeData.StatsRecentAsync();

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Count(), 1);
        }
        [Test]
        public async Task StatsRecordAsyncTest()
        {
            var response = await sandBoxClient.InvestorsExchangeData.StatsRecordAsync();

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("AAPL")]
        [TestCase("FB")]
        public async Task TOPSAsyncTest(params string[] symbols)
        {
            var response = await sandBoxClient.InvestorsExchangeData.TOPSAsync(symbols);

            Assert.IsNotNull(response);
        }
    }
}
