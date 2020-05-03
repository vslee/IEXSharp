using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VSLee.IEXSharp;

namespace VSLee.IEXSharpTest.Cloud
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
