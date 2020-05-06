using IEXSharp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.AlternativeData.Response;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.AlternativeData
{
	public interface IAlternativeDataService
	{
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
		Task<IEXResponse<IEnumerable<SocialSentimentMinuteResponse>>> SocialSentimentMinuteAsync(string symbol, DateTime? date = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#ceo-compensation"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<CEOCompensationResponse>> CEOCompensationAsync(string symbol);
	}
}