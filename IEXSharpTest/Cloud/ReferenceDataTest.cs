using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.ReferenceData.Request;

namespace IEXSharpTest.Cloud
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

		/// <summary>
		/// Not supported for free account
		/// </summary>
		/// <returns></returns>
		[Test]
		public async Task SymbolsFXAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.SymbolFXAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		public async Task SymbolCryptoAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.SymbolCryptoAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);

			Assert.IsNotNull(response.Data.First().symbol);
			Assert.IsNotNull(response.Data.First().name);
			Assert.IsNotNull(response.Data.First().isEnabled);
		}

		[Test]
		public async Task SymbolsIEXAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.SymbolsIEXAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("ca")]
		public async Task SymbolsInternationalRegionAsyncTest(string region)
		{
			var response = await sandBoxClient.ReferenceData.SymbolsInternationalRegionAsync(region);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		[TestCase("tse")]
		public async Task SymbolsInternationalExchangeAsyncTest(string exchange)
		{
			var response = await sandBoxClient.ReferenceData.SymbolsInternationalExchangeAsync(exchange);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task ExchangeInternationalAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.ExchangeInternationalAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task SymbolsMutualFundAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.SymbolsMutualFundAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task SymbolsOTCAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.SymbolsOTCAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task SectorsAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.SectorsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task SymbolsAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.SymbolsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task TagsAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.TagsAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}

		[Test]
		public async Task ExchangeUSAsyncTest()
		{
			var response = await sandBoxClient.ReferenceData.ExchangeUSAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
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
	}
}