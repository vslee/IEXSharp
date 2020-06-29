using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharpTest.Cloud;
using NUnit.Framework;

namespace IEXSharpTest.Helper
{
	public class ExecutorRESTTest
	{
		private IEXCloudClient sandBoxClient;

		[Test]
		[TestCase(RetryPolicy.NoWait)]
		[TestCase(RetryPolicy.Linear)]
		[TestCase(RetryPolicy.Exponential)]
		public async Task TooManyRequestsCatchErrorsTest(RetryPolicy retryPolicy)
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.publishableToken,
				secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true,
				retryPolicy: retryPolicy);
			const string tooManyRequestsHttpCode = "429";

			var tasks = Enumerable.Range(0, 10).Select(_ => sandBoxClient.ApiSystemMetadata.StatusAsync()).ToList();

			var result = await Task.WhenAll(tasks);

			Assert.IsEmpty(result.Where(r => r.ErrorMessage != null && r.ErrorMessage.Contains(tooManyRequestsHttpCode)),
				$"TooManyMessages errors (HTTP CODE = 429) are not expected");
		}

		/// <summary>
		/// Tests the RetryPolicy.Manual case, which should pass through the errors since it does not catch the errors
		/// </summary>
		/// <param name="retryPolicy"></param>
		/// <returns></returns>
		[Test]
		[TestCase(RetryPolicy.Manual)]
		public async Task TooManyRequestsPassThroughErrorsTest(RetryPolicy retryPolicy)
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.publishableToken,
				secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true,
				retryPolicy: retryPolicy);
			const string tooManyRequestsHttpCode = "429";

			var tasks = Enumerable.Range(0, 10).Select(_ => sandBoxClient.ApiSystemMetadata.StatusAsync()).ToList();

			var result = await Task.WhenAll(tasks);

			Assert.IsNotEmpty(result.Where(r => r.ErrorMessage != null && r.ErrorMessage.Contains(tooManyRequestsHttpCode)),
				$"TooManyMessages errors (HTTP CODE = 429) are not expected");
		}
	}
}