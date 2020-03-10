using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.ReferenceData.Request;

namespace VSLee.IEXSharpTest.Cloud
{
	public class ReferenceDataTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
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

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("ca")]
		public async Task InternationalRegionSymbolsAsyncTest(string region)
		{
			var response = await sandBoxClient.ReferenceData.InternationalRegionSymbolsAsync(region);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
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
		public async Task ExchangeUSAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.ExchangeUSAsync();

			Assert.IsNotNull(response);
			Assert.GreaterOrEqual(response.Count(), 1);
		}

		[Test]
		[TestCase(DateType.Holiday)]
		[TestCase(DateType.Trade)]
		[TestCase(DateType.Trade, DirectionType.Last)]
		[TestCase(DateType.Trade, DirectionType.Last, 2)]
		public async Task HolidaysAndTradingDatesUSAsyncTest(DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null)
		{
			var response = await sandBoxClient.ReferenceData.HolidaysAndTradingDatesUSAsync(type, direction, last, startDate);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase(DateType.Holiday)]
		[TestCase(DateType.Trade)]
		[TestCase(DateType.Trade, DirectionType.Last)]
		[TestCase(DateType.Trade, DirectionType.Last, 2)]
		public async Task HolidaysAndTradingDatesUSAsyncDateTest(DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null)
		{
			startDate = new DateTime(2019, 03, 25);
			var response = await sandBoxClient.ReferenceData.HolidaysAndTradingDatesUSAsync(type, direction, last, startDate);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("apple")]
		public async Task SearchAsyncTest(string pattern)
		{
			var response = await sandBoxClient.ReferenceData.SearchAsync(pattern);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);

			foreach (var searchResultModel in response.Data)
			{
				Assert.IsNotEmpty(searchResultModel.exchange);
				Assert.IsNotEmpty(searchResultModel.securityName);
				Assert.IsNotEmpty(searchResultModel.securityType);
				Assert.IsNotEmpty(searchResultModel.symbol);
				Assert.IsNotEmpty(searchResultModel.region);
			}
		}
	}
}