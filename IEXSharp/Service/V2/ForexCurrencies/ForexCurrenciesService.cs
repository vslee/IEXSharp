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
		private readonly string _pk;
		private readonly ExecutorREST _executor;

		public ForexCurrenciesService(HttpClient client, string sk, string pk, bool sign)
		{
			_pk = pk;
			_executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<ExchangeRateResponse>> ExchangeRateAsync(string from, string to)
		{
			const string urlPattern = "fx/rate/[from]/[to]";

			var qsb = new QueryStringBuilder();
			qsb.Add("token", _pk);

			var pathNvc = new NameValueCollection { { "from", from }, { "to", to } };

			return await _executor.ExecuteAsync<ExchangeRateResponse>(urlPattern, pathNvc, qsb);
		}
	}
}