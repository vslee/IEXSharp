using IEXSharp;
using IEXSharp.Model.Stock.Request;
using NUnit.Framework;
using IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEXSharpTest.V1
{
	public class StockTest
	{
		private IEXV1RestClient prodClient;

		[SetUp]
		public void Setup()
		{
			prodClient = new IEXV1RestClient();
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
		[TestCase(new string[] { "AAPL" }, new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote })]
		[TestCase(new string[] { "AAPL", "FB" }, new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote }, "1m", 2)]
		public async Task BatchByMarketAsyncTest(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			var response = await prodClient.Stock.BatchByMarketAsync(symbols, types, range, last);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count, 1);
			Assert.IsNotNull(response[symbols.ToList()[0]]);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task BookAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.BookAsync(symbol);

			Assert.IsNotNull(response);
			Assert.IsNotNull(response.quote);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("AAPL", ChartRange._1y)]
		[TestCase("AAPL", ChartRange._max)]
		[TestCase("AAPL", ChartRange._ytd)]
		[TestCase("AAPL", ChartRange._1m)]
		public async Task ChartAsync(string symbol,
			ChartRange range = ChartRange._1m, DateTime? date = null, QueryStringBuilder qsb = null)
		{
			var response = await prodClient.Stock.ChartAsync(symbol, range, date, qsb);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		public async Task ChartAsyncDateTest()
		{
			var response = await prodClient.Stock.ChartAsync("AAPL", ChartRange._1m, new DateTime(2019, 3, 25));

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}


		[Test]
		public async Task ChartDynamicAsyncDateTest()
		{
			var response = await prodClient.Stock.ChartDynamicAsync("AAPL", null);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.data.Count(), 0);
		}

		[Test]
		[TestCase(CollectionType.List, "iexvolume")]
		[TestCase(CollectionType.Sector, "Health Care")]
		[TestCase(CollectionType.Tag, "Computer Hardware")]
		public async Task CollectionAsyncTest(CollectionType collection, string collectionName)
		{
			var response = await prodClient.Stock.CollectionsAsync(collection, collectionName);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task CompanyAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.CompanyAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		public async Task CryptoAsyncTest()
		{
			var response = await prodClient.Stock.CryptoAsync();

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DelayedQuoteAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.DelayedQuoteAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL", DividendRange._1m)]
		[TestCase("AAPL", DividendRange._1y)]
		[TestCase("AAPL", DividendRange._2y)]
		[TestCase("AAPL", DividendRange._3m)]
		[TestCase("AAPL", DividendRange._5y)]
		[TestCase("AAPL", DividendRange._6m)]
		[TestCase("AAPL", DividendRange._next)]
		[TestCase("AAPL", DividendRange._ytd)]
		public async Task DividendAsyncTest(string symbol, DividendRange range)
		{
			var response = await prodClient.Stock.DividendAsync(symbol, range);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task EarningAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.EarningAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		public async Task EarningTodayAsyncTest()
		{
			var response = await prodClient.Stock.EarningTodayAsync();

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task EffectiveSpreadAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.EffectiveSpreadAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task FinancialAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.FinancialAsync(symbol);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.financials.Count, 1);
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
		public async Task ListedRegulationSHOThresholdSecuritiesListAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.ListedRegulationSHOThresholdSecuritiesListAsync(symbol);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task ListedShortInterestListAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.ListedShortInterestListAsync(symbol);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task KeyStatsAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.KeyStatsAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LargestTradesAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.LargestTradesAsync(symbol);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("mostactive")]
		[TestCase("gainers")]
		[TestCase("losers")]
		[TestCase("iexvolume")]
		[TestCase("iexpercent")]
		[TestCase("infocus")]
		public async Task ListAsyncTest(string listType)
		{
			var response = await prodClient.Stock.ListAsync(listType);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
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
		[TestCase("AAPL", 10)]
		[TestCase("FB", 20)]
		public async Task NewsAsyncTest(string symbol, int last)
		{
			var response = await prodClient.Stock.NewsAsync(symbol, last);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task OHLCAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.OHLCAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PeersAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.PeersAsync(symbol);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PreviousDayPriceAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.PreviousDayPriceAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PriceAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.PriceAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task QuoteAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.QuoteAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task RelevantAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.RelevantAsync(symbol);

			Assert.IsNotNull(response);
		}

		[Test]
		public async Task SectorPerformanceAsync()
		{
			var response = await prodClient.Stock.SectorPerformanceAsync();

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL", SplitRange._1m)]
		[TestCase("AAPL", SplitRange._1y)]
		[TestCase("AAPL", SplitRange._2y)]
		[TestCase("AAPL", SplitRange._3m)]
		[TestCase("AAPL", SplitRange._5y)]
		[TestCase("AAPL", SplitRange._6m)]
		[TestCase("AAPL", SplitRange._next)]
		[TestCase("AAPL", SplitRange._ytd)]
		public async Task SplitAsyncTest(string symbol, SplitRange range)
		{
			var response = await prodClient.Stock.SplitAsync(symbol, range);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task VolumeByVenueAsyncTest(string symbol)
		{
			var response = await prodClient.Stock.VolumeByVenueAsync(symbol);

			Assert.IsNotNull(response);
		}
	}
}