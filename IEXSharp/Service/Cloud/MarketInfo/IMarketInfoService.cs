using IEXSharp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.MarketInfo.Request;
using IEXSharp.Model.MarketInfo.Response;
using VSLee.IEXSharp.Model.MarketInfo.Request;
using VSLee.IEXSharp.Model.MarketInfo.Response;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.StockFundamentals.Response;

namespace IEXSharp.Service.Cloud.MarketInfo
{
	public interface IMarketInfoService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#collections"/>
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="collectionName"></param>
		Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection, string collectionName);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings-today"/>
		/// </summary>
		Task<IEXResponse<EarningTodayResponse>> EarningsTodayAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#intraday-prices"/>
		/// </summary>
		/// <param name="ipoType"></param>
		/// <returns></returns>
		Task<IEXResponse<IPOCalendarResponse>> IPOCalendarAsync(IPOType ipoType);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#list"/>
		/// </summary>
		/// <param name="listType"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<Quote>>> ListAsync(ListType listType);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#market-volume-u-s"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketVolumeUSAsync();

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
		Task<IEXResponse<IEnumerable<UpcomingEventMarketResponse>>> UpcomingEventMarketAsync(UpcomingEventType type);


		// TODO - Sha
		Task<IEXResponse<UpcomingEventMarketResponse>> UpcomingEventsAsync(string symbol);

		Task<IEXResponse<IEnumerable<UpcomingEarningsResponse>>> UpcomingEarningsAsync(string symbol);
	}
}
