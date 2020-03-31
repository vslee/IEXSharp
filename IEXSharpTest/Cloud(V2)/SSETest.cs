using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.Stock.Request;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace VSLee.IEXSharpTest.Cloud
{
	public class SSETest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.Firehose)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.FiveSeconds)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.OneMinute)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.OneSecond)]
		[TestCase(new object[] { "spy" }, true, StockQuoteSSEInterval.OneSecond)]
		[TestCase(new object[] { "spy", "aapl" }, false, StockQuoteSSEInterval.OneSecond)]
		public async Task StockQuoteUSSSETest(object[] symbols, bool UTP, StockQuoteSSEInterval interval)
		{
			using (var sseClient = sandBoxClient.SSE.SubscribeStockQuoteUSSSE(
										symbols.Cast<string>(), UTP: UTP, interval: interval))
			{
				sseClient.Error += (s, e) =>
				{
					sseClient.Close();
					Assert.Fail("EventSource Error Occurred. Details: {0}", e.Exception.Message);
				};
				sseClient.MessageReceived += (s,m) =>
				{
					sseClient.Close();
					Assert.Pass(m.ToString());
				};
				await sseClient.StartAsync();
			}
		}

		[Test]
		[TestCase(new object[] { "btcusdt" })]
		[TestCase(new object[] { "btcusdt", "ethusdt" })]
		public async Task CryptoQuoteSSETest(object[] symbols)
		{
			using (var sseClient = sandBoxClient.SSE.SubscribeCryptoQuoteSSE(
										symbols.Cast<string>()))
			{
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
		}

		[Test]
		[TestCase(new object[] { "btcusdt" })]
		[TestCase(new object[] { "btcusdt", "ethusdt" })]
		public async Task CryptoEventSSETest(object[] symbols)
		{
			using (var sseClient = sandBoxClient.SSE.SubscribeCryptoEventSSE(
										symbols.Cast<string>()))
			{
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
		}
	}
}
