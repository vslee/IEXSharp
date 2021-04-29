using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.CoreData.CorporateActions.Request;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class CorporateActionsTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task BonusIssueAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.BonusIssueAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.resultSecurityType);
			Assert.NotNull(data.currency);
			Assert.NotNull(data.lapsedPremium);
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task DistributionAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.DistributionAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.withdrawalFromDate);
			Assert.NotNull(data.withdrawalToDate);
			Assert.NotNull(data.electionDate);
			Assert.NotNull(data.minPrice);
			Assert.NotNull(data.maxPrice);
			Assert.NotNull(data.hasWithdrawalRights);
		}

		[Test]
		[TestCaseSource(nameof(DividendsAdvancedAsyncTestData))]
		public async Task DividendsAdvancedAsyncTest(TimeSeriesRange range)
		{
			var response = await sandBoxClient.CorporateActions.DividendsAdvancedAsync("AAPL", range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			// can sometimes be empty in case no dividend got declared in the selected time range
			if (!response.Data.Any()) return;

			var data = response.Data.First();

			Assert.Greater(data.exDate, DateTime.MinValue);
			Assert.Greater(data.declaredDate, DateTime.MinValue);
			Assert.Greater(data.paymentDate, DateTime.MinValue);
			Assert.Greater(data.amount, 0);
			Assert.Greater(data.grossAmount, 0);

			Assert.IsFalse(string.IsNullOrEmpty(data.currency));
			Assert.IsFalse(string.IsNullOrEmpty(data.figi));
			Assert.IsFalse(string.IsNullOrEmpty(data.marker));
			Assert.IsFalse(string.IsNullOrEmpty(data.flag));
			Assert.IsFalse(string.IsNullOrEmpty(data.securityType));
		}

		[Test]
		[TestCase("", TimeSeriesRange.LastQuarter, false, 10, "")]
		[TestCase("AAPL", TimeSeriesRange.LastQuarter, false, null, "")]
		[TestCase("AAPL", TimeSeriesRange.OneMonth, false, null, "")]
		[TestCase("AAPL", null, false, null, "")]
		[TestCase("PFF", null, false, null, "")]
		public async Task DividendsAdvancedAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.DividendsAdvancedAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			// can sometimes be empty in case no dividend got declared in the selected time range
			if (!response.Data.Any()) return;

			var data = response.Data.First();

			Assert.Greater(data.exDate, DateTime.MinValue);
			Assert.Greater(data.amount, 0);
			Assert.Greater(data.grossAmount, 0);

			Assert.IsFalse(string.IsNullOrEmpty(data.currency));
			Assert.IsFalse(string.IsNullOrEmpty(data.securityType));
		}

		private static IEnumerable<TimeSeriesRange> DividendsAdvancedAsyncTestData()
		{
			return (TimeSeriesRange[])Enum.GetValues(typeof(TimeSeriesRange));
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task ReturnOfCapitalAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.ReturnOfCapitalAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.withdrawalFromDate);
			Assert.NotNull(data.withdrawalToDate);
			Assert.NotNull(data.electionDate);
			Assert.NotNull(data.cashBack);
			Assert.NotNull(data.currency);
			Assert.NotNull(data.hasWithdrawalRights);
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task RightsIssueAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.RightsIssueAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.subscriptionStartDate);
			Assert.NotNull(data.subscriptionEndDate);
			Assert.NotNull(data.issuePrice);
			Assert.NotNull(data.currency);
			Assert.NotNull(data.isOverSubscription);
			Assert.NotNull(data.currency);
			Assert.NotNull(data.lapsedPremium);
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task RightToPurchaseAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.RightToPurchaseAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.subscriptionStart);
			Assert.NotNull(data.subscriptionEnd);
			Assert.NotNull(data.issuePrice);
			Assert.NotNull(data.currency);
			Assert.NotNull(data.isOverSubscription);
			Assert.NotNull(data.currency);
			Assert.NotNull(data.resultSecurityType);
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task SecurityReclassificationAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.SecurityReclassificationAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.resultSecurityType);
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task SecuritySwapAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.SecuritySwapAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.resultSecurityType);
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task SpinOffAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.SpinOffAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.withdrawalFromDate);
			Assert.NotNull(data.withdrawalToDate);
			Assert.NotNull(data.electionDate);
			Assert.NotNull(data.effectiveDate);
			Assert.NotNull(data.minPrice);
			Assert.NotNull(data.maxPrice);
			Assert.NotNull(data.hasWithdrawalRights);
			Assert.NotNull(data.currency);
		}

		[Test]
		[TestCase("AAPL", null, false, null, "")]
		public async Task SplitsAdvancedAsyncTest(string symbol, TimeSeriesRange range, bool calendar, int last, string refId)
		{
			var response = await sandBoxClient.CorporateActions.SplitsAdvancedAsync(symbol, range, calendar, last, refId);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			if (!response.Data.Any()) return;

			var data = response.Data.First();
			Assert.NotNull(data.symbol);
			Assert.NotNull(data.recordDate);
			Assert.NotNull(data.splitType);
			Assert.NotNull(data.oldParValue);
			Assert.NotNull(data.oldParValueCurrency);
		}
	}
}
