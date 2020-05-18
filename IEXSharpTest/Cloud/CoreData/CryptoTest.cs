using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class CryptoTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
		}

		[Test]
		[TestCase("BTCUSD")]
		[TestCase("ETHUSD")]
		public async Task BookAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Crypto.BookAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.IsNotNull(response.Data.asks);
			Assert.IsNotNull(response.Data.asks.First().price);

			Assert.IsNotNull(response.Data.bids);
			Assert.IsNotNull(response.Data.bids.First().price);
		}

		[Test]
		[TestCase(new object[] { "btcusdt" })]
		[TestCase(new object[] { "btcusdt", "ethusdt" })]
		public async Task CryptoEventSSETest(object[] symbols)
		{
			using (var sseClient = sandBoxClient.Crypto.SubscribeCryptoEvents(
										symbols.Cast<string>()))
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
		[TestCase("BTCUSD")]
		[TestCase("ETHUSD")]
		public async Task PriceAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Crypto.PriceAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.IsNotNull(response.Data.price);
			Assert.IsNotNull(response.Data.symbol);
		}

		[Test]
		[TestCase("BTCUSDT")]
		[TestCase("ETHUSD")]
		public async Task QuoteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Crypto.QuoteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.IsNotNull(response.Data.symbol);
			Assert.IsNotNull(response.Data.latestPrice);
		}

		[Test]
		[TestCase(new object[] { "btcusdt" })]
		[TestCase(new object[] { "btcusdt", "ethusdt" })]
		public async Task CryptoQuoteSSETest(object[] symbols)
		{
			using (var sseClient = sandBoxClient.Crypto.SubscribeCryptoQuotes(
										symbols.Cast<string>()))
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
	}
}