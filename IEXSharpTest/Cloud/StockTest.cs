using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.Stock.Request;
using NUnit.Framework;
using VSLee.IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp.Helper;

namespace VSLee.IEXSharpTest.Cloud
{
	public class StockTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AAPL", new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote })]
		[TestCase("FB", new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote }, "1m", 5)]
		public async Task BatchBySymbolAsyncTest(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			var response = await sandBoxClient.Stock.BatchBySymbolAsync(symbol, types, range, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(new string[] { "AAPL" }, new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote })]
		[TestCase(new string[] { "AAPL", "FB" }, new BatchType[] { BatchType.Chart, BatchType.News, BatchType.Quote }, "1m", 2)]
		public async Task BatchByMarketAsyncTest(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			var response = await sandBoxClient.Stock.BatchByMarketAsync(symbols, types, range, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count, 1);
			Assert.IsNotNull(response);
			Assert.IsNotNull(response.Data[symbols.ToList()[0]]);
		}
		
		[Test]
		[TestCase("AAPL", 10)]
		[TestCase("FB", 20)]
		public async Task NewsAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.Stock.NewsAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task RecommandationTrendAsyncTest(string symbol)
		{
			var response = await sandBoxClient.Stock.RecommendationTrendAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}
	}
}