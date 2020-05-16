using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.CorporateActions.Request;
using IEXSharp.Model.CoreData.News.Response;

namespace IEXSharp.Service.Cloud.CoreData.News
{
	public class NewsService : INewsService
	{
		private readonly ExecutorREST executor;
		private readonly ExecutorSSE executorSSE;

		internal NewsService(ExecutorREST executor, ExecutorSSE executorSSE)
		{
			this.executor = executor;
			this.executorSSE = executorSSE;
		}

		public async Task<IEXResponse<IEnumerable<NewsResponse>>> NewsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<NewsResponse>>("stock/[symbol]/news", symbol);

		public async Task<IEXResponse<IEnumerable<NewsResponse>>> NewsAsync(string symbol, int last) =>
			await executor.SymbolLastExecuteAsync<IEnumerable<NewsResponse>>("stock/[symbol]/news/last/[last]", symbol, last);

		public SSEClient<NewsResponse> SubscribeToNews(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<NewsResponse>("news-stream", symbols);

		public async Task<IEXResponse<IEnumerable<NewsResponse>>> HistoricalNewsAsync(TimeSeriesRange? range = null, int? limit = null)
		{
			const string urlPattern = "time-series/news";
			var qsb = GetQueryString(range, limit);
			var pathNvc = GetPathNvc(null);

			return await executor.ExecuteAsync<IEnumerable<NewsResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<NewsResponse>>> HistoricalNewsAsync(string symbol, TimeSeriesRange? range = null, int? limit = null)
		{
			const string urlPattern = "time-series/news/[symbol]";
			var qsb = GetQueryString(range, limit);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<NewsResponse>>(urlPattern, pathNvc, qsb);
		}

		private QueryStringBuilder GetQueryString(TimeSeriesRange? range = null, int? limit = null)
		{
			var queryStringBuilder = new QueryStringBuilder();

			if (range != null)
			{
				queryStringBuilder.Add("range", range.GetDescriptionFromEnum());
			}

			if (limit != null)
			{
				queryStringBuilder.Add("limit", limit.ToString());
			}

			return queryStringBuilder;
		}

		private NameValueCollection GetPathNvc(string symbol)
		{
			var pathNvc = new NameValueCollection();
			if (!string.IsNullOrEmpty(symbol))
			{
				pathNvc.Add("symbol", symbol);
			}
			return pathNvc;
		}
	}
}
