using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.ReferenceData.Response;

namespace IEXSharp.Service.Legacy.ReferenceData
{
	public interface IReferenceDataService
	{
		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SymbolResponse>>> SymbolsAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-corporate-actions"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IEXCorporateActionsResponse>>> IEXCorporateActionsAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-dividends"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IEXDividendsResponse>>> IEXDividendsAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-next-day-ex-date"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IEXNextDayExDateResponse>>> IEXNextDayExDateAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-listed-symbol-directory"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IEXListedSymbolDirectoryResponse>>> IEXListedSymbolDirectoryAsync();
	}
}