using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.Options.Request;
using IEXSharp.Model.CoreData.Options.Response;

namespace IEXSharp.Service.Cloud.CoreData.Options
{
	public interface IOptionsService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#end-of-day-options"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<string>>> OptionsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#end-of-day-options"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="expiration"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<OptionResponse>>> OptionsAsync(string symbol, string expiration);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#end-of-day-options"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="expiration"></param>
		/// <param name="optionSide"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<OptionResponse>>> OptionsAsync(string symbol, string expiration, OptionSide optionSide);
	}
}
