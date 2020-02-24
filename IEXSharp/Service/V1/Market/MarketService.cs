using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.InvestorsExchangeData.Response;
using VSLee.IEXSharp.Model.Market.Response;
using VSLee.IEXSharp.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.V1.Market
{
	internal class MarketService : IMarketService
	{
		private ExecutorREST _executor;

		public MarketService(HttpClient client)
		{
			_executor = new ExecutorREST(client, "", "", false);
		}

		public async Task<IEnumerable<TOPSResponse>> TOPSAsync(IEnumerable<string> symbols)
		{
			if (symbols.Count() > 0)
			{
				return await _executor.SymbolsExecuteAsync<IEnumerable<TOPSResponse>>("tops", symbols);
			}
			return await _executor.NoParamExecute<IEnumerable<TOPSResponse>>("tops");
		}

		public async Task<IEnumerable<LastResponse>> LastAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<IEnumerable<LastResponse>>("tops/last", symbols);

		public async Task<IEXResponse<Dictionary<string, IEnumerable<HISTResponse>>>> HISTAsync()
		{
			const string urlPattern = "hist";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsync<Dictionary<string, IEnumerable<HISTResponse>>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<HISTResponse>>> HISTByDateAsync(DateTime date)
		{
			const string urlPattern = "hist";

			var qsb = new QueryStringBuilder();
			qsb.Add("date", ((DateTime)date).ToString("yyyyMMdd"));

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsync<IEnumerable<HISTResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<DeepResponse> DeepAsync(IEnumerable<string> symbols)
		   => await _executor.SymbolsExecuteAsync<DeepResponse>("deep", symbols);

		public async Task<DeepBookResponse> DeepBookAsync(IEnumerable<string> symbols)
		   => await _executor.SymbolsExecuteAsync<DeepBookResponse>("deep/book", symbols);

		public async Task<Dictionary<string, IEnumerable<DeepTradeResponse>>> DeepTradeAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades", symbols);

		public async Task<DeepSystemEventResponse> DeepSystemEventAsync()
			=> await _executor.NoParamExecute<DeepSystemEventResponse>("deep/system-event");

		public async Task<Dictionary<string, DeepTradingStatusResponse>> DeepTradingStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepTradingStatusResponse>>("deep/trades-status", symbols);

		public async Task<Dictionary<string, DeepOperationalHaltStatusResponse>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepOperationalHaltStatusResponse>>("deep/op-halt-status", symbols);

		public async Task<Dictionary<string, DeepShortSalePriceTestStatusResponse>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepShortSalePriceTestStatusResponse>>("deep/ssr-status", symbols);

		public async Task<Dictionary<string, DeepSecurityEventResponse>> DeepSecurityEventAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepSecurityEventResponse>>("deep/security-event", symbols);

		public async Task<Dictionary<string, IEnumerable<DeepTradeResponse>>> DeepTradeBreaksAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades-breaks", symbols);

		public async Task<Dictionary<string, DeepAuctionResponse>> DeepActionAsync(IEnumerable<string> symbols)
		  => await _executor.SymbolsExecuteAsync<Dictionary<string, DeepAuctionResponse>>("deep/auction", symbols);

		public async Task<Dictionary<string, DeepOfficialPriceResponse>> DeepOfficialPriceAsync(IEnumerable<string> symbols)
			=> await _executor.SymbolsExecuteAsync<Dictionary<string, DeepOfficialPriceResponse>>("deep/official-price", symbols);
		public async Task<IEnumerable<USMarketVolumeResponse>> USMarketVolumeAsync() =>
			await _executor.NoParamExecute<IEnumerable<USMarketVolumeResponse>>("market");
	}
}