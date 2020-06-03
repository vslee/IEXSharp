using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.SocialSentiment.Response;

namespace IEXSharp.Service.Cloud.CoreData.SocialSentiment
{
	public interface ISocialSentimentService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbols">One or more stock symbols.</param>
		/// <returns></returns>
		SSEClient<SentimentResponse> SentimentStream(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SentimentMinuteResponse>>> SentimentByMinuteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<SentimentResponse>> SentimentByDayAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <param name="date">Date string in `YYYYMMDD` format</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SentimentMinuteResponse>>> SentimentByMinuteAsync(string symbol, string date);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <param name="date">Date string in `YYYYMMDD` format</param>
		/// <returns></returns>
		Task<IEXResponse<SentimentResponse>> SentimentByDayAsync(string symbol, string date);
	}
}
