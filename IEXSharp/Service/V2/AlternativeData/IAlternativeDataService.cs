using IEXSharp.Model;
using System;
using System.Threading.Tasks;
using VSLee.IEXSharp.Model.AlternativeData.Response;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Service.V2.AlternativeData
{
	public interface IAlternativeDataService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#crypto"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<Quote>> CryptoQuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		Task<IEXResponse<SocialSentimentDailyResponse>> SocialSentimentDailyAsync(string symbol, DateTime? date = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		Task<IEXResponse<SocialSentimentMinuteResponse>> SocialSentimentMinuteAsync(string symbol, DateTime? date = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#ceo-compensation"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<CEOCompensationResponse>> CEOCompensationAsync(string symbol);
	}
}