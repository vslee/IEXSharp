using IEXSharp.Model;
using IEXSharp.Model.SocialSentiment.Response;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using VSLee.IEXSharp.Helper;

namespace IEXSharp.Service.V2.Options
{
	public class SocialSentimentService : ISocialSentimentService
	{
		private readonly ExecutorREST executor;

		public SocialSentimentService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<IEnumerable<SentimentMinuteResponse>>> SentimentByMinuteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<SentimentMinuteResponse>>("stock/[symbol]/sentiment", symbol);

		public async Task<IEXResponse<SentimentResponse>> SentimentByDayAsync(string symbol) =>
			await executor.SymbolExecuteAsync<SentimentResponse>("stock/[symbol]/sentiment", symbol);

		public async Task<IEXResponse<IEnumerable<SentimentMinuteResponse>>> SentimentByMinuteAsync(string symbol, string date)
		{
			const string urlPattern = "stock/[symbol]/sentiment/minute/[date]";

			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "date", date } };

			return await executor.ExecuteAsync<IEnumerable<SentimentMinuteResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<SentimentResponse>> SentimentByDayAsync(string symbol, string date)
		{
			const string urlPattern = "stock/[symbol]/sentiment/daily/[date]";

			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "date", date } };

			return await executor.ExecuteAsync<SentimentResponse>(urlPattern, pathNvc, qsb);
		}
	}
}
