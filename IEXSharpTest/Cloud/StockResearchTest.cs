using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;

namespace IEXSharpTest.Cloud
{
	public class StockResearchResearchTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task AdvancedStatsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockResearch.AdvancedStatsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.NotNull(response.Data.marketcap);
			Assert.NotNull(response.Data.beta);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task AnalystRecommendationsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockResearch.AnalystRecommendationsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.NotNull(response.Data.FirstOrDefault()?.consensusEndDate);
			Assert.NotNull(response.Data.FirstOrDefault()?.consensusStartDate);
		}

		[Test]
		[TestCase("AAPL", 1)]
		[TestCase("FB", 2)]
		public async Task EstimateAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.StockResearch.EstimatesAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.estimates.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "consensusEPS", 1)]
		[TestCase("FB", "consensusEPS", 2)]
		public async Task EstimateFieldAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.StockResearch.EstimateFieldAsync(symbol, field, last);

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
		[TestCase("AAPL", "adxr")]
		[TestCase("FB", "abs")]
		public async Task TechnicalIndicatorsAsyncTest(string symbol, string indicator)
		{
			var response = await sandBoxClient.StockResearch.TechnicalIndicatorsAsync(symbol, indicator);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}
