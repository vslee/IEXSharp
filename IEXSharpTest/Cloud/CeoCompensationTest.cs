using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;

namespace IEXSharpTest.Cloud
{
	public class CeoCompensationTest
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
		public async Task GetCeoCompensationTest(string symbol)
		{
			var response = await sandBoxClient.CeoCompensation.CeoCompensationAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.name);
			Assert.IsNotNull(response.Data.companyName);
			Assert.IsNotNull(response.Data.salary);
		}
	}
}
