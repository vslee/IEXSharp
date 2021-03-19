using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.CoreData.StockPrices.Request;
using IEXSharp.Model.Shared.Request;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class StockResearchResearchTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.publishableToken, secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AACG")]
		[TestCase("AACQ")]
		[TestCase("AACQU")]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task AdvancedStatsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockResearch.AdvancedStatsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			// Removing these, as AACQU brings back everything as null, except for the company name
			//Assert.NotNull(response.Data.marketcap);
			//Assert.NotNull(response.Data.beta);
			Assert.NotNull(response.Data.companyName);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task AnalystRecommendationsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockResearch.AnalystRecommendationsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.NotNull(response.Data.FirstOrDefault()?.ratingBuy);
			Assert.NotNull(response.Data.FirstOrDefault()?.consensusStartDate);
		}

		[Test]
		[TestCase("AAPL", Period.Quarter, 1)]
		[TestCase("FB", Period.Quarter, 2)]
		[TestCase("AAPL", Period.Annual, 1)]
		[TestCase("AAPL", Period.Annual, 2)]
		public async Task EstimateAsyncTest(string symbol, Period period, int last)
		{
			var response = await sandBoxClient.StockResearch.EstimatesAsync(symbol, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.estimates.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "consensusEPS", Period.Quarter, 1)]
		[TestCase("FB", "consensusEPS", Period.Quarter, 2)]
		[TestCase("AAPL", "consensusEPS", Period.Annual, 1)]
		[TestCase("AAPL", "consensusEPS", Period.Annual, 2)]
		public async Task EstimateFieldAsyncTest(string symbol, string field, Period period, int last)
		{
			var response = await sandBoxClient.StockResearch.EstimateFieldAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		/// <summary> Not supported for free account </summary>
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task FundOwnershipAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockResearch.FundOwnershipAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		/// <summary> Not supported for free account </summary>
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task InstitutionalOwnerShipAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockResearch.InstitutionalOwnerShipAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AACG")]
		[TestCase("AACQ")]
		[TestCase("AACQU")]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task KeyStatsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockResearch.KeyStatsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "nextEarningsDate")]
		[TestCase("AAPL", "marketcap")]
		[TestCase("FB", "nextEarningsDate")]
		public async Task KeyStatsStatAsync(string symbol, string stat)
		{
			var response = await sandBoxClient.StockResearch.KeyStatsStatAsync(symbol, stat);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PriceTargetAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockResearch.PriceTargetAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "adxr", ChartRange.FiveDayMinute, false, false)]
		[TestCase("FB", "abs", ChartRange.FiveDayMinute, true, false)]
		[TestCase("GME", "rsi", ChartRange.FiveDayMinute, false, true)]
		public async Task TechnicalIndicatorsAsyncTest(string symbol, string indicator, ChartRange range, bool lastIndicator = false, bool indicatorOnly = false)
		{
			var response = await sandBoxClient.StockResearch.TechnicalIndicatorsAsync(symbol, indicator, range, lastIndicator, indicatorOnly);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}
