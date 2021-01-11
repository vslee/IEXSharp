using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Helper;
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

		[Test]
		public void GivenAnIncorrectMessageUsageHeader_WhenGetMessageUsage_ThenItShouldNotThrow()
		{
			var responseContent = new HttpResponseMessage(HttpStatusCode.OK);

			Assert.DoesNotThrow(() =>
				{
					var errorCode = ExecutorREST.GetMessagesUsage(responseContent, "wrong-header-name");
					Assert.That(errorCode, Is.EqualTo(-1));
				}
			);
		}

		[Test]
		public void GivenAMessageUsageHeaderWithNonParseableValue_WhenGetMessageUsage_ThenItShouldReturnSomeErrorCode()
		{
			//Arrange
			var responseContent = new HttpResponseMessage(HttpStatusCode.OK)
			{
				Headers =
				{
					{"not-int-parseable", "abc"}
				}
			};

			//Arrange
			var result = ExecutorREST.GetMessagesUsage(responseContent, "not-int-parseable");

			//Assert
			Assert.That(result, Is.EqualTo(-2));
		}

		[Test]
		public void GivenACorrectMessageUsageHeader_WhenGetMessageUsage_ThenItShouldReturnCorrectValue()
		{
			//Arrange
			var responseContent = new HttpResponseMessage(HttpStatusCode.OK)
			{
				Headers =
				{
					{"iexcloud-messages-used", "1234"}
				}
			};

			//Arrange
			var result = ExecutorREST.GetMessagesUsage(responseContent, "iexcloud-messages-used");

			//Assert
			Assert.That(result, Is.EqualTo(1234));
		}
	}
}