using IEXClient.Helper;
using IEXClient.Model.ForexCurrencies.Response;
using QueryString;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXClient.Service.ForexCurrencies
{
    internal class ForexCurrenciesService : IForexCurrenciesService
    {
        private readonly string _pk;
        private readonly Executor _executor;

        public ForexCurrenciesService(HttpClient client, string sk, string pk, bool sign)
        {
            _pk = pk;
            _executor = new Executor(client, sk, pk, sign);
        }

        public async Task<ExchangeRateResponse> ExchangeRateAsync(string from, string to)
        {
            const string urlPattern = "fx/rate/[from]/[to]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", _pk);

            var pathNvc = new NameValueCollection { { "from", from }, { "to", to } };

            return await _executor.ExecuteAsync<ExchangeRateResponse>(urlPattern, pathNvc, qsb);
        }
    }
}