using IEXSharp.Helper;
using IEXSharp.Model.InvestorsExchangeData.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.V2.InvestorsExchangeData
{
	internal class InvestorsExchangeDataService : IInvestorsExchangeDataService
	{
		private readonly string _pk;
		private readonly Executor _executor;

		public InvestorsExchangeDataService(HttpClient client, string sk, string pk, bool sign)
		{
			_pk = pk;
			_executor = new Executor(client, sk, pk, sign);
		}

		public async Task<Dictionary<string, DeepAuctionResponse>> DeepActionAsync(IEnumerable<string> symbols)
		  => await _executor.SymbolsExecuteAsync<Dictionary<string, DeepAuctionResponse>>("deep/auction", symbols, _pk);

		public async Task<DeepResponse> DeepAsync(IEnumerable<string> symbols)
		   => await _executor.SymbolsExecuteAsync<DeepResponse>("deep", symbols, _pk);

		public async Task<Dictionary<string, DeepBookResponse>> DeepBookAsync(IEnumerable<string> symbols)
		   => await _executor.SymbolsExecuteAsync<Dictionary<string, DeepBookResponse>>("deep/book", symbols, _pk);

		public async Task<Dictionary<string, DeepOfficialPriceResponse>> DeepOfficialPriceAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepOfficialPriceResponse>>("deep/official-price", symbols, _pk);

		public async Task<Dictionary<string, DeepOperationalHaltStatusResponse>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepOperationalHaltStatusResponse>>("deep/op-halt-status", symbols, _pk);

		public async Task<Dictionary<string, DeepSecurityEventResponse>> DeepSecurityEventAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepSecurityEventResponse>>("deep/security-event", symbols, _pk);

		public async Task<Dictionary<string, DeepShortSalePriceTestStatusResponse>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepShortSalePriceTestStatusResponse>>("deep/ssr-status", symbols, _pk);

		public async Task<DeepSystemEventResponse> DeepSystemEventAsync()
			=> await _executor.NoParamExecute<DeepSystemEventResponse>("deep/system-event", _pk);

		public async Task<Dictionary<string, IEnumerable<DeepTradeResponse>>> DeepTradeAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades", symbols, _pk);

		public async Task<Dictionary<string, IEnumerable<DeepTradeResponse>>> DeepTradeBreaksAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades-breaks", symbols, _pk);

		public async Task<Dictionary<string, DeepTradingStatusResponse>> DeepTradingStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepTradingStatusResponse>>("deep/trades-status", symbols, _pk);

		public async Task<IEnumerable<LastResponse>> LastAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<IEnumerable<LastResponse>>("tops/last", symbols, _pk);

		public async Task<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol)
			=> await _executor.SymbolExecuteAsync<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>("stock/[symbol]/threshold-securities", symbol, _pk);

		public async Task<IEnumerable<ListedShortInterestListResponse>> ListedShortInterestListAsync(string symbol)
			=> await _executor.SymbolExecuteAsync<IEnumerable<ListedShortInterestListResponse>>("stock/[symbol]/short-interest", symbol, _pk);

		public async Task<IEnumerable<StatsHisoricalDailyResponse>> StatsHistoricalDailyByDateAsync(string date)
		{
			const string urlPattern = "stats/historical/daily";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", _pk);
			qsb.Add("date", date);

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsync<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<StatsHisoricalDailyResponse>> StatsHistoricalDailyByLastAsync(int last)
		{
			const string urlPattern = "stats/historical/daily";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", _pk);
			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsync<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<StatsHistoricalSummaryResponse>> StatsHistoricalSummaryAsync(DateTime? date = null)
		{
			const string urlPattern = "stats/historical";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", _pk);
			qsb.Add("date", date == null ? DateTime.Now.ToString("yyyyMM") : ((DateTime)date).ToString("yyyyMM"));

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsync<IEnumerable<StatsHistoricalSummaryResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<StatsIntradayResponse> StatsIntradayAsync()
			=> await _executor.NoParamExecute<StatsIntradayResponse>("stats/intraday", _pk);

		public async Task<IEnumerable<StatsRecentResponse>> StatsRecentAsync()
			=> await _executor.NoParamExecute<IEnumerable<StatsRecentResponse>>("stats/recent", _pk);

		public async Task<StatsRecordResponse> StatsRecordAsync()
			=> await _executor.NoParamExecute<StatsRecordResponse>("stats/records", _pk);

		public async Task<IEnumerable<TOPSResponse>> TOPSAsync(IEnumerable<string> symbols)
		{
			if (symbols.Count() > 0)
			{
				return await _executor.SymbolsExecuteAsync<IEnumerable<TOPSResponse>>("tops", symbols, _pk);
			}
			return await _executor.NoParamExecute<IEnumerable<TOPSResponse>>("tops", _pk);
		}
	}
}