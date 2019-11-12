using System.Threading.Tasks;
using IEXClient.Model.ForexCurrencies.Response;

namespace IEXClient.Service.V2.ForexCurrencies
{
    public interface IForexCurrenciesService
    {
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#forex-currencies"/>
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        Task<ExchangeRateResponse> ExchangeRateAsync(string from, string to);
    }
}