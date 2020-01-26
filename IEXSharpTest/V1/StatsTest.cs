using VSLee.IEXSharp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSLee.IEXSharpTest.V1
{
	public class StatsTest
	{
		private IEXV1RestClient prodClient;

		[SetUp]
		public void Setup()
		{
			prodClient = new IEXV1RestClient();
		}

		[Test]
		public async Task StatsIntradayAsyncTest()
		{
			var response = await prodClient.Stats.StatsIntradayAsync();

			Assert.IsNotNull(response);
		}

		[Test]
		public async Task StatsRecentAsyncTest()
		{
			var response = await prodClient.Stats.StatsRecentAsync();

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		public async Task StatsRecordAsyncTest()
		{
			var response = await prodClient.Stats.StatsRecordAsync();

			Assert.IsNotNull(response);
		}
		[Test]
		[TestCase("201902")]
		[TestCase("201900225")]
		[Ignore("IEX V1 appears to have deprecated this method?")]
		public async Task StatsHistoricalDailyByDateAsyncTest(string date)
		{
			var response = await prodClient.Stats.StatsHistoricalDailyByDateAsync(date);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		public async Task StatsHistoricalDailyByLastAsync(int last)
		{
			var response = await prodClient.Stats.StatsHistoricalDailyByLastAsync(last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task StatsHistoricalSummaryAsyncTest()
		{
			var response1 = await prodClient.Stats.StatsHistoricalSummaryAsync();
			var response2 = await prodClient.Stats.StatsHistoricalSummaryAsync(new DateTime(2019, 02, 01));

			Assert.IsNull(response1.ErrorMessage);
			Assert.IsNotNull(response1.Data);
			Assert.GreaterOrEqual(response1.Data.Count(), 1);
			Assert.IsNull(response2.ErrorMessage);
			Assert.IsNotNull(response2.Data);
			Assert.GreaterOrEqual(response2.Data.Count(), 1);
		}
	}
}
