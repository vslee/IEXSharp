using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.ReferenceData.Request;
using IEXSharp.Model.ReferenceData.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.ReferenceData
{
	internal class ReferenceDataService : IReferenceDataService
	{
		private readonly ExecutorREST executor;

		internal ReferenceDataService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<SearchResponse>>> SearchAsync(string fragment)
		{
			const string urlPattern = "search/[fragment]";

			var pathNvc = new NameValueCollection
			{
				{"fragment", fragment},
			};

			return await executor.ExecuteAsync<IEnumerable<SearchResponse>>(urlPattern, pathNvc, null);
		}

		public async Task<IEXResponse<SymbolFXResponse>> SymbolFXAsync() =>
			await executor.NoParamExecute<SymbolFXResponse>("ref-data/fx/symbols");

		public async Task<IEXResponse<IEnumerable<SymbolCryptoResponse>>> SymbolCryptoAsync() =>
			await executor.NoParamExecute<IEnumerable<SymbolCryptoResponse>>("ref-data/crypto/symbols");

		public async Task<IEXResponse<IEnumerable<SymbolIEXResponse>>> SymbolsIEXAsync() =>
			await executor.NoParamExecute<IEnumerable<SymbolIEXResponse>>("ref-data/iex/symbols");

		public async Task<IEXResponse<IEnumerable<SymbolInternationalResponse>>> SymbolsInternationalRegionAsync(string region)
		{
			const string urlPattern = "ref-data/region/[region]/symbols";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"region", region}
			};

			return await executor.ExecuteAsync<IEnumerable<SymbolInternationalResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<SymbolInternationalResponse>>> SymbolsInternationalExchangeAsync(string exchange)
		{
			const string urlPattern = "ref-data/exchange/[exchange]/symbols";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"exchange", exchange}
			};

			return await executor.ExecuteAsync<IEnumerable<SymbolInternationalResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<ExchangeInternationalResponse>>> ExchangeInternationalAsync() =>
			await executor.NoParamExecute<IEnumerable<ExchangeInternationalResponse>>("ref-data/exchanges");

		public async Task<IEXResponse<IEnumerable<SymbolMutualFundResponse>>> SymbolsMutualFundAsync() =>
			await executor.NoParamExecute<IEnumerable<SymbolMutualFundResponse>>("ref-data/mutual-funds/symbols");

		public async Task<IEXResponse<Dictionary<string, string[]>>> SymbolsOptionsAsync() =>
			await executor.NoParamExecute<Dictionary<string, string[]>>("ref-data/options/symbols");

		public async Task<IEXResponse<IEnumerable<SymbolOTCResponse>>> SymbolsOTCAsync() =>
			await executor.NoParamExecute<IEnumerable<SymbolOTCResponse>>("ref-data/otc/symbols");

		public async Task<IEXResponse<IEnumerable<SectorResponse>>> SectorsAsync() =>
			await executor.NoParamExecute<IEnumerable<SectorResponse>>("ref-data/sectors");

		public async Task<IEXResponse<IEnumerable<SymbolResponse>>> SymbolsAsync() =>
			await executor.NoParamExecute<IEnumerable<SymbolResponse>>("ref-data/symbols");

		public async Task<IEXResponse<IEnumerable<TagResponse>>> TagsAsync() =>
			await executor.NoParamExecute<IEnumerable<TagResponse>>("ref-data/tags");

		public async Task<IEXResponse<IEnumerable<ExchangeUSResponse>>> ExchangeUSAsync() =>
			await executor.NoParamExecute<IEnumerable<ExchangeUSResponse>>("ref-data/market/us/exchanges");

		public async Task<IEXResponse<IEnumerable<HolidaysAndTradingDatesUSResponse>>> HolidaysAndTradingDatesUSAsync(
			DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null)
		{
			const string urlPattern = "ref-data/us/dates/[type]/[direction]/[last]/[startDate]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"type", type.GetDescriptionFromEnum()},
				{"direction", direction.GetDescriptionFromEnum()},
				{"last", last.ToString()},
				{"startDate", startDate == null ? DateTime.Now.ToString("yyyyMMdd") : ((DateTime) startDate).ToString("yyyyMMdd")}
			};

			return await executor.ExecuteAsync<IEnumerable<HolidaysAndTradingDatesUSResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}