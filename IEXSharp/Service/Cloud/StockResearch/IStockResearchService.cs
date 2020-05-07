using IEXSharp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.StockResearch.Response;

namespace IEXSharp.Service.Cloud.StockResearch
{
	public interface IStockResearchService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#advanced-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<AdvancedStatsResponse>> AdvancedStatsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#analyst-recommendations"/>
		/// (previously called Recommendation Trends, but renamed by IEX. Endpoint URL is still the same though.
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<AnalystRecommendationsResponse>>> AnalystRecommendationsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#estimates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<EstimatesResponse>> EstimatesAsync(string symbol, int last = 1);

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
	}
}
