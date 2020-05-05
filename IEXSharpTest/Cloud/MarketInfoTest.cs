using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp.Model.MarketInfo.Request;
using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.MarketInfo.Request;
using VSLee.IEXSharpTest.Cloud;

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
		[TestCase("AAPL")]
		public async Task UpcomingDividendsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.MarketInfoService.UpcomingDividendsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.reportDate);
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
			Assert.NotNull(data.reportDate);
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
