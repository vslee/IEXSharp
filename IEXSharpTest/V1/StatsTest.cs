using IEXSharp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEXSharpTest.V1
{
	public class StatsTest
	{
		private IEXRestV1Client prodClient;

		[SetUp]
		public void Setup()
		{
			prodClient = new IEXRestV1Client();
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
		public async Task StatsHistoricalDailyByDateAsyncTest(string date)
		{
			var response = await prodClient.Stats.StatsHistoricalDailyByDateAsync(date);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		public async Task StatsHistoricalDailyByLastAsync(int last)
		{
			var response = await prodClient.Stats.StatsHistoricalDailyByLastAsync(last);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		public async Task StatsHistoricalSummaryAsyncTest()
		{
			var response1 = await prodClient.Stats.StatsHistoricalSummaryAsync();
			var response2 = await prodClient.Stats.StatsHistoricalSummaryAsync(new DateTime(2019, 02, 01));

			Assert.IsNotNull(response1);
			Assert.GreaterOrEqual(response1.Count(), 1);
			Assert.IsNotNull(response2);
			Assert.GreaterOrEqual(response2.Count(), 1);
		}
	}
}
