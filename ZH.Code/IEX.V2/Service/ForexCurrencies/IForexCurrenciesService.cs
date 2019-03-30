using System.Threading.Tasks;
using ZH.Code.IEX.V2.Model.ForexCurrencies.Response;

namespace ZH.Code.IEX.V2.Service.ForexCurrencies
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