using System;
using System.Threading.Tasks;
using IEXSharp.Model.AlternativeData.Response;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.V2.AlternativeData
{
    public interface IAlternativeDataService
    {
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#crypto"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<Quote> CryptoAsync(string symbol);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<SocialSentimentDailyResponse> SocialSentimentDailyAsync(string symbol, DateTime? date = null);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<SocialSentimentMinuteResponse> SocialSentimentMinuteAsync(string symbol, DateTime? date = null);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#ceo-compensation"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<CEOCompensationResponse> CEOCompensationAsync(string symbol);
    }
}