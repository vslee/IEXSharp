using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.PremiumData
{
	public class KavoutTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task KScoreForUsEquitiesAsyncTest(string symbol)
		{
			var response = await sandBoxClient.KavoutService.KScoreForUsEquitiesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().Symbol);
		}

		[Test]
		[TestCase("")]
		[TestCase("603993-CN")]
		public async Task KScoreForChinaASharesAsyncTest(string symbol)
		{
			var response = await sandBoxClient.KavoutService.KScoreForChinaASharesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().Symbol);
		}
	}
}