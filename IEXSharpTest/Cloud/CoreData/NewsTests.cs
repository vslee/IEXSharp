using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.CoreData.CorporateActions.Request;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class NewsTests
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.publishableToken, secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task NewsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.News.NewsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL", 10)]
		[TestCase("FB", 20)]
		public async Task NewsAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.News.NewsAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase(new object[] { "AAPL" })]
		[TestCase(new object[] { "AAPL", "FB" })]
		public async Task NewsStreamTest(object[] symbols)
		{
			using var sseClient = sandBoxClient.News.NewsStream(symbols.Cast<string>());
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
		[TestCase(null, null)]
		[TestCase(TimeSeriesRange.LastWeek, null)]
		[TestCase(TimeSeriesRange.LastWeek, 10)]
		[TestCase(TimeSeriesRange.LastQuarter, 20)]
		public async Task HistoricalNewsAsyncTest(TimeSeriesRange? range, int limit)
		{
			var response = await sandBoxClient.News.HistoricalNewsAsync(range, limit);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL", null, null)]
		[TestCase("AAPL", TimeSeriesRange.LastWeek, null)]
		[TestCase("AAPL", TimeSeriesRange.LastWeek, 10)]
		[TestCase("AAPL", TimeSeriesRange.LastQuarter, 20)]
		public async Task HistoricalNewsAsyncTest(string symbol, TimeSeriesRange? range, int limit)
		{
			var response = await sandBoxClient.News.HistoricalNewsAsync(symbol, range, limit);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}
	}
}
