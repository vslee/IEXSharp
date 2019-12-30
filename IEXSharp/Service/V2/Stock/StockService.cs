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
		private readonly string pk;
		private readonly ExecutorREST executor;

		public StockService(HttpClient client, string sk, string pk, bool sign)
		{
			this.pk = pk;
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/balance-sheet/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"last", last.ToString()}
			};

			return await executor.ExecuteAsyncLegacy<BalanceSheetResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<string> BalanceSheetFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/balance-sheet/[last]/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsyncLegacy<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<BatchBySymbolResponse> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types,
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
			qsb.Add("token", pk);
			qsb.Add("types", string.Join(",", qsType));
			if (!string.IsNullOrWhiteSpace(range))
			{
				qsb.Add("range", range);
			}

			qsb.Add("last", last);

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await executor.ExecuteAsyncLegacy<BatchBySymbolResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<Dictionary<string, BatchBySymbolResponse>> BatchByMarketAsync(IEnumerable<string> symbols,
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
			qsb.Add("token", pk);
			qsb.Add("symbols", string.Join(",", symbols));
			qsb.Add("types", string.Join(",", qsType));
			if (!string.IsNullOrWhiteSpace(range))
			{
				qsb.Add("range", range);
			}

			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsyncLegacy<Dictionary<string, BatchBySymbolResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<BookResponse> BookAsync(string symbol) =>
			await executor.SymbolExecuteAsync<BookResponse>("stock/[symbol]/book", symbol, pk);

		public async Task<CashFlowResponse> CashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1)
		{
			const string urlPattern = "stock/[symbol]/cash-flow/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await executor.ExecuteAsyncLegacy<CashFlowResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<string> CashFlowFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/cash-flow/[last]/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);
			qsb.Add("period", period.ToString().ToLower());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsyncLegacy<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<Quote>> CollectionsAsync(CollectionType collection, string collectionName)
		{
			const string urlPattern = "stock/market/collection/[collectionType]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "collectionType", collection.ToString().ToLower() } };

			return await executor.ExecuteAsyncLegacy<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<CompanyResponse> CompanyAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CompanyResponse>("stock/[symbol]/company", symbol, pk);

		public async Task<DelayedQuoteResponse> DelayedQuoteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<DelayedQuoteResponse>("stock/[symbol]/delayed-quote", symbol, pk);

		public async Task<IEnumerable<DividendResponse>> DividendAsync(string symbol, DividendRange range)
		{
			const string urlPattern = "stock/[symbol]/dividends/[range]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}, {"range", range.ToString().ToLower().Replace("_", string.Empty)}
			};

			return await executor.ExecuteAsyncLegacy<IEnumerable<DividendResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<EarningResponse> EarningAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<EarningResponse>("stock/[symbol]/earnings/[last]", symbol, last,
				pk);

		public async Task<string> EarningFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/earnings/[last]/[field]", symbol, field, last,
				pk);

		public async Task<EarningTodayResponse> EarningTodayAsync() =>
			await executor.NoParamExecute<EarningTodayResponse>("stock/market/today-earnings",
				pk);

		public async Task<IEnumerable<EffectiveSpreadResponse>> EffectiveSpreadAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<EffectiveSpreadResponse>>("stock/[symbol]/effective-spread",
				symbol, pk);

		public async Task<EstimateResponse> EstimateAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<EstimateResponse>("stock/[symbol]/estimates/[last]", symbol, last,
				pk);

		public async Task<string> EstimateFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/estimates/[last]/[field]", symbol, field, last,
				pk);

		public async Task<FinancialResponse> FinancialAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<FinancialResponse>("stock/[symbol]/financials/[last]", symbol, last,
				pk);

		public async Task<string> FinancialFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/financials/[last]/[field]", symbol, field, last,
				pk);

		public async Task<FundOwnershipResponse> FundOwnershipAsync(string symbol) =>
			await executor.SymbolExecuteAsync<FundOwnershipResponse>("stock/[symbol]/fund-ownership", symbol, pk);

		public async Task<IEXResponse<IEnumerable<HistoricalPriceResponse>>> HistoricalPriceAsync(string symbol,
			ChartRange range = ChartRange._1m, QueryStringBuilder qsb = null)
		{
			const string urlPattern = "stock/[symbol]/chart/[range]";

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"range", range.ToString().Replace("_", string.Empty)},
			};

			return await executor.ExecuteAsync<IEnumerable<HistoricalPriceResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<HistoricalPriceResponse>> HistoricalPriceByDateAsync(string symbol,
			DateTime date, bool chartByDay, QueryStringBuilder qsb = null)
		{
			const string urlPattern = "stock/[symbol]/chart/date/[date]";

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"date", date == null ? DateTime.Now.ToString("yyyyMMdd") : date.ToString("yyyyMMdd")}
			};

			qsb = qsb ?? new QueryStringBuilder();
			if (chartByDay)
				qsb.Add("chartByDay", "true");
			qsb.Add("token", pk);

			return await executor.ExecuteAsyncLegacy<IEnumerable<HistoricalPriceResponse>>(urlPattern, pathNvc, qsb: qsb);
		}

		public async Task<HistoricalPriceDynamicResponse> HistoricalPriceDynamicAsync(string symbol,
			QueryStringBuilder qsb = null)
		{
			const string urlPattern = "stock/[symbol]/chart/dynamic";

			qsb = qsb ?? new QueryStringBuilder();
			if (qsb.Exist("token"))
			{
				qsb.Add("token", pk);
			}

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}
			};

			return await executor.ExecuteAsyncLegacy<HistoricalPriceDynamicResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IncomeStatementResponse> IncomeStatementAsync(string symbol, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/income/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await executor.ExecuteAsyncLegacy<IncomeStatementResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<string> IncomeStatementFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/income/[last]/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsyncLegacy<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<InsiderRosterResponse>> InsiderRosterAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderRosterResponse>>("stock/[symbol]/insider-roster",
				symbol, pk);

		public async Task<IEnumerable<InsiderSummaryResponse>> InsiderSummaryAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderSummaryResponse>>("stock/[symbol]/insider-summary",
				symbol, pk);

		public async Task<IEnumerable<InsiderTransactionResponse>> InsiderTransactionAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<InsiderTransactionResponse>>(
				"stock/[symbol]/insider-transactions", symbol, pk);

		public async Task<IEnumerable<InstitutionalOwnershipResponse>> InstitutionalOwnerShipAsync(string symbol) => await executor.SymbolExecuteAsync<IEnumerable<InstitutionalOwnershipResponse>>("stock/[symbol]/institutional-ownership", symbol, pk);

		public async Task<IEnumerable<IntradayPriceResponse>> IntradayPriceAsync(string symbol) => await executor.SymbolExecuteAsync<IEnumerable<IntradayPriceResponse>>("stock/[symbol]/intraday-prices", symbol, pk);

		public async Task<IPOCalendar> IPOCalendarAsync(IPOType ipoType)
		{
			const string urlPattern = "stock/market/[ipoType]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "ipoType", $"{ipoType.ToString().ToLower()}-ipos" } };

			return await executor.ExecuteAsyncLegacy<IPOCalendar>(urlPattern, pathNvc, qsb);
		}

		public async Task<KeyStatsResponse> KeyStatsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<KeyStatsResponse>("stock/[symbol]/stats", symbol, pk);

		public async Task<KeyStatsResponse> KeyStatsStatAsync(string symbol, string stat)
		{
			const string urlPattern = "stock/[symbol]/stats/[stat]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "stat", stat } };

			return await executor.ExecuteAsyncLegacy<KeyStatsResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<LargestTradeResponse>> LargestTradesAsync(string symbol) => await executor.SymbolExecuteAsync<IEnumerable<LargestTradeResponse>>("stock/[symbol]/largest-trades", symbol, pk);

		public async Task<IEnumerable<Quote>> ListAsync(string listType)
		{
			const string urlPattern = "stock/market/list/[list-type]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "list-type", listType } };

			return await executor.ExecuteAsyncLegacy<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<LogoResponse> LogoAsync(string symbol) => await executor.SymbolExecuteAsync<LogoResponse>("stock/[symbol]/logo", symbol, pk);

		public async Task<IEnumerable<USMarketVolumeResponse>> USMarketVolumeAsync() =>
			await executor.NoParamExecute<IEnumerable<USMarketVolumeResponse>>("market", pk);

		public async Task<IEnumerable<NewsResponse>> NewsAsync(string symbol, int last = 10) => await executor.SymbolLastExecuteAsync<IEnumerable<NewsResponse>>("stock/[symbol]/news/last/[last]", symbol, last, pk);

		public async Task<OHLCResponse> OHLCAsync(string symbol) => await executor.SymbolExecuteAsync<OHLCResponse>("stock/[symbol]/ohlc", symbol, pk);

		public async Task<IEnumerable<string>> PeersAsync(string symbol) => await executor.SymbolExecuteAsync<IEnumerable<string>>("stock/[symbol]/peers", symbol, pk);

		public async Task<HistoricalPriceResponse> PreviousDayPriceAsync(string symbol) => await executor.SymbolExecuteAsync<HistoricalPriceResponse>("stock/[symbol]/previous", symbol, pk);

		public async Task<decimal> PriceAsync(string symbol)
		{
			var returnValue = await executor.SymbolExecuteAsync<string>("stock/[symbol]/price", symbol, pk);
			return decimal.Parse(returnValue);
		}

		public async Task<PriceTargetResponse> PriceTargetAsync(string symbol) => await executor.SymbolExecuteAsync<PriceTargetResponse>("stock/[symbol]/price-target", symbol, pk);

		public async Task<Quote> QuoteAsync(string symbol) => await executor.SymbolExecuteAsync<Quote>("stock/[symbol]/quote", symbol, pk);

		public async Task<string> QuoteFieldAsync(string symbol, string field)
		{
			const string urlPattern = "stock/[symbol]/quote/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "field", field } };

			return await executor.ExecuteAsyncLegacy<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<RecommendationTrendResponse>> RecommendationTrendAsync(string symbol) => await executor.SymbolExecuteAsync<IEnumerable<RecommendationTrendResponse>>("stock/[symbol]/recommendation-trends", symbol, pk);

		public async Task<IEnumerable<SectorPerformanceResponse>> SectorPerformanceAsync() =>
			await executor.NoParamExecute<IEnumerable<SectorPerformanceResponse>>("stock/market/sector-performance", pk);

		public async Task<IEnumerable<SplitResponse>> SplitAsync(string symbol, SplitRange range = SplitRange._1m)
		{
			const string urlPattern = "stock/[symbol]/splits/[range]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "range", range.ToString().Replace("_", string.Empty) } };

			return await executor.ExecuteAsyncLegacy<IEnumerable<SplitResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<UpcomingEventSymbolResponse> UpcomingEventSymbolAsync(string symbol, UpcomingEventType type)
		{
			const string urlPattern = "stock/[symbol]/upcoming-[type]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "type", type.ToString().ToLower() } };

			return await executor.ExecuteAsyncLegacy<UpcomingEventSymbolResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<UpcomingEventMarketResponse> UpcomingEventMarketAsync(UpcomingEventType type)
		{
			const string urlPattern = "stock/market/upcoming-[type]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", pk);

			var pathNvc = new NameValueCollection { { "type", type.ToString().ToLower() } };

			return await executor.ExecuteAsyncLegacy<UpcomingEventMarketResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<VolumeByVenueResponse> VolumeByVenueAsync(string symbol) => await executor.SymbolExecuteAsync<VolumeByVenueResponse>("stock/[symbol]/delayed-quote", symbol, pk);
	}
}