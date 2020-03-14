using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.InvestorsExchangeData.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.V2.InvestorsExchangeData
{
	internal class InvestorsExchangeDataService : IInvestorsExchangeDataService
	{
		private readonly string _pk;
		private readonly ExecutorREST _executor;

		public InvestorsExchangeDataService(HttpClient client, string sk, string pk, bool sign)
		{
			_pk = pk;
			_executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<DeepResponse>> DeepAsync(IEnumerable<string> symbols)
		   => await _executor.SymbolsExecuteAsync<DeepResponse>("deep", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepAuctionResponse>>> DeepActionAsync(IEnumerable<string> symbols)
		  => await _executor.SymbolsExecuteAsync<Dictionary<string, DeepAuctionResponse>>("deep/auction", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepBookResponse>>> DeepBookAsync(IEnumerable<string> symbols)
		   => await _executor.SymbolsExecuteAsync<Dictionary<string, DeepBookResponse>>("deep/book", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepOperationalHaltStatusResponse>>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepOperationalHaltStatusResponse>>("deep/op-halt-status", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepOfficialPriceResponse>>> DeepOfficialPriceAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepOfficialPriceResponse>>("deep/official-price", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepSecurityEventResponse>>> DeepSecurityEventAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepSecurityEventResponse>>("deep/security-event", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepShortSalePriceTestStatusResponse>>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepShortSalePriceTestStatusResponse>>("deep/ssr-status", symbols);

		public async Task<IEXResponse<DeepSystemEventResponse>> DeepSystemEventAsync()
			=> await _executor.NoParamExecute<DeepSystemEventResponse>("deep/system-event");

		public async Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades", symbols);

		public async Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeBreaksAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades-breaks", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepTradingStatusResponse>>> DeepTradingStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepTradingStatusResponse>>("deep/trades-status", symbols);

		public async Task<IEXResponse<IEnumerable<LastResponse>>> LastAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<IEnumerable<LastResponse>>("tops/last", symbols);

		public async Task<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol)
			=> await _executor.SymbolExecuteAsyncLegacy<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>(
				"stock/[symbol]/threshold-securities", symbol);

		public async Task<IEnumerable<ListedShortInterestListResponse>> ListedShortInterestListAsync(string symbol)
			=> await _executor.SymbolExecuteAsyncLegacy<IEnumerable<ListedShortInterestListResponse>>(
				"stock/[symbol]/short-interest", symbol);

		public async Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByDateAsync(string date)
		{
			const string urlPattern = "stats/historical/daily";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", _pk);
			qsb.Add("date", date);

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsync<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByLastAsync(int last)
		{
			const string urlPattern = "stats/historical/daily";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", _pk);
			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsync<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<StatsHistoricalSummaryResponse>>> StatsHistoricalSummaryAsync(DateTime? date = null)
		{
			const string urlPattern = "stats/historical";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", _pk);
			qsb.Add("date", date == null ? DateTime.Now.ToString("yyyyMM") : ((DateTime)date).ToString("yyyyMM"));

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsync<IEnumerable<StatsHistoricalSummaryResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<StatsIntradayResponse>> StatsIntradayAsync()
			=> await _executor.NoParamExecute<StatsIntradayResponse>("stats/intraday");

		public async Task<IEXResponse<IEnumerable<StatsRecentResponse>>> StatsRecentAsync()
			=> await _executor.NoParamExecute<IEnumerable<StatsRecentResponse>>("stats/recent");

		public async Task<IEXResponse<StatsRecordResponse>> StatsRecordAsync()
			=> await _executor.NoParamExecute<StatsRecordResponse>("stats/records");

		public async Task<IEXResponse<IEnumerable<TOPSResponse>>> TOPSAsync(IEnumerable<string> symbols)
		{
			if (symbols.Count() > 0)
			{
				return await _executor.SymbolsExecuteAsync<IEnumerable<TOPSResponse>>("tops", symbols);
			}
			return await _executor.NoParamExecute<IEnumerable<TOPSResponse>>("tops");
		}
	}
}