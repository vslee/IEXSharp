using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.ReferenceData.Request;
using IEXSharp.Model.CoreData.ReferenceData.Response;

namespace IEXSharp.Service.Cloud.CoreData.ReferenceData
{
	public interface IReferenceDataService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#search"/>
		/// </summary>
		/// <param name="fragment"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SearchResponse>>> SearchAsync(string fragment);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#fx-symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<SymbolFXResponse>> SymbolFXAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SymbolCryptoResponse>>> SymbolCryptoAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#iex-symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SymbolIEXResponse>>> SymbolsIEXAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#international-symbols"/>
		/// </summary>
		/// <param name="region"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SymbolInternationalResponse>>> SymbolsInternationalRegionAsync(string region);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#international-symbols"/>
		/// </summary>
		/// <param name="exchange"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SymbolInternationalResponse>>> SymbolsInternationalExchangeAsync(string exchange);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#international-exchanges"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ExchangeInternationalResponse>>> ExchangeInternationalAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#mutual-fund-symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SymbolMutualFundResponse>>> SymbolsMutualFundAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#options-symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, string[]>>> SymbolsOptionsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#otc-symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SymbolOTCResponse>>> SymbolsOTCAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#sectors"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SectorResponse>>> SectorsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#symbols"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SymbolResponse>>> SymbolsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#tags"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TagResponse>>> TagsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#u-s-exchanges"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ExchangeUSResponse>>> ExchangeUSAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#u-s-holidays-and-trading-dates"/>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		/// <param name="last"></param>
		/// <param name="startDate"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<HolidaysAndTradingDatesUSResponse>>> HolidaysAndTradingDatesUSAsync(DateType type,
			DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null);
	}
}