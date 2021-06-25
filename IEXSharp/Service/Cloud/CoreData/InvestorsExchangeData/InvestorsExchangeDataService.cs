using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.InvestorsExchangeData.Response;

namespace IEXSharp.Service.Cloud.CoreData.InvestorsExchangeData
{
	internal class InvestorsExchangeDataService : IInvestorsExchangeDataService
	{
		private readonly ExecutorREST executor;
		private readonly ExecutorSSE executorSSE;

		internal InvestorsExchangeDataService(ExecutorREST executor, ExecutorSSE executorSSE)
		{
			this.executor = executor;
			this.executorSSE = executorSSE;
		}

		public async Task<IEXResponse<DeepResponse>> DeepAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<DeepResponse>("deep", symbols);

		public SSEClient<DeepResponse> DeepStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepResponse>("deep", new List<string>{symbol}, new List<string>{"deep"});

		public async Task<IEXResponse<Dictionary<string, DeepAuctionResponse>>> DeepAuctionAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, DeepAuctionResponse>>("deep/auction", symbols);

		public SSEClient<DeepAuctionResponse> DeepAuctionStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepAuctionResponse>("deep", new List<string>{symbol}, new List<string>{"deep-auction"});

		public async Task<IEXResponse<Dictionary<string, DeepBookResponse>>> DeepBookAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, DeepBookResponse>>("deep/book", symbols);

		public SSEClient<DeepBookResponse> DeepBookStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepBookResponse>("deep", new List<string>{symbol}, new List<string>{"book"});

		public async Task<IEXResponse<Dictionary<string, DeepOperationalHaltStatusResponse>>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, DeepOperationalHaltStatusResponse>>("deep/op-halt-status", symbols);

		public SSEClient<DeepOperationalHaltStatusResponse> DeepOperationHaltStatusStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepOperationalHaltStatusResponse>("deep", new List<string>{symbol}, new List<string>{"op-halt-status"});

		public async Task<IEXResponse<Dictionary<string, DeepOfficialPriceResponse>>> DeepOfficialPriceAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, DeepOfficialPriceResponse>>("deep/official-price", symbols);

		public SSEClient<DeepOfficialPriceResponse> DeepOfficialPriceStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepOfficialPriceResponse>("deep", new List<string>{symbol}, new List<string>{"official-price"});

		public async Task<IEXResponse<Dictionary<string, DeepSecurityEventResponse>>> DeepSecurityEventAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, DeepSecurityEventResponse>>("deep/security-event", symbols);

		public SSEClient<DeepSecurityEventResponse> DeepSecurityEventStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepSecurityEventResponse>("deep", new List<string>{symbol}, new List<string>{"security-event"});

		public async Task<IEXResponse<Dictionary<string, DeepShortSalePriceTestStatusResponse>>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, DeepShortSalePriceTestStatusResponse>>("deep/ssr-status", symbols);

		public SSEClient<DeepShortSalePriceTestStatusResponse> DeepShortSalePriceTestStatusStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepShortSalePriceTestStatusResponse>("deep", new List<string>{symbol}, new List<string>{"ssr-status"});

		public async Task<IEXResponse<DeepSystemEventResponse>> DeepSystemEventAsync() =>
			await executor.NoParamExecute<DeepSystemEventResponse>("deep/system-event");

		public SSEClient<DeepSystemEventResponse> DeepSystemEventStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepSystemEventResponse>("deep", new List<string>{symbol}, new List<string>{"system-event"});

		public async Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades", symbols);

		public SSEClient<DeepTradeStreamResponse> DeepTradeStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepTradeStreamResponse>("deep", new List<string>{symbol}, new List<string>{"trades"});

		public async Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeBreaksAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades-breaks", symbols);

		public SSEClient<DeepTradeStreamResponse> DeepTradeBreaksStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepTradeStreamResponse>("deep", new List<string>{symbol}, new List<string>{"trade-breaks"});

		public async Task<IEXResponse<Dictionary<string, DeepTradingStatusResponse>>> DeepTradingStatusAsync(IEnumerable<string> symbols) =>
			await executor.SymbolsExecuteAsync<Dictionary<string, DeepTradingStatusResponse>>("deep/trades-status", symbols);

		public SSEClient<DeepTradingStatusStreamResponse> DeepTradingStatusStream(string symbol) =>
			executorSSE.SymbolsChannelsSubscribeSSE<DeepTradingStatusStreamResponse>("deep", new List<string>{symbol}, new List<string>{"trading-status"});

		public async Task<IEXResponse<IEnumerable<LastResponse>>> LastAsync(IEnumerable<string> symbols)
		{
			if (symbols.Any())
			{
				return await executor.SymbolsExecuteAsync<IEnumerable<LastResponse>>("tops/last", symbols);
			}
			return await executor.NoParamExecute<IEnumerable<LastResponse>>("tops/last");
		}

		public async Task<IEXResponse<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>("stock/[symbol]/threshold-securities", symbol);

		public async Task<IEXResponse<IEnumerable<ListedShortInterestListResponse>>> ListedShortInterestListAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<ListedShortInterestListResponse>>("stock/[symbol]/short-interest", symbol);

		public async Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByDateAsync(string date)
		{
			const string urlPattern = "stats/historical/daily";

			var qsb = new QueryStringBuilder();
			qsb.Add("date", date);

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByLastAsync(int last)
		{
			const string urlPattern = "stats/historical/daily";

			var qsb = new QueryStringBuilder();
			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<StatsHistoricalSummaryResponse>>> StatsHistoricalSummaryAsync(DateTime? date = null)
		{
			const string urlPattern = "stats/historical";

			var qsb = new QueryStringBuilder();
			qsb.Add("date", date == null ? DateTime.Now.ToString("yyyyMM") : ((DateTime)date).ToString("yyyyMM"));

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<IEnumerable<StatsHistoricalSummaryResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<StatsIntradayResponse>> StatsIntradayAsync() =>
			await executor.NoParamExecute<StatsIntradayResponse>("stats/intraday");

		public async Task<IEXResponse<IEnumerable<StatsRecentResponse>>> StatsRecentAsync() =>
			await executor.NoParamExecute<IEnumerable<StatsRecentResponse>>("stats/recent");

		public async Task<IEXResponse<StatsRecordResponse>> StatsRecordAsync() =>
			await executor.NoParamExecute<StatsRecordResponse>("stats/records");

		public async Task<IEXResponse<IEnumerable<TOPSResponse>>> TOPSAsync(IEnumerable<string> symbols)
		{
			if (symbols.Any())
			{
				return await executor.SymbolsExecuteAsync<IEnumerable<TOPSResponse>>("tops", symbols);
			}
			return await executor.NoParamExecute<IEnumerable<TOPSResponse>>("tops");
		}
	}
}