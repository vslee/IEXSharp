using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;

namespace IEXSharpTest.Cloud
{
	public class InvestorsExchangeDataTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("ziext")]
		public async Task DeepAuctionAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepAuctionAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepBookAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepBookAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepOperationHaltStatusAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepOperationHaltStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepOfficialPriceAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepOfficialPriceAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepSecurityEventAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepSecurityEventAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepShortSalePriceTestStatusAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepShortSalePriceTestStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		public async Task DeepSystemEventAsyncTest()
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepSystemEventAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradeAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepTradeAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradeBreaksAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepTradeBreaksAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradingStatusAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.DeepTradingStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LastAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.LastAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task ListedRegulationSHOThresholdSecuritiesListAsyncTest(string symbol)
		{
			var response = await sandBoxClient.InvestorsExchangeData.ListedRegulationSHOThresholdSecuritiesListAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task ListedShortInterestListAsyncTest(string symbol)
		{
			var response = await sandBoxClient.InvestorsExchangeData.ListedShortInterestListAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("201902")]
		[TestCase("201900225")]
		public async Task StatsHistoricalDailyByDateAsyncTest(string date)
		{
			var response = await sandBoxClient.InvestorsExchangeData.StatsHistoricalDailyByDateAsync(date);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		public async Task StatsHistoricalDailyByLastAsync(int last)
		{
			var response = await sandBoxClient.InvestorsExchangeData.StatsHistoricalDailyByLastAsync(last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task StatsHistoricalSummaryAsyncTest()
		{
			var response1 = await sandBoxClient.InvestorsExchangeData.StatsHistoricalSummaryAsync();
			var response2 = await sandBoxClient.InvestorsExchangeData.StatsHistoricalSummaryAsync(new DateTime(2019, 02, 01));

			Assert.IsNull(response1.ErrorMessage);
			Assert.IsNotNull(response1.Data);
			Assert.GreaterOrEqual(response1.Data.Count(), 1);
			Assert.IsNull(response2.ErrorMessage);
			Assert.IsNotNull(response2.Data);
			Assert.GreaterOrEqual(response2.Data.Count(), 1);
		}

		[Test]
		public async Task StatsIntradayAsyncTest()
		{
			var response = await sandBoxClient.InvestorsExchangeData.StatsIntradayAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		public async Task StatsRecentAsyncTest()
		{
			var response = await sandBoxClient.InvestorsExchangeData.StatsRecentAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task StatsRecordAsyncTest()
		{
			var response = await sandBoxClient.InvestorsExchangeData.StatsRecordAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task TOPSAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeData.TOPSAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}