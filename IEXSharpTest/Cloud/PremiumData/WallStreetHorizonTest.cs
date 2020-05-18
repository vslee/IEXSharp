using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.PremiumData
{
	public class WallStreetHorizonTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
		}

		[Test]
		[TestCase("", "")]
		[TestCase("AAPL", "")]
		public async Task AnalystDaysAsyncTest(string symbol, string eventId)
		{
			var response = await sandBoxClient.WallStreetHorizonService.AnalystDaysAsync(symbol, eventId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		[TestCase("", "")]
		[TestCase("AAPL", "")]
		public async Task BoardOfDirectorsMeetingAsyncTest(string symbol, string eventId)
		{
			var response = await sandBoxClient.WallStreetHorizonService.BoardOfDirectorsMeetingAsync(symbol, eventId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		[TestCase("", "")]
		[TestCase("AAPL", "")]
		public async Task BusinessUpdatesAsyncTest(string symbol, string eventId)
		{
			var response = await sandBoxClient.WallStreetHorizonService.BusinessUpdatesAsync(symbol, eventId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		[TestCase("", "")]
		[TestCase("AAPL", "")]
		public async Task BuybacksAsyncTest(string symbol, string eventId)
		{
			var response = await sandBoxClient.WallStreetHorizonService.BuybacksAsync(symbol, eventId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().BuybackMethod);
		}

		[Test]
		public async Task CapitalMarketsDayAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.CapitalMarketsDayAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().companyname);
		}

		[Test]
		[TestCase("", "")]
		[TestCase("AAPL", "")]
		public async Task CompanyTravelAsyncTest(string symbol, string eventId)
		{
			var response = await sandBoxClient.WallStreetHorizonService.CompanyTravelAsync(symbol, eventId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().venue);
		}

		[Test]
		public async Task FilingDueDatesAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.FilingDueDatesAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().companyname);
		}

		[Test]
		public async Task FiscalQuarterEndAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.FiscalQuarterEndAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().companyname);
		}

		[Test]
		public async Task ForumAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.ForumAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task GeneralConferenceAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.GeneralConferenceAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task FdaAdvisoryCommitteeMeetingsAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.FdaAdvisoryCommitteeMeetingsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task HolidaysAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.HolidaysAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task IndexChangesAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.IndexChangesAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task IposAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.IposAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().iposcoopcompanyname);
		}

		[Test]
		public async Task LegalActionsAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.LegalActionsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().lawfirm);
		}

		[Test]
		[Ignore("Not yet sure of return type - docs are incomplete. It's a IEnumerable<WallStreetHorizonResponse> for now.")]
		[TestCase("", "")]
		[TestCase("AAPL", "")]
		public async Task MergersAndAcquisitionsAsyncTest(string symbol, string eventId)
		{
			var response = await sandBoxClient.WallStreetHorizonService.MergersAndAcquisitionsAsync(symbol, eventId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		[TestCase("", "")]
		[TestCase("AAPL", "")]
		public async Task ProductEventsAsyncTest(string symbol, string eventId)
		{
			var response = await sandBoxClient.WallStreetHorizonService.ProductEventsAsync(symbol, eventId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task ResearchAndDevelopmentDaysAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.ResearchAndDevelopmentDaysAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		[TestCase("", "")]
		[TestCase("AAPL", "")]
		public async Task SameStoreSalesAsyncTest(string symbol, string eventId)
		{
			var response = await sandBoxClient.WallStreetHorizonService.SameStoreSalesAsync(symbol, eventId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task SecondaryOfferingsAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.SecondaryOfferingsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task SeminarsAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.SeminarsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task ShareholderMeetingsAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.ShareholderMeetingsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task SummitMeetingsAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.SummitMeetingsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task TradeShowsAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.TradeShowsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task WitchingHoursAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.WitchingHoursAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}

		[Test]
		public async Task WorkshopsAsyncTest()
		{
			var response = await sandBoxClient.WallStreetHorizonService.WorkshopsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().eventid);
		}
	}
}