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
		private readonly string pk;
		private readonly ExecutorSSE executorSSE;
		private readonly ExecutorREST executor;

		public SocialSentimentService(HttpClient client, string baseSSEURL, string sk, string pk, bool sign)
		{
			this.pk = pk;
			executor = new ExecutorREST(client, sk, pk, sign);
			executorSSE = new ExecutorSSE(baseSSEURL, sk: sk, pk: pk);
		}

		public SSEClient<SentimentResponse> SubscribeToSentiment(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<SentimentResponse>("sentiment", symbols, pk);

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
