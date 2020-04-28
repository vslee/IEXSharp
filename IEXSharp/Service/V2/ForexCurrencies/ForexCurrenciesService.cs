using System.Collections.Generic;
using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.ForexCurrencies.Response;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.V2.ForexCurrencies
{
	internal class ForexCurrenciesService : IForexCurrenciesService
	{
		private readonly ExecutorREST executor;

		public ForexCurrenciesService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<IEnumerable<CurrencyRateResponse>>> LatestRatesAsync(string symbols)
		{
			var queryParameterDictionary = new Dictionary<string, string> {{"symbols", symbols}};

			return await executor.QueryStringExecuteAsync<IEnumerable<CurrencyRateResponse>>($"fx/latest", queryParameterDictionary);
		}

		public async Task<IEXResponse<IEnumerable<CurrencyConvertResponse>>> ConvertAsync(string symbols, string amount)
		{
			var queryParameterDictionary = new Dictionary<string, string> {{"symbols", symbols}, {"amount", amount}};

			return await executor.QueryStringExecuteAsync<IEnumerable<CurrencyConvertResponse>>($"fx/convert", queryParameterDictionary);
		}

		public async Task<IEXResponse<IEnumerable<IEnumerable<CurrencyHistoricalRateResponse>>>> HistoricalDailyAsync(string symbols, string query, string queryValue)
		{
			var queryParameterDictionary = new Dictionary<string, string> {{"symbols", symbols}, {query, queryValue}};

			return await executor.QueryStringExecuteAsync<IEnumerable<IEnumerable<CurrencyHistoricalRateResponse>>>($"fx/historical", queryParameterDictionary);
		}

		public async Task<IEXResponse<ExchangeRateResponse>> ExchangeRateAsync(string from, string to)
		{
			const string urlPattern = "fx/rate/[from]/[to]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "from", from }, { "to", to } };

			return await executor.ExecuteAsync<ExchangeRateResponse>(urlPattern, pathNvc, qsb);
		}
	}
}