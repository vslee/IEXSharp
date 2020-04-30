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
		/// <see cref="https://iexcloud.io/docs/api/#estimates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<EstimateResponse>> EstimateAsync(string symbol, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#estimates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> EstimateFieldAsync(string symbol, string field, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#fund-ownership"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<FundOwnershipResponse>>> FundOwnershipAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#institutional-ownership"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<InstitutionalOwnershipResponse>>> InstitutionalOwnerShipAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#intraday-prices"/>
		/// </summary>
		/// <param name="ipoType"></param>
		/// <returns></returns>
		Task<IEXResponse<IPOCalendar>> IPOCalendarAsync(IPOType ipoType);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#key-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<KeyStatsResponse>> KeyStatsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#key-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="stat"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> KeyStatsStatAsync(string symbol, string stat);

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
		/// <see cref="https://iexcloud.io/docs/api/#price-target"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<PriceTargetResponse>> PriceTargetAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#technical-indicators"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="indicator"></param>
		/// <returns></returns>
		Task<IEXResponse<TechnicalIndicatorsResponse>> TechnicalIndicatorsAsync(string symbol, string indicator);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#advanced-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<AdvancedStatsResponse>> AdvancedStatsAsync(string symbol);

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