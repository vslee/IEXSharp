using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
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
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
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
		public async Task UsageAsyncTest(UsageType type)
		{
			var response = await sandBoxClient.Account.UsageAsync(type);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			UsageResponse usageResponse = response.Data;
			UsageResponseMessages messages = usageResponse.messages;

			Assert.Greater(messages.monthlyUsage, 0);
			Assert.Greater(int.Parse(messages.keyUsage.GetValueOrDefault("FX_CONVERSION")), 0);
		}

		[Test]
		public async Task MessageUsageAsyncTest()
		{
			var response = await sandBoxClient.Account.MessageUsageAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);

			MessageUsageResponse usageResponse = response.Data;

			Assert.Greater(usageResponse.monthlyUsage, 0);
			Assert.Greater(int.Parse(usageResponse.keyUsage.GetValueOrDefault("FX_CONVERSION")), 0);
		}

		[Test]
		// TODO - Rules appears to have a different response from these, returns an empty array.
		[TestCase(UsageType.Rules)]
		[TestCase(UsageType.RuleRecords)]
		[TestCase(UsageType.Alerts)]
		[TestCase(UsageType.AlertRecords)]
		public async Task UnauthorisedUsageAsyncTest(UsageType type)
		{
			var response = await sandBoxClient.Account.UsageAsync(type);

			// This is due to a key on the Start plan and lack of documentation on https://iexcloud.io/docs/api/#usage around these.
			Assert.AreEqual("Forbidden - The API key provided is not valid.", response.ErrorMessage);
		}
	}
}