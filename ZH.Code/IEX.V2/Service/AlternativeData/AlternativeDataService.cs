using QSBuilder;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using ZH.Code.IEX.V2.Helper;
using ZH.Code.IEX.V2.Model.AlternativeData.Response;
using ZH.Code.IEX.V2.Model.Shared.Response;

namespace ZH.Code.IEX.V2.Service.AlternativeData
{
    internal class AlternativeDataService : IAlternativeDataService
    {
        private readonly string _pk;
        private readonly Executor _executor;

        public AlternativeDataService(HttpClient client, string sk, string pk, bool sign)
        {
            _pk = pk;
            _executor = new Executor(client, sk, pk, sign);
        }

        public async Task<Quote> CryptoAsync(string symbol) => await _executor.SymbolExecuteAsync<Quote>("crypto/[symbol]/quote", symbol, _pk);

        public async Task<SocialSentimentDailyResponse> SocialSentimentDailyAsync(string symbol, DateTime? date = null)
        {
            const string urlPattern = "stock/[symbol]/sentiment/daily/[date]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", _pk);

            var pathNvc = new NameValueCollection
            {
                {"symbol", symbol},
                {"date", date == null ? DateTime.Now.ToString("yyyyMMdd") : ((DateTime) date).ToString("yyyyMMdd")}
            };

            return await _executor.ExecuteAsync<SocialSentimentDailyResponse>(urlPattern, pathNvc, qsb);
        }

        public async Task<SocialSentimentMinuteResponse> SocialSentimentMinuteAsync(string symbol, DateTime? date = null)
        {
            const string urlPattern = "stock/[symbol]/sentiment/minute/[date]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", _pk);

            var pathNvc = new NameValueCollection
            {
                {"symbol", symbol},
                {"date", date == null ? DateTime.Now.ToString("yyyyMMdd") : ((DateTime) date).ToString("yyyyMMdd")}
            };

            return await _executor.ExecuteAsync<SocialSentimentMinuteResponse>(urlPattern, pathNvc, qsb);
        }

        public async Task<CEOCompensationResponse> CEOCompensationAsync(string symbol) => await _executor.SymbolExecuteAsync<CEOCompensationResponse>("stock/[symbol]/ceo-compensation", symbol, _pk);
    }
}