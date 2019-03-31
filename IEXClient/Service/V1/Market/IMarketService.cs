using IEXClient.Model.InvestorsExchangeData.Response;
using IEXClient.Model.Market.Response;
using IEXClient.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEXClient.Service.V1.Market
{
    public interface IMarketService
    {
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#tops"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<IEnumerable<TOPResponse>> TOPSAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#last"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<IEnumerable<LastResponse>> LastAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#hist"/>
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<IEnumerable<HISTResponse>> HISTAsync(DateTime? date = null);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#deep"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<DeepResponse> DeepAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#book60"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<DeepBookResponse> DeepBookAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#trades"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<Dictionary<string, IEnumerable<DeepTradeResponse>>> DeepTradeAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#system-event"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<DeepSystemEventResponse> DeepSystemEventAsync();

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#trading-status"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<Dictionary<string, DeepTradingStatusResponse>> DeepTradingStatusAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#operational-halt-status"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<Dictionary<string, DeepOperationalHaltStatusResponse>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#short-sale-price-test-status"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<Dictionary<string, DeepShortSalePriceTestStatusResponse>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#security-event"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<Dictionary<string, DeepSecurityEventResponse>> DeepSecurityEventAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#trade-break"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<Dictionary<string, IEnumerable<DeepTradeResponse>>> DeepTradeBreaksAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#auction"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<Dictionary<string, DeepAuctionResponse>> DeepActionAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#official-price"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        Task<Dictionary<string, DeepOfficialPriceResponse>> DeepOfficialPriceAsync(IEnumerable<string> symbols);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#markets"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<USMarketVolumeResponse>> USMarketVolumeAsync();
    }
}