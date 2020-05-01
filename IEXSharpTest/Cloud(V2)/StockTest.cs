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
		[TestCase(CollectionType.List, "iexvolume")]
		[TestCase(CollectionType.Sector, "Health Services")]
		[TestCase(CollectionType.Tag, "Computer Communications")]
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
		public async Task EffectiveSpreadAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.EffectiveSpreadAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
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
		[TestCase("mostactive")]
		[TestCase("gainers")]
		[TestCase("losers")]
		[TestCase("iexvolume")]
		[TestCase("iexpercent")]
		public async Task ListAsyncTest(string listType)
		{
			var response = await sandBoxClient.Stock.ListAsync(listType);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
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
	}
}