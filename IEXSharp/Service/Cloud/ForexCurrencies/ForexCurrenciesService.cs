using System.Collections.Generic;
using IEXSharp.Helper;
using IEXSharp.Model.ForexCurrencies.Response;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace IEXSharp.Service.Cloud.ForexCurrencies
{
	internal class ForexCurrenciesService : IForexCurrenciesService
	{
		private readonly ExecutorREST executor;

		public ForexCurrenciesService(HttpClient client, string publishableToken, string secretToken, bool sign)
		{
			executor = new ExecutorREST(client, publishableToken, secretToken, sign);
		}

		public async Task<IEXResponse<IEnumerable<CurrencyRateResponse>>> LatestRatesAsync(string symbols)
		{
			var nvc = new NameValueCollection();
			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", symbols);

			return await executor.ExecuteAsync<IEnumerable<CurrencyRateResponse>>("fx/latest", nvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<CurrencyConvertResponse>>> ConvertAsync(string symbols, string amount)
		{
			var nvc = new NameValueCollection();
			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", symbols);
			qsb.Add("amount", amount);

			return await executor.ExecuteAsync<IEnumerable<CurrencyConvertResponse>>("fx/convert", nvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<IEnumerable<CurrencyHistoricalRateResponse>>>> HistoricalDailyAsync(string symbols, string query, string queryValue)
		{
			var nvc = new NameValueCollection();
			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", symbols);
			qsb.Add(query, queryValue);

			return await executor.ExecuteAsync<IEnumerable<IEnumerable<CurrencyHistoricalRateResponse>>>("fx/historical", nvc, qsb);
		}

		public async Task<IEXResponse<ExchangeRateResponse>> ExchangeRateAsync(string from, string to)
		{
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "from", from }, { "to", to } };

			return await executor.ExecuteAsync<ExchangeRateResponse>("fx/rate/[from]/[to]", pathNvc, qsb);
		}
	}
}