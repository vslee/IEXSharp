using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.SocialSentiment.Response;

namespace IEXSharp.Service.Cloud.CoreData.SocialSentiment
{
	public class SocialSentimentService : ISocialSentimentService
	{
		private readonly ExecutorREST executor;
		private readonly ExecutorSSE executorSSE;

		internal SocialSentimentService(ExecutorREST executor, ExecutorSSE executorSSE)
		{
			this.executor = executor;
			this.executorSSE = executorSSE;
		}

		public SSEClient<SentimentResponse> SentimentStream(IEnumerable<string> symbols) =>
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
