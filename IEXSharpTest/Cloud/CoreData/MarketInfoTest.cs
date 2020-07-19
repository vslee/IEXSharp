using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.CoreData.MarketInfo.Request;
using IEXSharpTest.Helper;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class MarketInfoTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClientForTest(publishableToken: TestGlobal.publishableToken, secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true)
			{
				JsonMissingMemberHandling = MissingMemberHandling.Error
			};
		}

		[Test]
		[TestCase(CollectionType.List, "iexvolume")]
		[TestCase(CollectionType.Sector, "Health Services")]
		[TestCase(CollectionType.Tag, "Computer Communications")]
		public async Task CollectionAsyncTest(CollectionType collection, string collectionName)
		{
			var response = await sandBoxClient.MarketInfoService.CollectionsAsync(collection, collectionName);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task EarningsTodayAsyncTest()
		{
			var response = await sandBoxClient.MarketInfoService.EarningsTodayAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.IsNotNull(response.Data.amc);
			Assert.IsNotNull(response.Data.bto);
			Assert.IsNotNull(response.Data.other);
		}

		[Test]
		[TestCase(IPOType.Today)]
		[TestCase(IPOType.Upcoming)]
		public async Task IPOCalendarAsyncTest(IPOType ipoType)
		{
			var response = await sandBoxClient.MarketInfoService.IPOCalendarAsync(ipoType);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(ListType.MostActive)]
		[TestCase(ListType.Gainers)]
		[TestCase(ListType.Losers)]
		[TestCase(ListType.IexVolume)]
		[TestCase(ListType.IexPercent)]
		[TestCase(ListType.MostActive, false, 5)]
		[TestCase(ListType.Gainers, false, 5)]
		[TestCase(ListType.Losers, false, 5)]
		[TestCase(ListType.IexVolume, false, 5)]
		[TestCase(ListType.IexPercent, false, 5)]
		[TestCase(ListType.Losers, true)]
		[TestCase(ListType.IexVolume, true)]
		[TestCase(ListType.IexPercent, true)]
		[TestCase(ListType.MostActive, true, 5)]
		[TestCase(ListType.Gainers, true, 5)]
		[TestCase(ListType.Losers, true, 5)]
		public async Task ListAsyncTest(ListType listType, bool displayPercent = false, int listLimit = 10)
		{
			var response = await sandBoxClient.MarketInfoService.ListAsync(listType, displayPercent, listLimit);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 0);
			Assert.LessOrEqual(response.Data.Count(), listLimit);
		}

		[Test]
		public async Task MarketVolumeUSAsyncTest()
		{
			var response = await sandBoxClient.MarketInfoService.MarketVolumeUSAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);

			var data = response.Data.First();
			Assert.NotNull(data.venueName);
			Assert.NotNull(data.tapeA);
			Assert.NotNull(data.volume);
			Assert.NotNull(data.lastUpdated);
		}

		[Test]
		public async Task SectorPerformanceAsync()
		{
			var response = await sandBoxClient.MarketInfoService.SectorPerformanceAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);

			var data = response.Data.First();
			Assert.NotNull(data.type);
			Assert.NotNull(data.name);
			// Assert.NotNull(data.performance); sometimes IEX does return a null performance :(
			Assert.NotNull(data.lastUpdated);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task UpcomingEventAsyncTest(string symbol)
		{
			var response = await sandBoxClient.MarketInfoService.UpcomingEventsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.NotNull(response.Data.earnings);
			Assert.NotNull(response.Data.dividends);
			Assert.NotNull(response.Data.splits);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task UpcomingEarningsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.MarketInfoService.UpcomingEarningsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.reportDate);
		}

		[Test]
		[TestCase("")]
		[TestCase("market")]
		public async Task UpcomingDividendsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.MarketInfoService.UpcomingDividendsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.exDate);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task UpcomingSplitsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.MarketInfoService.UpcomingSplitsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			// Some stocks won't have upcoming splits.
			if(response.Data.FirstOrDefault() == null) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.exDate);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task UpcomingIposAsyncTest(string symbol)
		{
			var response = await sandBoxClient.MarketInfoService.UpcomingIposAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			Assert.NotNull(response.Data.rawData);
			Assert.NotNull(response.Data.viewData);
		}
	}
}
