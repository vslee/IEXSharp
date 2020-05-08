using IEXSharp.Model;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model.Shared.Request;
using IEXSharp.Model.StockResearch.Response;

namespace IEXSharp.Service.Cloud.StockResearch
{
	public class StockResearchService : IStockResearchService
	{
		private readonly ExecutorREST executor;

		public StockResearchService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<AdvancedStatsResponse>> AdvancedStatsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<AdvancedStatsResponse>("stock/[symbol]/advanced-stats", symbol);

		public async Task<IEXResponse<IEnumerable<AnalystRecommendationsResponse>>> AnalystRecommendationsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<AnalystRecommendationsResponse>>("stock/[symbol]/recommendation-trends", symbol);

		public async Task<IEXResponse<EstimatesResponse>> EstimatesAsync(string symbol, Period period = Period.Quarter, int last = 1)
		{
			const string urlPattern = "stock/[symbol]/estimates/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescriptionFromEnum());

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"last", last.ToString()}
			};

			return await executor.ExecuteAsync<EstimatesResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> EstimateFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			const string urlPattern = "stock/[symbol]/estimates/[last]/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescriptionFromEnum());

			var pathNvc = new NameValueCollection
			{
				{ "symbol", symbol },
				{ "last", last.ToString() },
				{ "field", field }
			};

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<FundOwnershipResponse>>> FundOwnershipAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<FundOwnershipResponse>>("stock/[symbol]/fund-ownership", symbol);

		public async Task<IEXResponse<IEnumerable<InstitutionalOwnershipResponse>>> InstitutionalOwnerShipAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InstitutionalOwnershipResponse>>(
				"stock/[symbol]/institutional-ownership", symbol);

		public async Task<IEXResponse<KeyStatsResponse>> KeyStatsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<KeyStatsResponse>("stock/[symbol]/stats", symbol);

		public async Task<IEXResponse<string>> KeyStatsStatAsync(string symbol, string stat)
		{
			const string urlPattern = "stock/[symbol]/stats/[stat]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "stat", stat } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<PriceTargetResponse>> PriceTargetAsync(string symbol) =>
			await executor.SymbolExecuteAsync<PriceTargetResponse>("stock/[symbol]/price-target", symbol);

		public async Task<IEXResponse<TechnicalIndicatorsResponse>> TechnicalIndicatorsAsync(string symbol, string indicator) =>
			await executor.SymbolExecuteAsync<TechnicalIndicatorsResponse>($"stock/[symbol]/indicator/{indicator}", symbol);
	}
}
