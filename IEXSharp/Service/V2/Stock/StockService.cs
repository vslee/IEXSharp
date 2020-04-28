using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using VSLee.IEXSharp.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.V2.Stock
{
	internal class StockService : IStockService
	{
		private readonly ExecutorREST executor;

		public StockService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<BalanceSheetResponse>> BalanceSheetAsync(string symbol, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/balance-sheet/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"last", last.ToString()}
			};

			return await executor.ExecuteAsync<BalanceSheetResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> BalanceSheetFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/balance-sheet/[last]/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<BatchResponse>>
			BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types,
			string range = "", int last = 1)
		{
			if (types?.Count() < 1)
			{
				throw new ArgumentNullException(nameof(types));
			}

			const string urlPattern = "stock/[symbol]/batch";

			var qsType = new List<string>();
			foreach (var x in types)
			{
				switch (x)
				{
					case BatchType.Quote:
						qsType.Add("quote");
						break;

					case BatchType.News:
						qsType.Add("news");
						break;

					case BatchType.Chart:
						qsType.Add("chart");
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(types));
				}
			}

			var qsb = new QueryStringBuilder();
			qsb.Add("types", string.Join(",", qsType));
			if (!string.IsNullOrWhiteSpace(range))
			{
				qsb.Add("range", range);
			}

			qsb.Add("last", last);

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await executor.ExecuteAsync<BatchResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<Dictionary<string, BatchResponse>>> BatchByMarketAsync(IEnumerable<string> symbols,
			IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			if (types?.Count() < 1)
			{
				throw new ArgumentNullException("batchTypes cannot be null");
			}
			else if (symbols?.Count() < 1)
			{
				throw new ArgumentNullException("symbols cannot be null");
			}

			const string urlPattern = "stock/market/batch";

			var qsType = new List<string>();
			foreach (var x in types)
			{
				switch (x)
				{
					case BatchType.Quote:
						qsType.Add("quote");
						break;

					case BatchType.News:
						qsType.Add("news");
						break;

					case BatchType.Chart:
						qsType.Add("chart");
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(types));
				}
			}

			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", string.Join(",", symbols));
			qsb.Add("types", string.Join(",", qsType));
			if (!string.IsNullOrWhiteSpace(range))
			{
				qsb.Add("range", range);
			}

			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<Dictionary<string, BatchResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<CashFlowResponse>> CashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1)
		{
			const string urlPattern = "stock/[symbol]/cash-flow/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await executor.ExecuteAsync<CashFlowResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> CashFlowFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/cash-flow/[last]/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection, string collectionName)
		{
			const string urlPattern = "stock/market/collection/[collectionType]";

			var qsb = new QueryStringBuilder();
			qsb.Add("collectionName", collectionName);

			var pathNvc = new NameValueCollection { { "collectionType", collection.ToString().ToLower() } };

			return await executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<CompanyResponse>> CompanyAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CompanyResponse>("stock/[symbol]/company", symbol);

		public async Task<IEXResponse<IEnumerable<DividendResponse>>> DividendAsync(string symbol, DividendRange range)
		{
			const string urlPattern = "stock/[symbol]/dividends/[range]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}, {"range", range.ToString().ToLower().Replace("_", string.Empty)}
			};

			return await executor.ExecuteAsync<IEnumerable<DividendResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<EarningResponse>> EarningAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<EarningResponse>("stock/[symbol]/earnings/[last]", symbol, last);

		public async Task<IEXResponse<string>> EarningFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/earnings/[last]/[field]", symbol, field, last);

		public async Task<IEXResponse<EarningTodayResponse>> EarningTodayAsync() =>
			await executor.NoParamExecute<EarningTodayResponse>("stock/market/today-earnings");

		public async Task<IEXResponse<IEnumerable<EffectiveSpreadResponse>>> EffectiveSpreadAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<EffectiveSpreadResponse>>(
				"stock/[symbol]/effective-spread", symbol);

		public async Task<IEXResponse<EstimateResponse>> EstimateAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<EstimateResponse>("stock/[symbol]/estimates/[last]", symbol, last);

		public async Task<IEXResponse<string>> EstimateFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/estimates/[last]/[field]", symbol, field, last);

		public async Task<IEXResponse<FinancialResponse>> FinancialAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<FinancialResponse>("stock/[symbol]/financials/[last]", symbol, last);

		public async Task<IEXResponse<string>> FinancialFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/financials/[last]/[field]", symbol, field, last);

		public async Task<IEXResponse<IEnumerable<FundOwnershipResponse>>> FundOwnershipAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<FundOwnershipResponse>>("stock/[symbol]/fund-ownership", symbol);

		public async Task<IEXResponse<IncomeStatementResponse>> IncomeStatementAsync(string symbol, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/income/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await executor.ExecuteAsync<IncomeStatementResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> IncomeStatementFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/income/[last]/[field]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<InsiderRosterResponse>>> InsiderRosterAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderRosterResponse>>("stock/[symbol]/insider-roster",
				symbol);

		public async Task<IEXResponse<IEnumerable<InsiderSummaryResponse>>> InsiderSummaryAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderSummaryResponse>>("stock/[symbol]/insider-summary",
				symbol);

		public async Task<IEXResponse<IEnumerable<InsiderTransactionResponse>>> InsiderTransactionAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderTransactionResponse>>(
				"stock/[symbol]/insider-transactions", symbol);

		public async Task<IEXResponse<IEnumerable<InstitutionalOwnershipResponse>>> InstitutionalOwnerShipAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InstitutionalOwnershipResponse>>(
				"stock/[symbol]/institutional-ownership", symbol);

		public async Task<IEXResponse<IPOCalendar>> IPOCalendarAsync(IPOType ipoType)
		{
			const string urlPattern = "stock/market/[ipoType]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "ipoType", $"{ipoType.ToString().ToLower()}-ipos" } };

			return await executor.ExecuteAsync<IPOCalendar>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<KeyStatsResponse>> KeyStatsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<KeyStatsResponse>("stock/[symbol]/stats", symbol);

		public async Task<IEXResponse<string>> KeyStatsStatAsync(string symbol, string stat)
		{
			const string urlPattern = "stock/[symbol]/stats/[stat]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "stat", stat } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<Quote>>> ListAsync(string listType)
		{
			const string urlPattern = "stock/market/list/[list-type]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "list-type", listType } };

			return await executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<LogoResponse>> LogoAsync(string symbol) =>
			await executor.SymbolExecuteAsync<LogoResponse>("stock/[symbol]/logo", symbol);

		public async Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketVolumeUSAsync() =>
			await executor.NoParamExecute<IEnumerable<MarketVolumeUSResponse>>("market");

		public async Task<IEXResponse<IEnumerable<NewsResponse>>> NewsAsync(string symbol, int last = 10) =>
			await executor.SymbolLastExecuteAsync<IEnumerable<NewsResponse>>("stock/[symbol]/news/last/[last]", symbol, last);

		public async Task<IEXResponse<IEnumerable<string>>> PeersAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<string>>("stock/[symbol]/peers", symbol);

		public async Task<IEXResponse<PriceTargetResponse>> PriceTargetAsync(string symbol) =>
			await executor.SymbolExecuteAsync<PriceTargetResponse>("stock/[symbol]/price-target", symbol);

		public async Task<IEXResponse<TechnicalIndicatorsResponse>> TechnicalIndicatorsAsync(string symbol, string indicator) =>
			await executor.SymbolExecuteAsync<TechnicalIndicatorsResponse>($"stock/[symbol]/indicator/{indicator}", symbol);

		public async Task<IEXResponse<AdvancedStatsResponse>> AdvancedStatsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<AdvancedStatsResponse>("stock/[symbol]/advanced-stats", symbol);

		public async Task<IEXResponse<IEnumerable<RecommendationTrendResponse>>> RecommendationTrendAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<RecommendationTrendResponse>>(
				"stock/[symbol]/recommendation-trends", symbol);

		public async Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync() =>
			await executor.NoParamExecute<IEnumerable<SectorPerformanceResponse>>("stock/market/sector-performance");

		public async Task<IEXResponse<IEnumerable<SplitResponse>>> SplitAsync(string symbol, SplitRange range = SplitRange._1m)
		{
			const string urlPattern = "stock/[symbol]/splits/[range]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "range", range.ToString().Replace("_", string.Empty) } };

			return await executor.ExecuteAsync<IEnumerable<SplitResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<UpcomingEventSymbolResponse>> UpcomingEventSymbolAsync(string symbol, UpcomingEventType type)
		{
			const string urlPattern = "stock/[symbol]/upcoming-[type]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "type", type.ToString().ToLower() } };

			return await executor.ExecuteAsync<UpcomingEventSymbolResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<UpcomingEventMarketResponse>> UpcomingEventMarketAsync(UpcomingEventType type)
		{
			const string urlPattern = "stock/market/upcoming-[type]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "type", type.ToString().ToLower() } };

			return await executor.ExecuteAsync<UpcomingEventMarketResponse>(urlPattern, pathNvc, qsb);
		}
	}
}