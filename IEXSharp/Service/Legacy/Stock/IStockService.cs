using IEXSharp.Model.InvestorsExchangeData.Response;
using IEXSharp.Model.Stock.Request;
using IEXSharp.Model.Stock.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.StockPrices.Response;
using IEXSharp.Model.StockProfiles.Response;
using IEXSharp.Model.StockFundamentals.Response;
using IEXSharp.Model.StockFundamentals.Request;
using IEXSharp.Model.MarketInfo.Request;
using IEXSharp.Model.MarketInfo.Response;

namespace IEXSharp.Service.Legacy.Stock
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
		Task<IEXResponse<BatchBySymbolLegacyResponse>> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#book"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<BookResponse>> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#dividends"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<DividendV1Response>>> DividendAsync(string symbol, DividendRange range);

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
		/// <see cref="https://iextrading.com/developer/docs/#intraday-prices"/>
		/// </summary>
		/// <param name="ipoType"></param>
		/// <returns></returns>
		Task<IEXResponse<IPOCalendarResponse>> IPOCalendarAsync(IPOType ipoType);

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
		/// <see cref="https://iextrading.com/developer/docs/#logo"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<LogoResponse>> LogoAsync(string symbol);

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
		/// <see cref="https://iextrading.com/developer/docs/#sector-performance"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync();
	}
}