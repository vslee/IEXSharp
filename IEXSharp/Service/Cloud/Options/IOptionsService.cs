using IEXSharp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSLee.IEXSharp.Model.Options.Request;
using VSLee.IEXSharp.Model.Options.Response;

namespace IEXSharp.Service.V2.Options
{
    public interface IOptionsService
    {
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#end-of-day-options"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<IEXResponse<IEnumerable<string>>> OptionsAsync(string symbol);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#end-of-day-options"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="expiration"></param>
        /// <returns></returns>
        Task<IEXResponse<IEnumerable<OptionResponse>>> OptionsAsync(string symbol, string expiration);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#end-of-day-options"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="expiration"></param>
        /// <param name="optionSide"></param>
        /// <returns></returns>
        Task<IEXResponse<IEnumerable<OptionResponse>>> OptionsAsync(string symbol, string expiration, OptionSide optionSide);
    }
}