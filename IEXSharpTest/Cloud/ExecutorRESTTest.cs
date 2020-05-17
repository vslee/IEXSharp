using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Helper;
using NUnit.Framework;

namespace IEXSharpTest.Cloud
{
	public class ExecutorRESTTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
		}

		[Test]
		public async Task TooManyRequestsTest()
		{
			const string tooManyRequestsHttpCode = "429";

			var tasks = Enumerable.Range(0, 10).Select(_ => sandBoxClient.ApiSystemMetadata.StatusAsync()).ToList();

			var result = await Task.WhenAll(tasks);

			Assert.IsEmpty(result.Where(r => r.ErrorMessage != null && r.ErrorMessage.Contains(tooManyRequestsHttpCode)),
				$"TooManyMessages errors (HTTP CODE = 429) are not expected");
		}
	}
}