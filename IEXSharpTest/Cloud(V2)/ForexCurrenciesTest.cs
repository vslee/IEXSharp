using System.Linq;
using NUnit.Framework;
using System.Threading.Tasks;
using VSLee.IEXSharp;

namespace VSLee.IEXSharpTest.Cloud
{
	public class ForexCurrenciesTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
		}

		// Not supported for free account
		[Test]
		[TestCase("EUR", "USD")]
		public async Task ExchangeRateAsyncTest(string from, string to)
		{
			var response = await sandBoxClient.ForexCurrencies.ExchangeRateAsync(from, to);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("USDCAD")]
		[TestCase("USDCAD,USDGBP,USDJPY")]
		public async Task LatestRatesAsyncTest(string symbols)
		{
			var response = await sandBoxClient.ForexCurrencies.LatestRatesAsync(symbols);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			var data = response.Data.First();
			Assert.IsNotNull(data.symbol);
			Assert.IsNotNull(data.timestamp);
		}

		[Test]
		[TestCase("USDGBP", "99.00")]
		[TestCase("USDCAD,USDGBP,USDJPY", "7500.00")]
		public async Task ConvertAsyncTest(string symbols, string amount)
		{
			var response = await sandBoxClient.ForexCurrencies.ConvertAsync(symbols, amount);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			var data = response.Data.First();
			Assert.IsNotNull(data.symbol);
			Assert.IsNotNull(data.amount);
		}

		[Test]
		[TestCase("USDGBP", "last", "3")]
		[TestCase("USDCAD,USDGBP,USDJPY", "first", "5")]
		public async Task HistoricalDailyAsyncTest(string symbols, string query, string queryValue)
		{
			var response = await sandBoxClient.ForexCurrencies.HistoricalDailyAsync(symbols, query, queryValue);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			var data = response.Data.First();
			Assert.IsNotNull(data.First().rate);
			Assert.IsNotNull(data.First().date);
		}
	}
}
