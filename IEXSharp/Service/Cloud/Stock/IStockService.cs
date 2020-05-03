using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using VSLee.IEXSharp.Model.Stock.Response;
using VSLee.IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.Cloud.Stock
{
	public interface IStockService
	{

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="types"></param>
		/// <param name="range"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<BatchResponse>> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <param name="types"></param>
		/// <param name="range"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, BatchResponse>>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#collections"/>
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="collectionName"></param>
		Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection, string collectionName);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#effective-spread"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EffectiveSpreadResponse>>> EffectiveSpreadAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#intraday-prices"/>
		/// </summary>
		/// <param name="ipoType"></param>
		/// <returns></returns>
		Task<IEXResponse<IPOCalendar>> IPOCalendarAsync(IPOType ipoType);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#list"/>
		/// </summary>
		/// <param name="listType"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<Quote>>> ListAsync(string listType);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#market-volume-u-s"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketVolumeUSAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#news"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<NewsResponse>>> NewsAsync(string symbol, int last = 10);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#recommendation-trends"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<RecommendationTrendResponse>>> RecommendationTrendAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#sector-performance"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		Task<IEXResponse<UpcomingEventSymbolResponse>> UpcomingEventSymbolAsync(string symbol, UpcomingEventType type);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		Task<IEXResponse<UpcomingEventMarketResponse>> UpcomingEventMarketAsync(UpcomingEventType type);
	}
}