using IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.InvestorsExchangeData.Response;
using IEXSharp.Model.CoreData.Market.Response;
using IEXSharp.Model.CoreData.MarketInfo.Response;

namespace IEXSharp.Service.Legacy.Market
{
	internal class MarketService : IMarketService
	{
		private readonly ExecutorREST executor;

		internal MarketService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<TOPSResponse>>> TOPSAsync(IEnumerable<string> symbols)
		{
			if (symbols.Count() > 0)
			{
				return await executor.SymbolsExecuteAsync<IEnumerable<TOPSResponse>>("tops", symbols);
			}
			return await executor.NoParamExecute<IEnumerable<TOPSResponse>>("tops");
		}

		public async Task<IEXResponse<IEnumerable<LastResponse>>> LastAsync(IEnumerable<string> symbols)
			=> await executor.SymbolsExecuteAsync<IEnumerable<LastResponse>>("tops/last", symbols);

		public async Task<IEXResponse<Dictionary<string, IEnumerable<HISTResponse>>>> HISTAsync()
		{
			const string urlPattern = "hist";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<Dictionary<string, IEnumerable<HISTResponse>>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<HISTResponse>>> HISTByDateAsync(DateTime date)
		{
			const string urlPattern = "hist";

			var qsb = new QueryStringBuilder();
			qsb.Add("date", ((DateTime)date).ToString("yyyyMMdd"));

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<IEnumerable<HISTResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<DeepResponse>> DeepAsync(IEnumerable<string> symbols)
		   => await executor.SymbolsExecuteAsync<DeepResponse>("deep", symbols);

		public async Task<IEXResponse<DeepBookResponse>> DeepBookAsync(IEnumerable<string> symbols)
		   => await executor.SymbolsExecuteAsync<DeepBookResponse>("deep/book", symbols);

		public async Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeAsync(IEnumerable<string> symbols)
			=> await executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades", symbols);

		public async Task<IEXResponse<DeepSystemEventResponse>> DeepSystemEventAsync()
			=> await executor.NoParamExecute<DeepSystemEventResponse>("deep/system-event");

		public async Task<IEXResponse<Dictionary<string, DeepTradingStatusResponse>>> DeepTradingStatusAsync(IEnumerable<string> symbols)
			=> await executor.SymbolsExecuteAsync<Dictionary<string, DeepTradingStatusResponse>>("deep/trades-status", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepOperationalHaltStatusResponse>>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols)
			=> await executor.SymbolsExecuteAsync<Dictionary<string, DeepOperationalHaltStatusResponse>>("deep/op-halt-status", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepShortSalePriceTestStatusResponse>>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols)
			=> await executor.SymbolsExecuteAsync<Dictionary<string, DeepShortSalePriceTestStatusResponse>>("deep/ssr-status", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepSecurityEventResponse>>> DeepSecurityEventAsync(IEnumerable<string> symbols)
			=> await executor.SymbolsExecuteAsync<Dictionary<string, DeepSecurityEventResponse>>("deep/security-event", symbols);

		public async Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeBreaksAsync(IEnumerable<string> symbols)
			=> await executor.SymbolsExecuteAsync<Dictionary<string, IEnumerable<DeepTradeResponse>>>("deep/trades-breaks", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepAuctionResponse>>> DeepAuctionAsync(IEnumerable<string> symbols)
		  => await executor.SymbolsExecuteAsync<Dictionary<string, DeepAuctionResponse>>("deep/auction", symbols);

		public async Task<IEXResponse<Dictionary<string, DeepOfficialPriceResponse>>> DeepOfficialPriceAsync(IEnumerable<string> symbols)
			=> await executor.SymbolsExecuteAsync<Dictionary<string, DeepOfficialPriceResponse>>("deep/official-price", symbols);
		public async Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketVolumeUSAsync() =>
			await executor.NoParamExecute<IEnumerable<MarketVolumeUSResponse>>("market");
	}
}