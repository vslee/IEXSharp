using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class SocialSentimentTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.publishableToken, secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase(new object[] { "AAPL" })]
		[TestCase(new object[] { "AAPL", "FB" })]
		public async Task StreamingSentimentTest(object[] symbols)
		{
			using var sseClient = sandBoxClient.SocialSentiment.SubscribeToSentiment(symbols.Cast<string>());
			sseClient.Error += (s, e) =>
			{
				sseClient.Close();
				Assert.Fail("EventSource Error Occurred. Details: {0}", e.Exception.Message);
			};
			sseClient.MessageReceived += (s, m) =>
			{
				sseClient.Close();
				Assert.Pass(m.ToString());
			};
			await sseClient.StartAsync();
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
			var response = await sandBoxClient.SocialSentiment.SentimentByMinuteAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.FirstOrDefault()?.sentiment);
			Assert.IsNotNull(response.Data.FirstOrDefault()?.totalScores);
		}

		[Test]
		[TestCase("AAPL", "20200505")]
		[TestCase("FB", "20200505")]
		public async Task GetSocialSentimentByMinuteTest(string symbol, string date)
		{
			var response = await sandBoxClient.SocialSentiment.SentimentByMinuteAsync(symbol, date);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.FirstOrDefault()?.sentiment);
			Assert.IsNotNull(response.Data.FirstOrDefault()?.totalScores);
		}
	}
}
