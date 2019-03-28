using IEX.V2.Model.Shared.Response;
using IEX.V2.Model.Stock.Request;
using IEX.V2.Model.Stock.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEX.V2.Service.Stock
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
        Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period, int last = 1);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="field"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        Task<string> BalanceSheetFieldAsync(string symbol, Period period, string field, int last = 1);

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
        Task<CashFlowResponse> CashFlowAsync(string symbol, Period period, int last = 1);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="field"></param>
        /// <param name="last"></param>
        Task<string> CashFlowFieldAsync(string symbol, Period period, string field, int last = 1);

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
        Task<Dictionary<string, EarningTodayResponse>> EarningTodayAsync();

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
    }
}