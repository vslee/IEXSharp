using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSLee.IEXSharp;
using VSLee.IEXSharpTest.Cloud;

namespace IEXSharpTest.Cloud
{
	public class StockProfilesTest
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
		public async Task CompanyAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockProfiles.CompanyAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		/// <summary> Not supported for free account </summary>
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task InsiderRosterAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockProfiles.InsiderRosterAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		/// <summary> Not supported for free account </summary>
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task InsiderSummaryAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockProfiles.InsiderSummaryAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		/// <summary> Not supported for free account </summary>
		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task InsiderTransactionAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockProfiles.InsiderTransactionAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task LogoAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockProfiles.LogoAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task PeerGroupsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.StockProfiles.PeerGroupsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}
	}
}
