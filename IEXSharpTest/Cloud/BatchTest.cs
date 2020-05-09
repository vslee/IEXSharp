using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;
using IEXSharp.Model.Batch.Request;

namespace IEXSharpTest.Cloud
{
	public class BatchTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.publishableToken, secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AAPL", new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote })]
		[TestCase("FB", new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote }, "1m", 5)]
		[TestCase("AAPL", new BatchType[] { BatchType.Peers, BatchType.AdvancedStats, BatchType.PreviousDayPrice })]
		[TestCase("AAPL", new BatchType[] { BatchType.SplitsBasic, BatchType.DividendsBasic })]
		public async Task BatchBySymbolAsyncTest(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			var response = await sandBoxClient.Batch.BatchBySymbolAsync(symbol, types, range, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(new string[] { "AAPL" }, new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote })]
		[TestCase(new string[] { "AAPL", "FB" }, new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote }, "1m", 2)]
		[TestCase(new string[] { "AAPL" }, new BatchType[] { BatchType.Peers, BatchType.AdvancedStats, BatchType.PreviousDayPrice })]
		[TestCase(new string[] { "AAPL" }, new BatchType[] { BatchType.SplitsBasic, BatchType.DividendsBasic })]
		public async Task BatchByMarketAsyncTest(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			var response = await sandBoxClient.Batch.BatchByMarketAsync(symbols, types, range, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
			Assert.IsNotNull(response);
			Assert.IsNotNull(response.Data[symbols.First()]);
		}
	}
}