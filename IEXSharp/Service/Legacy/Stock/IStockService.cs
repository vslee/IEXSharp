using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.Batch.Request;
using IEXSharp.Model.CoreData.Batch.Response;
using IEXSharp.Model.CoreData.MarketInfo.Request;
using IEXSharp.Model.CoreData.MarketInfo.Response;
using IEXSharp.Model.CoreData.Stock.Response;
using IEXSharp.Model.CoreData.StockPrices.Response;
using IEXSharp.Model.CoreData.StockProfiles.Response;

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
	}
}