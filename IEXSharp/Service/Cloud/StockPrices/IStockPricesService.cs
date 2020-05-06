using IEXSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model.StockPrices.Request;
using IEXSharp.Model.StockPrices.Response;

namespace IEXSharp.Service.Cloud.StockPrices
{
	public interface IStockPricesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#book"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<BookResponse>> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#delayed-quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<DelayedQuoteResponse>> DelayedQuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<HistoricalPriceResponse>>> HistoricalPriceAsync(string symbol, ChartRange range = ChartRange.OneMonth, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="date"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<HistoricalPriceResponse>>> HistoricalPriceByDateAsync(string symbol, DateTime date, bool chartByDay, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<IEXResponse<HistoricalPriceDynamicResponse>> HistoricalPriceDynamicAsync(string symbol, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#intraday-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IntradayPriceResponse>>> IntradayPricesAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#largest-trades"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<LargestTradeResponse>>> LargestTradesAsync(string symbol);

		/// <summary>
		/// https://iexcloud.io/docs/api/#ohlc
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<OHLCResponse>> OHLCAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#previous-day-price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<HistoricalPriceResponse>> PreviousDayPriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> PriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<Quote>> QuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> QuoteFieldAsync(string symbol, string field);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#volume-by-venue"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<VolumeByVenueResponse>>> VolumeByVenueAsync(string symbol);
	}
}
