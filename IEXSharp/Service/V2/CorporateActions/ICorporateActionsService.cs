using IEXSharp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.CorporateActions.Request;
using IEXSharp.Model.CorporateActions.Response;

namespace IEXSharp.Service.V2.CorporateActions
{
	public interface ICorporateActionsService
	{
		/// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#bonus-issue"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="refId"></param>
        /// <returns></returns>
        Task<IEXResponse<IEnumerable<BonusIssueResponse>>> BonusIssueAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#distribution"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<DistributionResponse>>> DistributionAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#dividends"/>
		/// Dividends (Advanced), as opposed to the Dividends (Basic) found in StockFundamentalsService
		/// </summary>
		/// <param name="symbol">Optional. Symbol name.</param>
		/// <param name="range">range enum</param>
		/// <param name="calendar">true or false (defaults to false)</param>
		/// <param name="last">last number of dividends, default is null</param>
		/// <param name="refId">Optional. Id that matches the refId field returned in the response object. This allows you to pull a specific dividend for a symbol.</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<AdvancedDividendResponse>>> DividendsAsync(
			string symbol, TimeSeriesRange range = TimeSeriesRange.ThisQuarter, bool calendar = false, int? last = null, string refId = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#return-of-capital"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ReturnOfCapitalResponse>>> ReturnOfCapitalAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#rights-issue"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<RightsIssueResponse>>> RightsIssueAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#right-to-purchase"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<RightToPurchaseResponse>>> RightToPurchaseAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#security-reclassification"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SecurityUpdateResponse>>> SecurityReclassificationAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#security-swap"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SecurityUpdateResponse>>> SecuritySwapAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#spinoff"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SpinOffResponse>>> SpinOffAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#splits"/>
		/// Splits (Advanced), as opposed to the Splits (Basic) found in StockFundamentalsService
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="refId"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SplitsResponse>>> SplitsAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId);
	}
}
