using System.Linq;
using System.Threading.Tasks;
using IEXSharp.Model.Treasuries.Request;
using NUnit.Framework;
using IEXSharp;

namespace IEXSharpTest.Cloud
{
	public class TreasuriesTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase(TreasuryRateSymbol.DGS30)]
		[TestCase(TreasuryRateSymbol.DGS20)]
		[TestCase(TreasuryRateSymbol.DGS10)]
		[TestCase(TreasuryRateSymbol.DGS5)]
		[TestCase(TreasuryRateSymbol.DGS2)]
		[TestCase(TreasuryRateSymbol.DGS1)]
		[TestCase(TreasuryRateSymbol.DGS6MO)]
		[TestCase(TreasuryRateSymbol.DGS3MO)]
		[TestCase(TreasuryRateSymbol.DGS1MO)]
		public async Task GetTreasuryDataPointTest(TreasuryRateSymbol symbol)
		{
			var response = await sandBoxClient.Treasuries.DataPointAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(TreasuryRateSymbol.DGS1MO)]
		public async Task GetTreasuryTimeSeriesTest(TreasuryRateSymbol symbol)
		{
			var response = await sandBoxClient.Treasuries.TimeSeriesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.FirstOrDefault()?.id);
			Assert.IsNotNull(response.Data.FirstOrDefault()?.value);
		}
	}
}
