using System.Collections.Generic;
using IEXSharp.Model;
using System.Threading.Tasks;
using VSLee.IEXSharp.Model.ForexCurrencies.Response;

namespace VSLee.IEXSharp.Service.V2.ForexCurrencies
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
		/// <value>700</value>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CurrencyRateResponse>>> LatestRatesAsync(string symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#currency-conversion"/>
		/// </summary>
		/// <value>700</value>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CurrencyConvertResponse>>> ConvertAsync(string symbols, string amount);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-daily"/>
		/// </summary>
		/// <value>700</value>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IEnumerable<CurrencyHistoricalRateResponse>>>> HistoricalDailyAsync(string symbols, string query, string queryValue);
	}
}