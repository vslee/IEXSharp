using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.PremiumData
{
	public class FraudFactorsTest
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
		public async Task SimilarityIndexAsyncTest(string symbol)
		{
			var response = await sandBoxClient.FraudFactorsService.SimilarityIndexAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().symbol);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task NonTimelyFilingsAsyncTest(string symbol)
		{
			var response = await sandBoxClient.FraudFactorsService.NonTimelyFilingsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().symbol);
		}
	}
}