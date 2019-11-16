using IEXSharp;
using IEXSharp.Model.Stock.Request;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace IEXSharpTest.Cloud
{
	public class SSETest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(pk: TestGlobal.pk, sk: TestGlobal.sk, signRequest: false, sandBox: true);
		}

		[Test]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.Firehose)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.FiveSeconds)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.OneMinute)]
		[TestCase(new object[] { "spy" }, false, StockQuoteSSEInterval.OneSecond)]
		[TestCase(new object[] { "spy" }, true, StockQuoteSSEInterval.OneSecond)]
		[TestCase(new object[] { "spy", "aapl" }, false, StockQuoteSSEInterval.OneSecond)]
		public async Task QuoteSSETest(object[] symbols, bool UTP, StockQuoteSSEInterval interval)
		{
			using (var sseClient = sandBoxClient.SSE.SubscribeQuoteSSE(
										symbols.Cast<string>(), UTP: UTP, interval: interval))
			{
				sseClient.Error += (s, e) =>
				{
					sseClient.Close();
					Assert.Fail("EventSource Error Occurred. Details: {0}", e.Exception.Message);
				};
				sseClient.MessageReceived += m =>
				{
					sseClient.Close();
					Assert.Pass(m.ToString());
				};
				await sseClient.StartAsync();
			}
		}
	}
}
