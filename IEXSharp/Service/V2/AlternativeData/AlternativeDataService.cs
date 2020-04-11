using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.AlternativeData.Response;
using VSLee.IEXSharp.Model.Shared.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.V2.AlternativeData
{
	internal class AlternativeDataService : IAlternativeDataService
	{
		private readonly ExecutorREST _executor;

		public AlternativeDataService(HttpClient client, string sk, string pk, bool sign)
		{
			_executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<Quote>> CryptoQuoteAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<Quote>("crypto/[symbol]/quote", symbol);

		public async Task<IEXResponse<SocialSentimentDailyResponse>> SocialSentimentDailyAsync(string symbol, DateTime? date = null)
		{
			const string urlPattern = "stock/[symbol]/sentiment/daily/[date]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"date", date == null ? DateTime.Now.ToString("yyyyMMdd") : ((DateTime) date).ToString("yyyyMMdd")}
			};

			return await _executor.ExecuteAsync<SocialSentimentDailyResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<SocialSentimentMinuteResponse>>> SocialSentimentMinuteAsync(string symbol, DateTime? date = null)
		{
			const string urlPattern = "stock/[symbol]/sentiment/minute/[date]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"date", date == null ? DateTime.Now.ToString("yyyyMMdd") : ((DateTime) date).ToString("yyyyMMdd")}
			};

			return await _executor.ExecuteAsync<IEnumerable<SocialSentimentMinuteResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<CEOCompensationResponse>> CEOCompensationAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<CEOCompensationResponse>("stock/[symbol]/ceo-compensation", symbol);
	}
}