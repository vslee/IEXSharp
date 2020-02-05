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
	}
}