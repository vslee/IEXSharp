using NUnit.Framework;
using System.Threading.Tasks;
using VSLee.IEXSharp;

namespace VSLee.IEXSharpTest.Cloud
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
		[TestCase("BTCUSDT")]
		public async Task BookAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Crypto.BookAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("BTCUSDT")]
		public async Task PriceAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Crypto.PriceAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("BTCUSDT")]
		public async Task QuoteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Crypto.QuoteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}