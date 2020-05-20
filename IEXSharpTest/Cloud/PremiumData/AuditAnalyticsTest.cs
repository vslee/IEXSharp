using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.PremiumData
{
	public class AuditAnalyticsTest
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
		public async Task DirectorAndOfficerChangesAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AuditAnalyticsService.DirectorAndOfficerChangesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().FirstName);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task AccountingQualityAndRiskMatrixAsyncTest(string symbol)
		{
			var response = await sandBoxClient.AuditAnalyticsService.AccountingQualityAndRiskMatrixAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().CeoChangeSeverity);
		}
	}
}