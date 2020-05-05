using System;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp.Helper;
using NUnit.Framework;
using VSLee.IEXSharp;
using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.StockPrices.Request;

namespace IEXSharpTest.Cloud
{
	public class StockPricesTest
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
		public async Task BookAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.BookAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.quote);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DelayedQuoteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.DelayedQuoteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("AAPL", ChartRange.OneYear)]
		[TestCase("AAPL", ChartRange.Max)]
		[TestCase("AAPL", ChartRange.Ytd)]
		[TestCase("AAPL", ChartRange.OneMonth)]
		public async Task HistoricalPriceAsync(string symbol,
			ChartRange range = ChartRange.OneMonth, QueryStringBuilder qsb = null)
		{
			var response = await sandBoxClient.StockPrices.HistoricalPriceAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
			Assert.IsNotEmpty(response.Data.First().date);
			Assert.Greater(response.Data.First().GetDateTimeInUTC(), DateTime.MinValue);
		}

		[Test]
		[TestCase("AAPL", ChartRange.Max)]
		public async Task HistoricalPriceNonZeroAsync(string symbol,
			ChartRange range = ChartRange.OneMonth, DateTime? date = null, QueryStringBuilder qsb = null)
		{
			var response = await sandBoxClient.StockPrices.HistoricalPriceAsync(symbol, range);
			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			foreach (var ohlc in response.Data)
			{
				Assert.NotZero(ohlc.open);
				Assert.NotZero(ohlc.high);
				Assert.NotZero(ohlc.low);
				Assert.NotZero(ohlc.close);
				Assert.NotZero(ohlc.volume);
				Assert.NotZero(ohlc.uOpen);
				Assert.NotZero(ohlc.uHigh);
				Assert.NotZero(ohlc.uLow);
				Assert.NotZero(ohlc.uClose);
				Assert.NotZero(ohlc.uVolume);
			}
		}

		[Test]
		[TestCase("AAPL", true)]
		[TestCase("AAPL", false)]
		public async Task HistoricalPriceAsyncDateTest(string symbol, bool chartByDay)
		{
			var response = await sandBoxClient.StockPrices.HistoricalPriceByDateAsync(symbol, getLatestWeekday(), chartByDay);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
			Assert.IsNotEmpty(response.Data.First().minute);
			Assert.Greater(response.Data.First().GetDateTimeInUTC(), DateTime.MinValue);
		}

		private static DateTime getLatestWeekday()
		{
			var latestWeekday = DateTime.Now.Subtract(TimeSpan.FromDays(1));
			while (latestWeekday.DayOfWeek == DayOfWeek.Saturday || latestWeekday.DayOfWeek == DayOfWeek.Sunday)
				latestWeekday -= TimeSpan.FromDays(1);
			return latestWeekday;
		}

		//public async Task HistoricalPriceAsyncQsbTest()
		//{
		//	var qsb = new QueryStringBuilder();
		//	qsb.Add("chartByDay", "true");
		//	var response = await sandBoxClient.StockPrices.HistoricalPriceByDateAsync("AAPL", ChartRange._1m, null, qsb);

		//	Assert.IsNotNull(response);
		//	Assert.GreaterOrEqual(response.Count(), 0);
		//}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task HistoricalPriceDynamicAsync(string symbol, QueryStringBuilder qsb = null)
		{
			var response = await sandBoxClient.StockPrices.HistoricalPriceDynamicAsync(symbol, qsb);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.data);
			Assert.GreaterOrEqual(response.Data.data.Count, 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task IntradayPriceAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.IntradayPriceAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("F")]
		[TestCase("GE")]
		public async Task LargestTradesAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.LargestTradesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task OHLCAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.OHLCAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PreviousDayPriceAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.PreviousDayPriceAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PriceAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.PriceAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task QuoteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.QuoteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "companyName")]
		[TestCase("AAPL", "marketCap")]
		[TestCase("FB", "companyName")]
		public async Task QuoteFieldAsyncTest(string symbol, string field)
		{
			var response = await sandBoxClient.StockPrices.QuoteFieldAsync(symbol, field);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task VolumeByVenueAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockPrices.VolumeByVenueAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.GreaterOrEqual(response.Data.Count(), 1);

			Assert.IsNotNull(response.Data.First().venue);
			Assert.IsNotNull(response.Data.First().volume);
		}
	}
}
