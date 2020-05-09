using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.SocialSentiment.Response;

namespace IEXSharp.Service.Cloud.SocialSentiment
{
	public class SocialSentimentService : ISocialSentimentService
	{
		private readonly ExecutorSSE executorSSE;
		private readonly ExecutorREST executor;

		public SocialSentimentService(HttpClient client, string baseSSEURL, string publishableToken, string secretToken, bool sign)
		{
			executor = new ExecutorREST(client, publishableToken, secretToken, sign);
			executorSSE = new ExecutorSSE(baseSSEURL, publishableToken: publishableToken, secretToken: secretToken);
		}

		public SSEClient<SentimentResponse> SubscribeToSentiment(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<SentimentResponse>("sentiment", symbols);

		public async Task<IEXResponse<IEnumerable<SentimentMinuteResponse>>> SentimentByMinuteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<SentimentMinuteResponse>>("stock/[symbol]/sentiment/minute", symbol);

		public async Task<IEXResponse<SentimentResponse>> SentimentByDayAsync(string symbol) =>
			await executor.SymbolExecuteAsync<SentimentResponse>("stock/[symbol]/sentiment/daily", symbol);

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
