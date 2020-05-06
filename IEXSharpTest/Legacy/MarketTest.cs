using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;

namespace IEXSharpTest.Legacy
{
	public class MarketTest
	{
		private IEXLegacyClient prodClient;

		[SetUp]
		public void Setup()
		{
			prodClient = new IEXLegacyClient();
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task TOPSAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.TOPSAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LastAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.LastAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task HISTAsyncTest()
		{
			var response = await prodClient.Market.HISTAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		public async Task HISTByDateAsyncTest()
		{
			var response = await prodClient.Market.HISTByDateAsync(new DateTime(2019, 02, 25));

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepBookAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepBookAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradeAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepTradeAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		public async Task DeepSystemEventAsyncTest()
		{
			var response = await prodClient.Market.DeepSystemEventAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradingStatusAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepTradingStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepOperationHaltStatusAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepOperationHaltStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepShortSalePriceTestStatusAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepShortSalePriceTestStatusAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepSecurityEventAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepSecurityEventAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradeBreaksAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepTradeBreaksAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepAuctionAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepAuctionAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepOfficialPriceAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepOfficialPriceAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
		}

		[Test]
		public async Task MarketUSAsync()
		{
			var response = await prodClient.Market.MarketVolumeUSAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}
	}
}