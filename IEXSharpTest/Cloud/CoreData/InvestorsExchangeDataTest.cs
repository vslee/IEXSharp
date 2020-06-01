using System;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class InvestorsExchangeDataTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		public async Task DeepStreamTest(string symbol)
		{
			using (var sseClient = sandBoxClient.InvestorsExchangeDataService.DeepStream(symbol))
			{
				sseClient.Error += (s, e) =>
				{
					sseClient.Close();
					Assert.Fail("EventSource Error Occurred. Details: {0}", e.Exception.Message);
				};
				sseClient.MessageReceived += (s, m) =>
				{
					sseClient.Close();
					Assert.Pass(m.ToString());
				};
				await sseClient.StartAsync();
			}
		}

		[Test]
		[TestCase("ziext")]
		public async Task DeepAuctionAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepAuctionAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepBookAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepBookAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepOperationHaltStatusAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepOperationHaltStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepOfficialPriceAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepOfficialPriceAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepSecurityEventAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepSecurityEventAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepShortSalePriceTestStatusAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepShortSalePriceTestStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		public async Task DeepSystemEventAsyncTest()
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepSystemEventAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradeAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepTradeAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradeBreaksAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepTradeBreaksAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradingStatusAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.DeepTradingStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LastAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.LastAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task ListedRegulationSHOThresholdSecuritiesListAsyncTest(string symbol)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.ListedRegulationSHOThresholdSecuritiesListAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task ListedShortInterestListAsyncTest(string symbol)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.ListedShortInterestListAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("201902")]
		[TestCase("201900225")]
		public async Task StatsHistoricalDailyByDateAsyncTest(string date)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.StatsHistoricalDailyByDateAsync(date);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		public async Task StatsHistoricalDailyByLastAsync(int last)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.StatsHistoricalDailyByLastAsync(last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task StatsHistoricalSummaryAsyncTest()
		{
			var response1 = await sandBoxClient.InvestorsExchangeDataService.StatsHistoricalSummaryAsync();
			var response2 = await sandBoxClient.InvestorsExchangeDataService.StatsHistoricalSummaryAsync(new DateTime(2019, 02, 01));

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
			var response = await sandBoxClient.InvestorsExchangeDataService.StatsIntradayAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		public async Task StatsRecentAsyncTest()
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.StatsRecentAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task StatsRecordAsyncTest()
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.StatsRecordAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task TOPSAsyncTest(params string[] symbols)
		{
			var response = await sandBoxClient.InvestorsExchangeDataService.TOPSAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}