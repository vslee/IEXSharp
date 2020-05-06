using System.Threading.Tasks;
using NUnit.Framework;
using VSLee.IEXSharp;
using VSLee.IEXSharpTest.Cloud;

namespace IEXSharpTest.Cloud
{
	public class SocialSentimentTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task GetSocialSentimentByDayTest(string symbol)
		{
			var response = await sandBoxClient.SocialSentiment.SentimentByDayAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.sentiment);
			Assert.IsNotNull(response.Data.totalScores);
		}

		[Test]
		[TestCase("AAPL", "20200505")]
		[TestCase("FB", "20200505")]
		public async Task GetSocialSentimentByDayTest(string symbol, string date)
		{
			var response = await sandBoxClient.SocialSentiment.SentimentByDayAsync(symbol, date);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.sentiment);
			Assert.IsNotNull(response.Data.totalScores);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task GetSocialSentimentByMinuteTest(string symbol)
		{
			var response = await sandBoxClient.SocialSentiment.SentimentByDayAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.sentiment);
			Assert.IsNotNull(response.Data.totalScores);
		}

		[Test]
		[TestCase("AAPL", "20200505")]
		[TestCase("FB", "20200505")]
		public async Task GetSocialSentimentByMinuteTest(string symbol, string date)
		{
			var response = await sandBoxClient.SocialSentiment.SentimentByDayAsync(symbol, date);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.sentiment);
			Assert.IsNotNull(response.Data.totalScores);
		}
	}
}
