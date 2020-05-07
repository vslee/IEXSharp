using IEXSharp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.Treasuries.Request;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.Options
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
