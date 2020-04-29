using IEXSharp.Model;
using IEXSharp.Model.CoprorateActions.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.CoprorateActions.Request;

namespace IEXSharp.Service.V2.CorporateActions
{
	public interface ICorporateActionsService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#dividends"/>
		/// Advanced dividends (as opposed to the basic dividends in IStockService)
		/// </summary>
		/// <param name="symbol">Optional. Symbol name.</param>
		/// <param name="range">range enum</param>
		/// <param name="calendar">true or false (defaults to false)</param>
		/// <param name="last">last number of dividends, default is null</param>
		/// <param name="refid">Optional. Id that matches the refid field returned in the response object. This allows you to pull a specific dividend for a symbol.</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<AdvancedDividendResponse>>> DividendsAsync(
			string symbol, TimeSeriesRange range, bool calendar = false, int? last = null, string refid = null);

		/// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#bonus-issue"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="refId"></param>
        /// <returns></returns>
        Task<IEXResponse<IEnumerable<PlaceholderResponse>>> BonusIssueAsync(
			string symbol, TimeSeriesRange range = TimeSeriesRange.ThisQuarter, bool calendar = false, int? last = null, string refId = null
        );

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#distribution"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<PlaceholderResponse>> DistributionAsync(string symbol, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#return-of-capital"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<PlaceholderResponse>> ReturnOfCapitalAsync(string symbol, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#rights-issue"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<PlaceholderResponse>> RightsIssueAsync(string symbol, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#right-to-purchase"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<PlaceholderResponse>> RightToPurchaseAsync(string symbol, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#security-reclassification"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<PlaceholderResponse>> SecurityReclassificationAsync(string symbol, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#security-swap"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<PlaceholderResponse>> SecuritySwapAsync(string symbol, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#spinoff"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<PlaceholderResponse>> SpinOffAsync(string symbol, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#splits"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<PlaceholderResponse>> SplitsAsync(string symbol, string refId);
	}
}
