using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;

namespace IEXSharpTest.Cloud
{
	public class APISystemMetadataTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
		}

		[Test]
		public async Task StatusAsyncTest()
		{
			var response = await sandBoxClient.ApiSystemMetadata.StatusAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}
