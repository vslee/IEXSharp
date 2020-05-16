using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.ForexCurrencies.Response;

namespace IEXSharp.Service.Cloud.CoreData.ForexCurrencies
{
	public interface IForexCurrenciesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#forex-currencies"/>
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		Task<IEXResponse<ExchangeRateResponse>> ExchangeRateAsync(string from, string to);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#latest-currency-rates"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CurrencyRateResponse>>> LatestRatesAsync(string symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#currency-conversion"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CurrencyConvertResponse>>> ConvertAsync(string symbols, string amount);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-daily"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <param name="query"></param>
		/// /// <param name="queryValue"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IEnumerable<CurrencyHistoricalRateResponse>>>> HistoricalDailyAsync(string symbols, string query, string queryValue);
	}
}