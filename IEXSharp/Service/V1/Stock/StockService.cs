using IEXSharp.Helper;
using IEXSharp.Model.InvestorsExchangeData.Response;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model.Stock.Request;
using IEXSharp.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.V1.Stock
{
	internal class StockService : IStockService
    {
        private readonly Executor _executor;

        public StockService(HttpClient client)
        {
            _executor = new Executor(client, string.Empty, string.Empty, false);
        }

        public async Task<BatchBySymbolV1Response> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types,
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

        public async Task<Dictionary<string, BatchBySymbolV1Response>> BatchByMarketAsync(IEnumerable<string> symbols,
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

        public async Task<BookResponse> BookAsync(string symbol) =>
            await _executor.SymbolExecuteAsync<BookResponse>("stock/[symbol]/book", symbol, "");

        public async Task<IEnumerable<ChartResponse>> ChartAsync(string symbol,
            ChartRange range = ChartRange._1m, DateTime? date = null, QueryStringBuilder qsb = null)
        {
            const string urlPattern = "stock/[symbol]/chart/[range]/[date]";

            qsb = qsb ?? new QueryStringBuilder();

            var pathNvc = new NameValueCollection
            {
                {"symbol", symbol},
                {"range", range.ToString().Replace("_", string.Empty)},
                {"date", date == null ? DateTime.Now.ToString("yyyyMMdd") : ((DateTime) date).ToString("yyyyMMdd")}
            };

            return await _executor.ExecuteAsync<IEnumerable<ChartResponse>>(urlPattern, pathNvc, qsb);
        }

        public async Task<ChartDynamicResponse> ChartDynamicAsync(string symbol,
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

        public async Task<IEnumerable<Quote>> CollectionsAsync(CollectionType collection, string collectionName)
        {
            const string urlPattern = "stock/market/collection/[collectionType]";

            var qsb = new QueryStringBuilder();

            var pathNvc = new NameValueCollection { { "collectionType", collection.ToString().ToLower() } };

            return await _executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
        }

        public async Task<CompanyResponse> CompanyAsync(string symbol) =>
            await _executor.SymbolExecuteAsync<CompanyResponse>("stock/[symbol]/company", symbol, "");

        public async Task<IEnumerable<Quote>> CryptoAsync() => await _executor.NoParamExecute<IEnumerable<Quote>>("crypto/market/quote", "");

        public async Task<DelayedQuoteResponse> DelayedQuoteAsync(string symbol) =>
            await _executor.SymbolExecuteAsync<DelayedQuoteResponse>("stock/[symbol]/delayed-quote", symbol, "");

        public async Task<IEnumerable<DividendV1Response>> DividendAsync(string symbol, DividendRange range)
        {
            const string urlPattern = "stock/[symbol]/dividends/[range]";

            var qsb = new QueryStringBuilder();

            var pathNvc = new NameValueCollection
            {
                {"symbol", symbol}, {"range", range.ToString().ToLower().Replace("_", string.Empty)}
            };

            return await _executor.ExecuteAsync<IEnumerable<DividendV1Response>>(urlPattern, pathNvc, qsb);
        }

        public async Task<EarningResponse> EarningAsync(string symbol) =>
            await _executor.SymbolExecuteAsync<EarningResponse>("stock/[symbol]/earnings", symbol, "");

        public async Task<EarningTodayResponse> EarningTodayAsync() =>
            await _executor.NoParamExecute<EarningTodayResponse>("stock/market/today-earnings",
                "");

        public async Task<IEnumerable<EffectiveSpreadResponse>> EffectiveSpreadAsync(string symbol) =>
            await _executor.SymbolExecuteAsync<IEnumerable<EffectiveSpreadResponse>>("stock/[symbol]/effective-spread",
                symbol, "");

        public async Task<FinancialResponse> FinancialAsync(string symbol, Period period = Period.Quarter)
        {
            const string urlPattern = "stock/[symbol]/financials";

            var qsb = new QueryStringBuilder();
            qsb.Add("period", period.ToString().ToLower());

            var pathNvc = new NameValueCollection
            {
                {"symbol", symbol}
            };

            return await _executor.ExecuteAsync<FinancialResponse>(urlPattern, pathNvc, qsb);
        }

        public async Task<IPOCalendar> IPOCalendarAsync(IPOType ipoType)
        {
            const string urlPattern = "stock/market/[ipoType]";

            var qsb = new QueryStringBuilder();

            var pathNvc = new NameValueCollection { { "ipoType", $"{ipoType.ToString().ToLower()}-ipos" } };

            return await _executor.ExecuteAsync<IPOCalendar>(urlPattern, pathNvc, qsb);
        }

        public async Task<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol)
            => await _executor.SymbolExecuteAsync<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>("stock/[symbol]/threshold-securities", symbol, "");
        
        public async Task<IEnumerable<ListedShortInterestListResponse>> ListedShortInterestListAsync(string symbol)
            => await _executor.SymbolExecuteAsync<IEnumerable<ListedShortInterestListResponse>>("stock/[symbol]/short-interest", symbol, "");

        public async Task<KeyStatsResponse> KeyStatsAsync(string symbol) =>
            await _executor.SymbolExecuteAsync<KeyStatsResponse>("stock/[symbol]/stats", symbol, "");
        
        public async Task<IEnumerable<LargestTradeResponse>> LargestTradesAsync(string symbol) => await _executor.SymbolExecuteAsync<IEnumerable<LargestTradeResponse>>("stock/[symbol]/largest-trades", symbol, "");

        public async Task<IEnumerable<Quote>> ListAsync(string listType)
        {
            const string urlPattern = "stock/market/list/[list-type]";

            var qsb = new QueryStringBuilder();

            var pathNvc = new NameValueCollection { { "list-type", listType } };

            return await _executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
        }

        public async Task<LogoResponse> LogoAsync(string symbol) => await _executor.SymbolExecuteAsync<LogoResponse>("stock/[symbol]/logo", symbol, "");
        
        public async Task<IEnumerable<NewsV1Response>> NewsAsync(string symbol, int last = 10) => await _executor.SymbolLastExecuteAsync<IEnumerable<NewsV1Response>>("stock/[symbol]/news/last/[last]", symbol, last, "");

        public async Task<OHLCResponse> OHLCAsync(string symbol) => await _executor.SymbolExecuteAsync<OHLCResponse>("stock/[symbol]/ohlc", symbol, "");

        public async Task<IEnumerable<string>> PeersAsync(string symbol) => await _executor.SymbolExecuteAsync<IEnumerable<string>>("stock/[symbol]/peers", symbol, "");

        public async Task<HistoricalPriceResponse> PreviousDayPriceAsync(string symbol) => await _executor.SymbolExecuteAsync<HistoricalPriceResponse>("stock/[symbol]/previous", symbol, "");

        public async Task<decimal> PriceAsync(string symbol)
        {
            var returnValue = await _executor.SymbolExecuteAsync<string>("stock/[symbol]/price", symbol, "");
            return decimal.Parse(returnValue);
        }

        public async Task<Quote> QuoteAsync(string symbol) => await _executor.SymbolExecuteAsync<Quote>("stock/[symbol]/quote", symbol, "");

        public async Task<RelevantResponse> RelevantAsync(string symbol) => await _executor.SymbolExecuteAsync<RelevantResponse>("stock/[symbol]/relevant", symbol, "");

        public async Task<IEnumerable<SectorPerformanceResponse>> SectorPerformanceAsync() =>
            await _executor.NoParamExecute<IEnumerable<SectorPerformanceResponse>>("stock/market/sector-performance", "");

        public async Task<IEnumerable<SplitV1Response>> SplitAsync(string symbol, SplitRange range = SplitRange._1m)
        {
            const string urlPattern = "stock/[symbol]/splits/[range]";

            var qsb = new QueryStringBuilder();

            var pathNvc = new NameValueCollection { { "symbol", symbol }, { "range", range.ToString().Replace("_", string.Empty) } };

            return await _executor.ExecuteAsync<IEnumerable<SplitV1Response>>(urlPattern, pathNvc, qsb);
        }

        public async Task<VolumeByVenueResponse> VolumeByVenueAsync(string symbol) => await _executor.SymbolExecuteAsync<VolumeByVenueResponse>("stock/[symbol]/delayed-quote", symbol, "");
    }
}