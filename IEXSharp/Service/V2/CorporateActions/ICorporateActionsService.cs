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
		/// <see cref="https://iexcloud.io/docs/api/#stats-records"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<AdvancedDividendResponse>>> DividendsAsync(string symbol, TimeSeriesRange range = TimeSeriesRange._this__quarter);
	}
}
