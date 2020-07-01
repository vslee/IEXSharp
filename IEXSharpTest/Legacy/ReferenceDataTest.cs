using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;

namespace IEXSharpTest.Legacy
{
	public class ReferenceDataTest
	{
		private IEXLegacyClient prodClient;

		[SetUp]
		public void Setup()
		{
			prodClient = new IEXLegacyClient();
		}

		[Test]
		public async Task SymbolsAsyncTest()
		{
			var response = await prodClient.ReferenceData.SymbolsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task IEXCorporateActionsAsyncTest()
		{
			var response = await prodClient.ReferenceData.IEXCorporateActionsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[Ignore("IEX are no longer listing symbols.")]
		public async Task IEXDividendsAsyncTest()
		{
			var response = await prodClient.ReferenceData.IEXDividendsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[Ignore("IEX are no longer listing symbols.")]
		public async Task IEXNextDayExDateAsyncTest()
		{
			var response = await prodClient.ReferenceData.IEXNextDayExDateAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[Ignore("IEX are no longer listing symbols.")]
		public async Task IEXListedSymbolDirectoryAsyncTest()
		{
			var response = await prodClient.ReferenceData.IEXListedSymbolDirectoryAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}
	}
}