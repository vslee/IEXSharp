using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using VSLee.IEXSharp.Model.Stock.Response;
using VSLee.IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.V2.Stock
{
	public interface IStockService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<string> BalanceSheetFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="types"></param>
		/// <param name="range"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<BatchBySymbolResponse> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <param name="types"></param>
		/// <param name="range"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<Dictionary<string, BatchBySymbolResponse>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#book"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<BookResponse> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		Task<CashFlowResponse> CashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		Task<string> CashFlowFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#collections"/>
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="collectionName"></param>
		Task<IEnumerable<Quote>> CollectionsAsync(CollectionType collection, string collectionName);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#company"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<CompanyResponse> CompanyAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#delayed-quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<DelayedQuoteResponse> DelayedQuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#dividends"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEnumerable<DividendResponse>> DividendAsync(string symbol, DividendRange range);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<EarningResponse> EarningAsync(string symbol, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<string> EarningFieldAsync(string symbol, string field, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings-today"/>
		/// </summary>
		/// <returns></returns>
		Task<EarningTodayResponse> EarningTodayAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#effective-spread"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<EffectiveSpreadResponse>> EffectiveSpreadAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#estimates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<EstimateResponse> EstimateAsync(string symbol, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#estimates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<string> EstimateFieldAsync(string symbol, string field, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#financials"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<FinancialResponse> FinancialAsync(string symbol, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#financials"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<string> FinancialFieldAsync(string symbol, string field, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#fund-ownership"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<FundOwnershipResponse> FundOwnershipAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<HistoricalPriceResponse>>> HistoricalPriceAsync(string symbol, ChartRange range = ChartRange._1m, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="date"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<IEnumerable<HistoricalPriceResponse>> HistoricalPriceByDateAsync(string symbol, DateTime date, bool chartByDay, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<HistoricalPriceDynamicResponse> HistoricalPriceDynamicAsync(string symbol, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#income-statement"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IncomeStatementResponse> IncomeStatementAsync(string symbol, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#income-statement"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<string> IncomeStatementFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#insider-roster"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<InsiderRosterResponse>> InsiderRosterAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#insider-summary"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<InsiderSummaryResponse>> InsiderSummaryAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#insider-transactions"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<InsiderTransactionResponse>> InsiderTransactionAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#institutional-ownership"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<InstitutionalOwnershipResponse>> InstitutionalOwnerShipAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#institutional-ownership"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<IntradayPriceResponse>> IntradayPriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#intraday-prices"/>
		/// </summary>
		/// <param name="ipoType"></param>
		/// <returns></returns>
		Task<IPOCalendar> IPOCalendarAsync(IPOType ipoType);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#key-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<KeyStatsResponse> KeyStatsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#key-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="stat"></param>
		/// <returns></returns>
		Task<KeyStatsResponse> KeyStatsStatAsync(string symbol, string stat);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#largest-trades"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<LargestTradeResponse>> LargestTradesAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#list"/>
		/// </summary>
		/// <param name="listType"></param>
		/// <returns></returns>
		Task<IEnumerable<Quote>> ListAsync(string listType);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#logo"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<LogoResponse> LogoAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#market-volume-u-s"/>
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<USMarketVolumeResponse>> USMarketVolumeAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#news"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEnumerable<NewsResponse>> NewsAsync(string symbol, int last = 10);

		/// <summary>
		/// https://iexcloud.io/docs/api/#ohlc
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<OHLCResponse> OHLCAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#peers"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<string>> PeersAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#previous-day-price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<HistoricalPriceResponse> PreviousDayPriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<decimal> PriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#price-target"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<PriceTargetResponse> PriceTargetAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<Quote> QuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		Task<string> QuoteFieldAsync(string symbol, string field);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#recommendation-trends"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEnumerable<RecommendationTrendResponse>> RecommendationTrendAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#sector-performance"/>
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SectorPerformanceResponse>> SectorPerformanceAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#splits"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEnumerable<SplitResponse>> SplitAsync(string symbol, SplitRange range = SplitRange._1m);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		Task<UpcomingEventSymbolResponse> UpcomingEventSymbolAsync(string symbol, UpcomingEventType type);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		Task<UpcomingEventMarketResponse> UpcomingEventMarketAsync(UpcomingEventType type);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#volume-by-venue"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<VolumeByVenueResponse> VolumeByVenueAsync(string symbol);
	}
}