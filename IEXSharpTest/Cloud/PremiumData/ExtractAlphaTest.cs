using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.PremiumData
{
	public class ExtractAlphaTest
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
			var response = await sandBoxClient.ExtractAlphaService.CrossAssetModelOneAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().Key);
		}
	}
}