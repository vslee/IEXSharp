using VSLee.IEXSharp.Model.InvestorsExchangeData.Response;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using VSLee.IEXSharp.Model.Stock.Response;
using VSLee.IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using VSLee.IEXSharp.Model.StockPrices.Response;
using VSLee.IEXSharp.Model.StockPrices.Request;
using VSLee.IEXSharp.Model.StockProfiles.Response;
using VSLee.IEXSharp.Model.StockFundamentals.Response;
using VSLee.IEXSharp.Model.StockFundamentals.Request;
using VSLee.IEXSharp.Model.StockResearch.Response;

namespace VSLee.IEXSharp.Service.V1.Stock
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
		Task<IEXResponse<BatchBySymbolV1Response>> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#batch-requests"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <param name="types"></param>
		/// <param name="range"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, BatchBySymbolV1Response>>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#book"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<BookResponse>> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#chart"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <param name="qsb">Additional optional querystring</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ChartResponse>>> ChartAsync(string symbol, ChartRange range = ChartRange.OneMonth, DateTime? date = null, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#chart"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="qsb">Additional optional querystring</param>
		/// <returns></returns>
		Task<IEXResponse<ChartDynamicResponse>> ChartDynamicAsync(string symbol, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#collections"/>
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="collectionName"></param>
		Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection, string collectionName);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#company"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<CompanyResponse>> CompanyAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#crypto"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<Quote>>> CryptoAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#delayed-quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<DelayedQuoteResponse>> DelayedQuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#dividends"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<DividendV1Response>>> DividendAsync(string symbol, DividendRange range);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#earnings"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<EarningResponse>> EarningAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#earnings-today"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<EarningTodayResponse>> EarningTodayAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#effective-spread"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EffectiveSpreadResponse>>> EffectiveSpreadAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#financials"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <returns></returns>
		Task<IEXResponse<FinancialResponse>> FinancialAsync(string symbol, Period period = Period.Quarter);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#intraday-prices"/>
		/// </summary>
		/// <param name="ipoType"></param>
		/// <returns></returns>
		Task<IEXResponse<IPOCalendar>> IPOCalendarAsync(IPOType ipoType);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-regulation-sho-threshold-securities-list"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-short-interest-list"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ListedShortInterestListResponse>>> ListedShortInterestListAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#key-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<KeyStatsResponse>> KeyStatsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#largest-trades"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<LargestTradeResponse>>> LargestTradesAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#list"/>
		/// </summary>
		/// <param name="listType"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<Quote>>> ListAsync(string listType);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#logo"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<LogoResponse>> LogoAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#news"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<NewsV1Response>>> NewsAsync(string symbol, int last = 10);

		/// <summary>
		/// https://iextrading.com/developer/docs/#ohlc
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<OHLCResponse>> OHLCAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#peers"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<string>>> PeersAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#previous-day-price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<HistoricalPriceResponse>> PreviousDayPriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> PriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<Quote>> QuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#relevant"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<RelevantResponse>> RelevantAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#sector-performance"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#splits"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SplitV1Response>>> SplitAsync(string symbol, SplitRange range = SplitRange.OneMonth);


		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#volume-by-venue"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<VolumeByVenueResponse>> VolumeByVenueAsync(string symbol);
	}
}