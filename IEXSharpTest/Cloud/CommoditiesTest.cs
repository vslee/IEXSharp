using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.Commodities.Request;
using NUnit.Framework;

namespace IEXSharpTest.Cloud
{
	public class CommoditiesTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.publishableToken, secretToken: TestGlobal.secretToken, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase(CommoditySymbol.DCOILBRENTEU)]
		[TestCase(CommoditySymbol.DCOILWTICO)]
		[TestCase(CommoditySymbol.DHHNGSP)]
		[TestCase(CommoditySymbol.DHOILNYH)]
		[TestCase(CommoditySymbol.DJFUELUSGULF)]
		[TestCase(CommoditySymbol.DPROPANEMBTX)]
		[TestCase(CommoditySymbol.GASDESW)]
		[TestCase(CommoditySymbol.GASMIDCOVW)]
		[TestCase(CommoditySymbol.GASPRMCOVW)]
		[TestCase(CommoditySymbol.GASREGCOVW)]
		public async Task GetDataPointsTest(CommoditySymbol symbol)
		{
			var response = await sandBoxClient.Commodities.DataPointAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase(CommoditySymbol.DCOILBRENTEU)]
		[TestCase(CommoditySymbol.DCOILWTICO)]
		[TestCase(CommoditySymbol.DHHNGSP)]
		[TestCase(CommoditySymbol.DHOILNYH)]
		[TestCase(CommoditySymbol.DJFUELUSGULF)]
		[TestCase(CommoditySymbol.DPROPANEMBTX)]
		[TestCase(CommoditySymbol.GASDESW)]
		[TestCase(CommoditySymbol.GASMIDCOVW)]
		[TestCase(CommoditySymbol.GASPRMCOVW)]
		[TestCase(CommoditySymbol.GASREGCOVW)]
		public async Task GetTimeSeriesTest(CommoditySymbol symbol)
		{
			var response = await sandBoxClient.Commodities.TimeSeriesAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data.FirstOrDefault()?.value);
		}
	}
}
