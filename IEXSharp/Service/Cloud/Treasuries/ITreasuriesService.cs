using IEXSharp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.Treasuries.Request;
using IEXSharp.Model.Treasuries.Response;

namespace IEXSharp.Service.V2.Options
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
		Task<IEXResponse<IEnumerable<TreasuryResponse>>> TimeSeriesAsync(TreasuryRateSymbol symbol);
	}
}
