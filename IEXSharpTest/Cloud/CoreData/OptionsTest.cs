using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.CoreData.Options.Request;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.CoreData
{
	public class OptionsTest
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
		public async Task EndOfDayOptionsTest(string symbol)
		{
			var response = await sandBoxClient.Options.OptionsAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "202004")]
		[TestCase("FB", "202004")]
		public async Task EndOfDayOptionsTest(string symbol, string expiration)
		{
			var response = await sandBoxClient.Options.OptionsAsync(symbol, expiration);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "202004", OptionSide.Call)]
		[TestCase("FB", "202004", OptionSide.Put)]
		public async Task EndOfDayOptionsTest(string symbol, string expiration, OptionSide optionSide)
		{
			var response = await sandBoxClient.Options.OptionsAsync(symbol, expiration, optionSide);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}
