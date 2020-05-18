using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;
using IEXSharp.Model.CoreData.Batch.Request;
using IEXSharp.Model.CoreData.MarketInfo.Request;
using IEXSharp.Model.CoreData.StockFundamentals.Request;

namespace IEXSharpTest.Legacy
{
	public class StockTest
	{
		private IEXLegacyClient prodClient;

		[SetUp]
		public void Setup()
		{
			prodClient = new IEXLegacyClient();
		}

		[Test]
		[TestCase("AAPL", new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote })]
		[TestCase("FB", new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote }, "1m", 5)]
		public async Task BatchBySymbolAsyncTest(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			var response = await prodClient.Stock.BatchBySymbolAsync(symbol, types, range, last);

			Assert.NotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task BookAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.BookAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", DividendRange.OneMonth)]
		[TestCase("AAPL", DividendRange.OneYear)]
		[TestCase("AAPL", DividendRange.TwoYears)]
		[TestCase("AAPL", DividendRange.ThreeMonths)]
		[TestCase("AAPL", DividendRange.FiveYears)]
		[TestCase("AAPL", DividendRange.SixMonths)]
		[TestCase("AAPL", DividendRange.Next)]
		[TestCase("AAPL", DividendRange.Ytd)]
		public async Task DividendAsyncTest(string symbol, DividendRange range)
		{
			var response = await prodClient.Stock.DividendAsync(symbol, range);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task EffectiveSpreadAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.EffectiveSpreadAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase(IPOType.Today)]
		[TestCase(IPOType.Upcoming)]
		public async Task IPOCalendarAsyncTest(IPOType ipoType)
		{
			var response = await prodClient.Stock.IPOCalendarAsync(ipoType);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LogoAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.LogoAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task OHLCAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.OHLCAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}