using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZH.Code.IEX.V2.Model.ReferenceData.Request;
using ZH.Code.IEX.V2.Model.ReferenceData.Response;

namespace ZH.Code.IEX.V2.Service.Symbols
{
    public interface ISymbolService
    {
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#symbols"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SymbolResponse>> SymbolsAsync();

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#iex-symbols"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IEXSymbolResponse>> IEXSymbolsAsync();

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#international-symbols"/>
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        Task<IEnumerable<InternationalSymbolResponse>> InternationalRegionSymbolsAsync(string region);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#international-symbols"/>
        /// </summary>
        /// <param name="exchange"></param>
        /// <returns></returns>
        Task<IEnumerable<InternationalSymbolResponse>> InternationalExchangeSymbolsAsync(string exchange);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#international-exchanges"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<InternationalExchangeResponse>> InternationalExchangeAsync();

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#u-s-exchanges"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<USExchangeResponse>> USExchangeAsync();

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#u-s-holidays-and-trading-dates"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="direction"></param>
        /// <param name="last"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        Task<IEnumerable<USHolidaysAndTradingDatesResponse>> USHolidaysAndTradingDatesAsync(DateType type,
            DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#mutual-fund-symbols"/>
        /// </summary>
        /// <returns></returns>
        Task<MutualFundSymbolResponse> MutualFundSymbolsAsync();

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#otc-symbols"/>
        /// </summary>
        /// <returns></returns>
        Task<OTCSymbolResponse> OTCSymbolsAsync();

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#fx-symbols"/>
        /// </summary>
        /// <returns></returns>
        Task<FXSymbolResponse> FXSymbolAsync();
    }
}