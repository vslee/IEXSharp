using IEXSharp;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IEXSharpTest.V1
{
	public class MarketTest
	{
		private IEXRestV1Client prodClient;

		[SetUp]
		public void Setup()
		{
			prodClient = new IEXRestV1Client();
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task TOPSAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.TOPSAsync(symbols);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LastAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.LastAsync(symbols);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		public async Task HISTAsyncTest()
		{
			var response = await prodClient.Market.HISTAsync();

			Assert.IsNotNull(response);

			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		public async Task HISTByDateAsyncTest()
		{
			var response = await prodClient.Market.HISTByDateAsync(new DateTime(2019, 02, 25));

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepAsync(symbols);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepBookAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepBookAsync(symbols);

			Assert.IsNotNull(response);
		}
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradeAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepTradeAsync(symbols);

			Assert.IsNotNull(response);
		}

		[Test]
		public async Task DeepSystemEventAsyncTest()
		{
			var response = await prodClient.Market.DeepSystemEventAsync();

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradingStatusAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepTradingStatusAsync(symbols);

			Assert.IsNotNull(response);
		}
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepOperationHaltStatusAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepOperationHaltStatusAsync(symbols);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepShortSalePriceTestStatusAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepShortSalePriceTestStatusAsync(symbols);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepSecurityEventAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepSecurityEventAsync(symbols);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepTradeBreaksAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepTradeBreaksAsync(symbols);

			Assert.IsNotNull(response);
		}
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepActionAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepActionAsync(symbols);

			Assert.IsNotNull(response);
		}
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DeepOfficialPriceAsyncTest(params string[] symbols)
		{
			var response = await prodClient.Market.DeepOfficialPriceAsync(symbols);

			Assert.IsNotNull(response);
		}

		[Test]
		public async Task USMarketAsync()
		{
			var response = await prodClient.Market.USMarketVolumeAsync();

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}
	}
}