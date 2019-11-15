using NUnit.Framework;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.Account.Request;
using IEXSharp.Model.Account.Response;

namespace IEXSharpTest.Cloud
{
	public class AccountTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
		}

		[Test]
		public async Task MetadataAsyncTest()
		{
			MetadataResponse response = await sandBoxClient.Account.MetadataAsync();

			Assert.IsNotNull(response);
		}

		[Test]
		[TestCase(UsageType.All)]
		public async Task UsageAsyncTest(UsageType type)
		{
			UsageResponse response = await sandBoxClient.Account.UsageAsync(type);

			Assert.IsNotNull(response);
		}
	}
}