using IEXSharp.Model.CoprorateActions.Request;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSLee.IEXSharp;

namespace VSLee.IEXSharpTest.Cloud
{
	public class CorporateActionsTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCaseSource(nameof(DividendsAsyncTestData))]
		public async Task DividendsAsyncTest(TimeSeriesRange range)
		{
			var response = await sandBoxClient.CorporateActions.DividendsAsync("AAPL", range);

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
			Assert.IsFalse(string.IsNullOrEmpty(data.refid));
			Assert.IsFalse(string.IsNullOrEmpty(data.figi));
			Assert.IsFalse(string.IsNullOrEmpty(data.marker));
			Assert.IsFalse(string.IsNullOrEmpty(data.flag));
			Assert.IsFalse(string.IsNullOrEmpty(data.securityType));
		}

		private static IEnumerable<TimeSeriesRange> DividendsAsyncTestData()
		{
			foreach (var range in (TimeSeriesRange[])Enum.GetValues(typeof(TimeSeriesRange)))
			{
				yield return range;
			}
		}
	}
}
