using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.EconomicData.Request;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.EconomicData
{
	public interface IEconomicDataService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#economic-data"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> DataPointAsync(EconomicDataSymbol symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#economic-data"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(EconomicDataTimeSeriesSymbol? symbol);
	}
}