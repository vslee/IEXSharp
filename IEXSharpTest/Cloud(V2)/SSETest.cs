using IEXSharp;
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
		[TestCase(new object[] { "spy" })]
		[TestCase(new object[] { "spy", "aapl" })]
		public async Task QuoteSSETest(object[] symbols)
		{
			using (var sseClient = sandBoxClient.SSE.SubscribeQuoteSSE(symbols.Cast<string>(), UTP: false))
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
