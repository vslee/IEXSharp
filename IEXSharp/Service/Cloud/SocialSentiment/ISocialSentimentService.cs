using IEXSharp.Model;
using IEXSharp.Model.SocialSentiment.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.Options
{
	public interface ISocialSentimentService
	{
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
