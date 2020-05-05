using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp.Model.MarketInfo.Request;
using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.MarketInfo.Request;

namespace IEXSharpTest.Cloud
{
	public class MarketInfoTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
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
		public async Task ListAsyncTest(ListType listType)
		{
			var response = await sandBoxClient.MarketInfoService.ListAsync(listType);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
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
			Assert.NotNull(data.performance);
			Assert.NotNull(data.lastUpdated);
		}

		[Test]
		[TestCase("AAPL", UpcomingEventType.Dividends)]
		[TestCase("AAPL", UpcomingEventType.Earnings)]
		[TestCase("AAPL", UpcomingEventType.Events)]
		[TestCase("AAPL", UpcomingEventType.IPOs)]
		[TestCase("AAPL", UpcomingEventType.Splits)]
		public async Task UpcomingEventSymbolAsyncTest(string symbol, UpcomingEventType type)
		{
			var response = await sandBoxClient.MarketInfoService.UpcomingEventSymbolAsync(symbol, type);

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
			var response = await sandBoxClient.MarketInfoService.UpcomingEventMarketAsync(type);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}
