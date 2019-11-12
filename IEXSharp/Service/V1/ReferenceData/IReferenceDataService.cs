using IEXSharp.Model.ReferenceData.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEXSharp.Service.V1.ReferenceData
{
	public interface IReferenceDataService
	{
		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SymbolResponse>> SymbolsAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-corporate-actions"/>
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<IEXCorporateActionsResponse>> IEXCorporateActionsAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-dividends"/>
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<IEXDividendsResponse>> IEXDividentsAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-next-day-ex-date"/>
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<IEXNextDayExDateResponse>> IEXNextDayExDateAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#iex-listed-symbol-directory"/>
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<IEXListedSymbolDirectoryResponse>> IEXListedSymbolDirectoryAsync();
	}
}