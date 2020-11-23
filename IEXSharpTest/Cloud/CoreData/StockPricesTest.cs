using System;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Helper;
using IEXSharp.Model.CoreData.StockPrices.Request;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class StockPricesTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.publishableToken, secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true);
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
			Assert.Greater(response.Data.First().GetTimestampInUTC(), DateTime.MinValue);
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
				assertNotZeroIfNotNull(ohlc.open);
				assertNotZeroIfNotNull(ohlc.high);
				assertNotZeroIfNotNull(ohlc.low);
				assertNotZeroIfNotNull(ohlc.close);
				assertNotZeroIfNotNull(ohlc.volume);
				assertNotZeroIfNotNull(ohlc.uOpen);
				assertNotZeroIfNotNull(ohlc.uHigh);
				assertNotZeroIfNotNull(ohlc.uLow);
				assertNotZeroIfNotNull(ohlc.uClose);
				Assert.NotZero(ohlc.uVolume.Value);
			}

			void assertNotZeroIfNotNull(decimal? num)
			{
				if (num != null)
					Assert.NotZero(num.Value);
			}
		}

		[Test]
		[TestCase("AAPL", "", true)]
		[TestCase("AAPL", "", false)]
		[TestCase("AMER", "20201120", false)]
		public async Task HistoricalPriceAsyncDateTest(string symbol, string date, bool chartByDay)
		{
			var dt = string.IsNullOrEmpty(date) ? getLatestWeekday() : DateTime.ParseExact(date, "yyyyMMdd", null);
			var response = await sandBoxClient.StockPrices.HistoricalPriceByDateAsync(symbol, dt, chartByDay);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
			Assert.IsNotEmpty(response.Data.First().minute);
			Assert.Greater(response.Data.First().GetTimestampInUTC(), DateTime.MinValue);
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
			var response = await sandBoxClient.StockPrices.IntradayPricesAsync(symbol);

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
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.Firehose)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.FiveSeconds)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.OneMinute)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.OneSecond)]
		[TestCase(new object[] { "spy" }, true, StockQuoteSSEInterval.OneSecond)]
		[TestCase(new object[] { "spy", "aapl" }, false, StockQuoteSSEInterval.OneSecond)]
		public async Task StockQuoteUSSSETest(object[] symbols, bool UTP, StockQuoteSSEInterval interval)
		{
			using var sseClient = sandBoxClient.StockPrices.QuoteStream(
				symbols.Cast<string>(), UTP: UTP, interval: interval);
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
