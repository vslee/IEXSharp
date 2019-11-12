using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using IEXSharp.Model.ReferenceData.Request;

namespace IEXSharpTest.V2
{
	public class ReferenceDataTest
	{
		private IEXRestV2Client sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXRestV2Client(TestGlobal.pk, TestGlobal.sk, false, true);
		}

		[Test]
		public async Task SymbolsAsyncTest()
		{
			var resposne = await sandBoxClient.ReferenceData.SymbolsAsync();

			Assert.IsNotNull(resposne);
			Assert.GreaterOrEqual(resposne.Count(), 1);
		}


		// Not supported for free account
		[Test]
		public async Task FXSymbolsAsyncTest()
		{
			var resposne = await sandBoxClient.ReferenceData.FXSymbolAsync();

			Assert.IsNotNull(resposne);
		}


		[Test]
		public async Task IEXSymbolsAsyncTest()
		{
			var resposne = await sandBoxClient.ReferenceData.IEXSymbolsAsync();

			Assert.IsNotNull(resposne);
			Assert.GreaterOrEqual(resposne.Count(), 1);
		}


		[Test]
		public async Task InternationalExchangeAsyncTest()
		{
			var resposne = await sandBoxClient.ReferenceData.InternationalExchangeAsync();

			Assert.IsNotNull(resposne);
			Assert.GreaterOrEqual(resposne.Count(), 1);
		}

		[Test]
		[TestCase("tse")]
		public async Task InternationalExchangeSymbolsAsyncTest(string exchange)
		{
			var response = await sandBoxClient.ReferenceData.InternationalExchangeSymbolsAsync(exchange);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		[TestCase("ca")]
		public async Task InternationalRegionSymbolsAsyncTest(string region)
		{
			var response = await sandBoxClient.ReferenceData.InternationalRegionSymbolsAsync(region);

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		public async Task MutualFundSymbolsAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.MutualFundSymbolsAsync();

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		public async Task OTCSymbolsAsync()
		{
			var response = await sandBoxClient.ReferenceData.OTCSymbolsAsync();

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 0);
		}

		[Test]
		public async Task USExchangeAsyncTest()
		{
			var resposne = await sandBoxClient.ReferenceData.USExchangeAsync();

			Assert.IsNotNull(resposne);
			Assert.GreaterOrEqual(resposne.Count(), 1);
		}

		[Test]
		[TestCase(DateType.Holiday)]
		[TestCase(DateType.Trade)]
		[TestCase(DateType.Trade, DirectionType.Last)]
		[TestCase(DateType.Trade, DirectionType.Last, 2)]
		public async Task USHolidaysAndTradingDatesAsyncTest(DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null)
		{
			var resposne = await sandBoxClient.ReferenceData.USHolidaysAndTradingDatesAsync(type, direction, last, startDate);

			Assert.IsNotNull(resposne);
			Assert.GreaterOrEqual(resposne.Count(), 1);
		}

		[Test]
		[TestCase(DateType.Holiday)]
		[TestCase(DateType.Trade)]
		[TestCase(DateType.Trade, DirectionType.Last)]
		[TestCase(DateType.Trade, DirectionType.Last, 2)]
		public async Task USHolidaysAndTradingDatesAsyncDateTest(DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null)
		{
			startDate = new DateTime(2019, 03, 25);
			var resposne = await sandBoxClient.ReferenceData.USHolidaysAndTradingDatesAsync(type, direction, last, startDate);

			Assert.IsNotNull(resposne);
			Assert.GreaterOrEqual(resposne.Count(), 1);
		}
	}
}