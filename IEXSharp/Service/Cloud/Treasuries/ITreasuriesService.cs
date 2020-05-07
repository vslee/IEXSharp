using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model.Treasuries.Request;

namespace IEXSharp.Service.Cloud.Treasuries
{
	public interface ITreasuriesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#daily-treasury-rates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> DataPointAsync(TreasuryRateSymbol symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#daily-treasury-rates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(TreasuryRateSymbol symbol);
	}
}
