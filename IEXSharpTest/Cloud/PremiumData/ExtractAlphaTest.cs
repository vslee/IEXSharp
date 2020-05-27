using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.PremiumData
{
	public class ExtractAlphaTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task SimilarityIndexAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.CrossAssetModelOneAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().VolumeComponent);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgCpfbComplaintsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgCpfbComplaintsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().ComplaintId);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgCpscRecallsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgCpscRecallsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().RecallNumber);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgDolVisaApplicationsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgDolVisaApplicationsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().TotalWorkers);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgEpaEnforcementsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgEpaEnforcementsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().EnfSummaryText);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgEpaMilestonesAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgEpaMilestonesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().DefendantName);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgFecIndividualCampaignContributionsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgFecIndividualCampaignContributionsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().TransactionAmt);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgOshaInspectionsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgOshaInspectionsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().InspType);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgSenateLobbyingAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgSenateLobbyingAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().ClientName);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgUsaSpendingAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgUsaSpendingAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().VendorName);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgUsptoPatentApplicationsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgUsptoPatentApplicationsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().FilingDate);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task EsgUsptoPatentGrantsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.EsgUsptoPatentGrantsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().PatentNumber);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task TacticalModelOneAsyncTest(string symbol)
		{
			var response = await sandBoxClient.ExtractAlphaService.TacticalModelOneAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;
			Assert.IsNotNull(response.Data.First().LiquidityShockComponent);
		}
	}
}