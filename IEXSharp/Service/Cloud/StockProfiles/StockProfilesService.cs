using IEXSharp.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model.StockProfiles.Response;

namespace IEXSharp.Service.Cloud.StockProfiles
{
	public class StockProfilesService : IStockProfilesService
	{
		private readonly ExecutorREST executor;

		public StockProfilesService(HttpClient client, string publishableToken, string secretToken, bool sign)
		{
			executor = new ExecutorREST(client, publishableToken, secretToken, sign);
		}

		public async Task<IEXResponse<CompanyResponse>> CompanyAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CompanyResponse>("stock/[symbol]/company", symbol);

		public async Task<IEXResponse<IEnumerable<InsiderRosterResponse>>> InsiderRosterAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderRosterResponse>>("stock/[symbol]/insider-roster",
				symbol);

		public async Task<IEXResponse<IEnumerable<InsiderSummaryResponse>>> InsiderSummaryAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderSummaryResponse>>("stock/[symbol]/insider-summary",
				symbol);

		public async Task<IEXResponse<IEnumerable<InsiderTransactionResponse>>> InsiderTransactionsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderTransactionResponse>>(
				"stock/[symbol]/insider-transactions", symbol);

		public async Task<IEXResponse<LogoResponse>> LogoAsync(string symbol) =>
			await executor.SymbolExecuteAsync<LogoResponse>("stock/[symbol]/logo", symbol);

		public async Task<IEXResponse<IEnumerable<string>>> PeerGroupsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<string>>("stock/[symbol]/peers", symbol);

	}
}
