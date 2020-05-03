using NUnit.Framework;
using System.Threading.Tasks;
using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.Account.Request;
using VSLee.IEXSharp.Model.Account.Response;

namespace VSLee.IEXSharpTest.Cloud
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
			var response = await sandBoxClient.Account.MetadataAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(UsageType.All)]
		[TestCase(UsageType.Messages)]
		public async Task UsageAsyncTest(UsageType type)
		{
			var response = await sandBoxClient.Account.UsageAsync(type);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}