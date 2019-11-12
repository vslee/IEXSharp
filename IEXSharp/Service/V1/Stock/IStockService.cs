using IEXSharp.Model.InvestorsExchangeData.Response;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model.Stock.Request;
using IEXSharp.Model.Stock.Response;
using IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEXSharp.Service.V1.Stock
{
    public interface IStockService
    {
        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#batch-requests"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="types"></param>
        /// <param name="range"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        Task<BatchBySymbolV1Response> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#batch-requests"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="types"></param>
        /// <param name="range"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        Task<Dictionary<string, BatchBySymbolV1Response>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#book"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<BookResponse> BookAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#chart"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="range"></param>
        /// <param name="qsb">Additional optional querystring</param>
        /// <returns></returns>
        Task<IEnumerable<ChartResponse>> ChartAsync(string symbol, ChartRange range = ChartRange._1m, DateTime? date = null, QueryStringBuilder qsb = null);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#chart"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="qsb">Additional optional querystring</param>
        /// <returns></returns>
        Task<ChartDynamicResponse> ChartDynamicAsync(string symbol, QueryStringBuilder qsb = null);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#collections"/>
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="collectionName"></param>
        Task<IEnumerable<Quote>> CollectionsAsync(CollectionType collection, string collectionName);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#company"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<CompanyResponse> CompanyAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#crypto"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Quote>> CryptoAsync();
        
        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#delayed-quote"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<DelayedQuoteResponse> DelayedQuoteAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#dividends"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        Task<IEnumerable<DividendV1Response>> DividendAsync(string symbol, DividendRange range);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#earnings"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<EarningResponse> EarningAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#earnings-today"/>
        /// </summary>
        /// <returns></returns>
        Task<EarningTodayResponse> EarningTodayAsync();

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#effective-spread"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<IEnumerable<EffectiveSpreadResponse>> EffectiveSpreadAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#financials"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        Task<FinancialResponse> FinancialAsync(string symbol, Period period = Period.Quarter);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#intraday-prices"/>
        /// </summary>
        /// <param name="ipoType"></param>
        /// <returns></returns>
        Task<IPOCalendar> IPOCalendarAsync(IPOType ipoType);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#iex-regulation-sho-threshold-securities-list"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#iex-short-interest-list"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<IEnumerable<ListedShortInterestListResponse>> ListedShortInterestListAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#key-stats"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<KeyStatsResponse> KeyStatsAsync(string symbol);
        
        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#largest-trades"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<IEnumerable<LargestTradeResponse>> LargestTradesAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#list"/>
        /// </summary>
        /// <param name="listType"></param>
        /// <returns></returns>
        Task<IEnumerable<Quote>> ListAsync(string listType);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#logo"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<LogoResponse> LogoAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#news"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        Task<IEnumerable<NewsV1Response>> NewsAsync(string symbol, int last = 10);

        /// <summary>
        /// https://iextrading.com/developer/docs/#ohlc
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<OHLCResponse> OHLCAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#peers"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> PeersAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#previous-day-price"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<HistoricalPriceResponse> PreviousDayPriceAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#price"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<decimal> PriceAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#quote"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<Quote> QuoteAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#relevant"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<RelevantResponse> RelevantAsync(string symbol);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#sector-performance"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SectorPerformanceResponse>> SectorPerformanceAsync();

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#splits"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        Task<IEnumerable<SplitV1Response>> SplitAsync(string symbol, SplitRange range = SplitRange._1m);


        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#volume-by-venue"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<VolumeByVenueResponse> VolumeByVenueAsync(string symbol);
    }
}