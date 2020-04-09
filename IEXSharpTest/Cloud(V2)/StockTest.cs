using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.Stock.Request;
using NUnit.Framework;
using VSLee.IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp.Helper;

namespace VSLee.IEXSharpTest.Cloud
{
	public class StockTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AAPL", Period.Quarter, 1)]
		[TestCase("FB", Period.Quarter, 2)]
		public async Task BalanceSheetAsyncTest(string symbol, Period period = Period.Quarter,
			int last = 1)
		{
			var response = await sandBoxClient.Stock.BalanceSheetAsync(symbol, period, last);
			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.balancesheet);
			Assert.GreaterOrEqual(response.Data.balancesheet.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "currentCash", Period.Quarter, 1)]
		[TestCase("FB", "currentCash", Period.Quarter, 2)]
		public async Task BalanceSheetFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.Stock.BalanceSheetFieldAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote })]
		[TestCase("FB", new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote }, "1m", 5)]
		public async Task BatchBySymbolAsyncTest(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			var response = await sandBoxClient.Stock.BatchBySymbolAsync(symbol, types, range, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(new string[] { "AAPL" }, new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote })]
		[TestCase(new string[] { "AAPL", "FB" }, new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote }, "1m", 2)]
		public async Task BatchByMarketAsyncTest(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			var response = await sandBoxClient.Stock.BatchByMarketAsync(symbols, types, range, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
			Assert.IsNotNull(response);
			Assert.IsNotNull(response.Data[symbols.ToList()[0]]);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task BookAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.BookAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.quote);
		}

		[Test]
		[TestCase("AAPL", Period.Quarter, 1)]
		[TestCase("AAPL", Period.Annual, 2)]
		public async Task CashFlowAsyncTest(string symbol, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.Stock.CashFlowAsync(symbol, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "reportDate", Period.Annual, 1)]
		[TestCase("AAPL", "reportDate", Period.Quarter, 2)]
		public async Task CashFlowFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.Stock.CashFlowFieldAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(CollectionType.List, "iexvolume")]
		[TestCase(CollectionType.Sector, "Health Care")]
		[TestCase(CollectionType.Tag, "Computer Hardware")]
		public async Task CollectionAsyncTest(CollectionType collection, string collectionName)
		{
			var response = await sandBoxClient.Stock.CollectionsAsync(collection, collectionName);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task CompanyAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.CompanyAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task DelayedQuoteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.DelayedQuoteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
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
			var response = await sandBoxClient.Stock.DividendAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", 1)]
		[TestCase("FB", 2)]
		public async Task EarningAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.Stock.EarningAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "consensusEPS", 1)]
		[TestCase("AAPL", "announceTime", 2)]
		public async Task EarningFieldAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.Stock.EarningFieldAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		public async Task EarningTodayAsyncTest()
		{
			var response = await sandBoxClient.Stock.EarningTodayAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task EffectiveSpreadAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.EffectiveSpreadAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", 1)]
		[TestCase("FB", 2)]
		public async Task EstimateAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.Stock.EstimateAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.estimates.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "consensusEPS", 1)]
		[TestCase("FB", "consensusEPS", 2)]
		public async Task EstimateFieldAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.Stock.EstimateFieldAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", 1)]
		[TestCase("FB", 2)]
		public async Task FinancialAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.Stock.FinancialAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.financials.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "grossProfit", 1)]
		[TestCase("FB", "grossProfit", 2)]
		public async Task FinancialFieldAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.Stock.FinancialFieldAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task FundOwnershipAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.FundOwnershipAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("AAPL", ChartRange._1y)]
		[TestCase("AAPL", ChartRange._max)]
		[TestCase("AAPL", ChartRange._ytd)]
		[TestCase("AAPL", ChartRange._1m)]
		public async Task HistoricalPriceAsync(string symbol,
			ChartRange range = ChartRange._1m, QueryStringBuilder qsb = null)
		{
			var response = await sandBoxClient.Stock.HistoricalPriceAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
			Assert.IsNotEmpty(response.Data.First().date);
			Assert.Greater(response.Data.First().GetDateTimeInUTC(), DateTime.MinValue);
		}

		[Test]
		[TestCase("ORCL", ChartRange._max)]
		public async Task HistoricalPriceNonZeroAsync(string symbol,
			ChartRange range = ChartRange._1m, DateTime? date = null, QueryStringBuilder qsb = null)
		{
			var response = await sandBoxClient.Stock.HistoricalPriceAsync(symbol, range);
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
			var response = await sandBoxClient.Stock.HistoricalPriceByDateAsync(symbol, getLatestWeekday(), chartByDay);

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
		//	var response = await sandBoxClient.Stock.HistoricalPriceByDateAsync("AAPL", ChartRange._1m, null, qsb);

		//	Assert.IsNotNull(response);
		//	Assert.GreaterOrEqual(response.Count(), 0);
		//}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task HistoricalPriceDynamicAsync(string symbol, QueryStringBuilder qsb = null)
		{
			var response = await sandBoxClient.Stock.HistoricalPriceDynamicAsync(symbol, qsb);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.data);
			Assert.GreaterOrEqual(response.Data.data.Count, 1);
		}

		[Test]
		[TestCase("AAPL", Period.Annual, 1)]
		[TestCase("FB", Period.Quarter, 2)]
		public async Task IncomeStatementAsyncTest(string symbol, Period period, int last)
		{
			var response = await sandBoxClient.Stock.IncomeStatementAsync(symbol, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.income);
			Assert.GreaterOrEqual(response.Data.income.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "costOfRevenue", Period.Quarter, 1)]
		[TestCase("AAPL", "costOfRevenue", Period.Annual, 2)]
		public async Task InComeStatementFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.Stock.IncomeStatementFieldAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task InsiderRosterAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.InsiderRosterAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task InsiderSummaryAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.InsiderSummaryAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task InsiderTransactionAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.InsiderTransactionAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task InstitutionalOwnerShipAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.InstitutionalOwnerShipAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task IntradayPriceAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.IntradayPriceAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase(IPOType.Today)]
		[TestCase(IPOType.Upcoming)]
		public async Task IPOCalendarAsyncTest(IPOType ipoType)
		{
			var response = await sandBoxClient.Stock.IPOCalendarAsync(ipoType);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task KeyStatsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.KeyStatsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "nextEarningsDate")]
		[TestCase("AAPL", "marketcap")]
		[TestCase("FB", "nextEarningsDate")]
		public async Task KeyStatsStatAsync(string symbol, string stat)
		{
			var response = await sandBoxClient.Stock.KeyStatsStatAsync(symbol, stat);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LargestTradesAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.LargestTradesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
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
			var response = await sandBoxClient.Stock.ListAsync(listType);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LogoAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.LogoAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		public async Task MarketVolumeUSAsyncTest()
		{
			var response = await sandBoxClient.Stock.MarketVolumeUSAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL", 10)]
		[TestCase("FB", 20)]
		public async Task NewsAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.Stock.NewsAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task OHLCAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.OHLCAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PeersAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.PeersAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PreviousDayPriceAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.PreviousDayPriceAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PriceAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.PriceAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PriceTargetAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.PriceTargetAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task QuoteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.QuoteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "companyName")]
		[TestCase("AAPL", "marketCap")]
		[TestCase("FB", "companyName")]
		public async Task QuoteFieldAsyncTest(string symbol, string field)
		{
			var response = await sandBoxClient.Stock.QuoteFieldAsync(symbol, field);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task RecommandationTrendAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.RecommendationTrendAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task SectorPerformanceAsync()
		{
			var response = await sandBoxClient.Stock.SectorPerformanceAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
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
			var response = await sandBoxClient.Stock.SplitAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL", UpcomingEventType.Dividends)]
		[TestCase("AAPL", UpcomingEventType.Earnings)]
		[TestCase("AAPL", UpcomingEventType.Events)]
		[TestCase("AAPL", UpcomingEventType.IPOs)]
		[TestCase("AAPL", UpcomingEventType.Splits)]
		public async Task UpcomingEventSymbolAsyncTest(string symbol, UpcomingEventType type)
		{
			var response = await sandBoxClient.Stock.UpcomingEventSymbolAsync(symbol, type);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		// Not supported for free account
		[Test]
		[TestCase(UpcomingEventType.Dividends)]
		[TestCase(UpcomingEventType.Earnings)]
		[TestCase(UpcomingEventType.Events)]
		[TestCase(UpcomingEventType.IPOs)]
		[TestCase(UpcomingEventType.Splits)]
		public async Task UpcomingEventMarketAsyncTest(UpcomingEventType type)
		{
			var response = await sandBoxClient.Stock.UpcomingEventMarketAsync(type);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task VolumeByVenueAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.VolumeByVenueAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}