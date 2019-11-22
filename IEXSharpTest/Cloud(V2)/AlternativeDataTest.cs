using NUnit.Framework;
using System;
using System.Threading.Tasks;
using VSLee.IEXSharp;

namespace VSLee.IEXSharpTest.Cloud
{
	public class AlternativeDataTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
		}

		[Test]
		[TestCase("BTCUSDT")]
		public async Task CryptoAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AlternativeData.CryptoAsync(symbol);

			Assert.IsNotNull(response);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task SocialSentimentDailyAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AlternativeData.SocialSentimentDailyAsync(symbol);

			Assert.IsNotNull(response);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task SocialSentimentDailyDateAsyncTest(string symbol)
		{
			DateTime date = new DateTime(2019, 03, 30);
			var response = await sandBoxClient.AlternativeData.SocialSentimentDailyAsync(symbol, date);

			Assert.IsNotNull(response);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task SocialSentimentMinuteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AlternativeData.SocialSentimentMinuteAsync(symbol);

			Assert.IsNotNull(response);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task SocialSentimentMinuteDateAsyncTest(string symbol)
		{
			DateTime date = new DateTime(2019, 03, 30);
			var response = await sandBoxClient.AlternativeData.SocialSentimentMinuteAsync(symbol, date);

			Assert.IsNotNull(response);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task CEOCompensationAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AlternativeData.CEOCompensationAsync(symbol);

			Assert.IsNotNull(response);
		}
	}
}