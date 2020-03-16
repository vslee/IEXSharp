using IEXSharp.Model;
using IEXSharp.Model.CoprorateActions.Request;
using IEXSharp.Model.CoprorateActions.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

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
		Task<IEXResponse<IEnumerable<AdvancedDividendResponse>>> DividendsAsync(string symbol,
			TimeSeriesRange range = TimeSeriesRange._this__quarter, bool calendar = false, int? last = null, string refid = null);
	}
}
