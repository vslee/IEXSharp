using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.EconomicData.Request;
using NUnit.Framework;

namespace IEXSharpTest.Cloud
{
	public class EconomicDataTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
		}

		[Test]
		[TestCase(EconomicDataSymbol.MMNRNJ)]
		[TestCase(EconomicDataSymbol.MMNRJD)]
		[TestCase(EconomicDataSymbol.CPIAUCSL)]
		[TestCase(EconomicDataSymbol.TERMCBCCALLNS)]
		[TestCase(EconomicDataSymbol.FEDFUNDS)]
		[TestCase(EconomicDataSymbol.A191RL1Q225SBEA)]
		[TestCase(EconomicDataSymbol.WIMFSL)]
		[TestCase(EconomicDataSymbol.IC4WSA)]
		[TestCase(EconomicDataSymbol.INDPRO)]
		[TestCase(EconomicDataSymbol.MORTGAGE30US)]
		[TestCase(EconomicDataSymbol.MORTGAGE15US)]
		[TestCase(EconomicDataSymbol.MORTGAGE5US)]
		[TestCase(EconomicDataSymbol.HOUST)]
		[TestCase(EconomicDataSymbol.PAYEMS)]
		[TestCase(EconomicDataSymbol.TOTALSA)]
		[TestCase(EconomicDataSymbol.WRMFSL)]
		[TestCase(EconomicDataSymbol.UNRATE)]
		[TestCase(EconomicDataSymbol.RECPROUSM156N)]
		public async Task GetDataPointsTest(EconomicDataSymbol symbol)
		{
			var response = await sandBoxClient.EconomicData.DataPointAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(null)]
		[TestCase(EconomicDataTimeSeriesSymbol.A191RL1Q225SBEA)]
		[TestCase(EconomicDataTimeSeriesSymbol.MORTGAGE30US)]
		[TestCase(EconomicDataTimeSeriesSymbol.MORTGAGE15US)]
		[TestCase(EconomicDataTimeSeriesSymbol.MORTGAGE5US)]
		[TestCase(EconomicDataTimeSeriesSymbol.HOUST)]
		[TestCase(EconomicDataTimeSeriesSymbol.UNRATE)]
		public async Task GetTimeSeriesTest(EconomicDataTimeSeriesSymbol symbol)
		{
			var response = await sandBoxClient.EconomicData.TimeSeriesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
	}
}