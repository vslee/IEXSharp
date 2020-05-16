using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.StockProfiles.Response;

namespace IEXSharp.Service.Cloud.CoreData.StockProfiles
{
	public class StockProfilesService : IStockProfilesService
	{
		private readonly ExecutorREST executor;

		internal StockProfilesService(ExecutorREST executor)
		{
			this.executor = executor;
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
