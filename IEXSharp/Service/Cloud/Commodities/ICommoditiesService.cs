using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.Commodities.Request;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.Commodities
{
	public interface ICommoditiesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#commodities"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> DataPointAsync(CommoditySymbol symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#commodities"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(CommoditySymbol symbol);
	}
}
