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
		public async Task CryptoQuoteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AlternativeData.CryptoQuoteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task SocialSentimentDailyAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AlternativeData.SocialSentimentDailyAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task SocialSentimentDailyDateAsyncTest(string symbol)
		{
			DateTime date = new DateTime(2019, 03, 30);
			var response = await sandBoxClient.AlternativeData.SocialSentimentDailyAsync(symbol, date);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task SocialSentimentMinuteAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AlternativeData.SocialSentimentMinuteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task SocialSentimentMinuteDateAsyncTest(string symbol)
		{
			DateTime date = new DateTime(2019, 03, 30);
			var response = await sandBoxClient.AlternativeData.SocialSentimentMinuteAsync(symbol, date);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		// Not supported for free account
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task CEOCompensationAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AlternativeData.CEOCompensationAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}