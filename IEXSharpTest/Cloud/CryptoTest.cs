using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;

namespace IEXSharpTest.Cloud
{
	public class CryptoTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
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
	}
}