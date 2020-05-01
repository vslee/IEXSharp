using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.InvestorsExchangeData.Response;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using VSLee.IEXSharp.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using VSLee.IEXSharp.Model.StockPrices.Response;
using VSLee.IEXSharp.Model.StockPrices.Request;
using VSLee.IEXSharp.Model.StockProfiles.Response;
using VSLee.IEXSharp.Model.StockFundamentals.Response;
using VSLee.IEXSharp.Model.StockFundamentals.Request;
using VSLee.IEXSharp.Model.StockResearch.Response;

namespace VSLee.IEXSharp.Service.V1.Stock
{
	internal class StockService : IStockService
	{
		private readonly ExecutorREST _executor;

		public StockService(HttpClient client)
		{
			_executor = new ExecutorREST(client, string.Empty, string.Empty, false);
		}

		public async Task<IEXResponse<BatchBySymbolV1Response>> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types,
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

			return await _executor.ExecuteAsync<BatchBySymbolV1Response>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<Dictionary<string, BatchBySymbolV1Response>>> BatchByMarketAsync(IEnumerable<string> symbols,
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

			return await _executor.ExecuteAsync<Dictionary<string, BatchBySymbolV1Response>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<BookResponse>> BookAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<BookResponse>("stock/[symbol]/book", symbol);

		public async Task<IEXResponse<IEnumerable<ChartResponse>>> ChartAsync(string symbol,
			ChartRange range = ChartRange.OneMonth, DateTime? date = null, QueryStringBuilder qsb = null)
		{
			const string urlPattern = "stock/[symbol]/chart/[range]/[date]";

			qsb = qsb ?? new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"range", range.GetDescription()},
				{"date", date == null ? DateTime.Now.ToString("yyyyMMdd") : ((DateTime) date).ToString("yyyyMMdd")}
			};

			return await _executor.ExecuteAsync<IEnumerable<ChartResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<ChartDynamicResponse>> ChartDynamicAsync(string symbol,
			QueryStringBuilder qsb = null)
		{
			const string urlPattern = "stock/[symbol]/chart/dynamic";

			qsb = qsb ?? new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}
			};

			return await _executor.ExecuteAsync<ChartDynamicResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection, string collectionName)
		{
			const string urlPattern = "stock/market/collection/[collectionType]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "collectionType", collection.GetDescription() } };

			return await _executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<CompanyResponse>> CompanyAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<CompanyResponse>("stock/[symbol]/company", symbol);

		public async Task<IEXResponse<IEnumerable<Quote>>> CryptoAsync() =>
			await _executor.NoParamExecute<IEnumerable<Quote>>("crypto/market/quote");

		public async Task<IEXResponse<DelayedQuoteResponse>> DelayedQuoteAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<DelayedQuoteResponse>("stock/[symbol]/delayed-quote", symbol);

		public async Task<IEXResponse<IEnumerable<DividendV1Response>>> DividendAsync(string symbol, DividendRange range)
		{
			const string urlPattern = "stock/[symbol]/dividends/[range]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}, {"range", range.GetDescription()}
			};

			return await _executor.ExecuteAsync<IEnumerable<DividendV1Response>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<EarningResponse>> EarningAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<EarningResponse>("stock/[symbol]/earnings", symbol);

		public async Task<IEXResponse<EarningTodayResponse>> EarningTodayAsync() =>
			await _executor.NoParamExecute<EarningTodayResponse>("stock/market/today-earnings");

		public async Task<IEXResponse<IEnumerable<EffectiveSpreadResponse>>> EffectiveSpreadAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<IEnumerable<EffectiveSpreadResponse>>(
				"stock/[symbol]/effective-spread", symbol);

		public async Task<IEXResponse<FinancialResponse>> FinancialAsync(string symbol, Period period = Period.Quarter)
		{
			const string urlPattern = "stock/[symbol]/financials";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescription());

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}
			};

			return await _executor.ExecuteAsync<FinancialResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IPOCalendar>> IPOCalendarAsync(IPOType ipoType)
		{
			const string urlPattern = "stock/market/[ipoType]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "ipoType", ipoType.GetDescription() } };

			return await _executor.ExecuteAsync<IPOCalendar>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol)
			=> await _executor.SymbolExecuteAsync<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>(
				"stock/[symbol]/threshold-securities", symbol);

		public async Task<IEXResponse<IEnumerable<ListedShortInterestListResponse>>> ListedShortInterestListAsync(string symbol)
			=> await _executor.SymbolExecuteAsync<IEnumerable<ListedShortInterestListResponse>>(
				"stock/[symbol]/short-interest", symbol);

		public async Task<IEXResponse<KeyStatsResponse>> KeyStatsAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<KeyStatsResponse>("stock/[symbol]/stats", symbol);

		public async Task<IEXResponse<IEnumerable<LargestTradeResponse>>> LargestTradesAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<IEnumerable<LargestTradeResponse>>("stock/[symbol]/largest-trades", symbol);

		public async Task<IEXResponse<IEnumerable<Quote>>> ListAsync(string listType)
		{
			const string urlPattern = "stock/market/list/[list-type]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "list-type", listType } };

			return await _executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<LogoResponse>> LogoAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<LogoResponse>("stock/[symbol]/logo", symbol);

		public async Task<IEXResponse<IEnumerable<NewsV1Response>>> NewsAsync(string symbol, int last = 10) =>
			await _executor.SymbolLastExecuteAsync<IEnumerable<NewsV1Response>>("stock/[symbol]/news/last/[last]", symbol, last);

		public async Task<IEXResponse<OHLCResponse>> OHLCAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<OHLCResponse>("stock/[symbol]/ohlc", symbol);

		public async Task<IEXResponse<IEnumerable<string>>> PeersAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<IEnumerable<string>>("stock/[symbol]/peers", symbol);

		public async Task<IEXResponse<HistoricalPriceResponse>> PreviousDayPriceAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<HistoricalPriceResponse>("stock/[symbol]/previous", symbol);

		public async Task<IEXResponse<decimal>> PriceAsync(string symbol)
		{
			var returnValue = await _executor.SymbolExecuteAsync<string>("stock/[symbol]/price", symbol);
			if (returnValue.ErrorMessage != null)
				return new IEXResponse<decimal>() { ErrorMessage = returnValue.ErrorMessage };
			else
				return new IEXResponse<decimal>() { Data = decimal.Parse(returnValue.Data) };
		}

		public async Task<IEXResponse<Quote>> QuoteAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<Quote>("stock/[symbol]/quote", symbol);

		public async Task<IEXResponse<RelevantResponse>> RelevantAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<RelevantResponse>("stock/[symbol]/relevant", symbol);

		public async Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync() =>
			await _executor.NoParamExecute<IEnumerable<SectorPerformanceResponse>>("stock/market/sector-performance");

		public async Task<IEXResponse<IEnumerable<SplitV1Response>>> SplitAsync(string symbol, SplitRange range = SplitRange.OneMonth)
		{
			const string urlPattern = "stock/[symbol]/splits/[range]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "range", range.GetDescription() } };

			return await _executor.ExecuteAsync<IEnumerable<SplitV1Response>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<VolumeByVenueResponse>> VolumeByVenueAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<VolumeByVenueResponse>("stock/[symbol]/delayed-quote", symbol);
	}
}