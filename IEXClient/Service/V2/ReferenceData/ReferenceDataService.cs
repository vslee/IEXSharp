using IEXClient.Helper;
using IEXClient.Model.ReferenceData.Request;
using IEXClient.Model.ReferenceData.Response;
using QueryString;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXClient.Service.V2.ReferenceData
{
    internal class ReferenceDataService : IReferenceDataService
    {
        private readonly string _pk;
        private readonly Executor _executor;

        public ReferenceDataService(HttpClient client, string sk, string pk, bool sign)
        {
            _pk = pk;
            _executor = new Executor(client, sk, pk, sign);
        }

        public async Task<IEnumerable<SymbolResponse>> SymbolsAsync() => await _executor.NoParamExecute<IEnumerable<SymbolResponse>>("ref-data/symbols", _pk);

        public async Task<FXSymbolResponse> FXSymbolAsync() => await _executor.NoParamExecute<FXSymbolResponse>("ref-data/fx/symbols", _pk);

        public async Task<IEnumerable<IEXSymbolResponse>> IEXSymbolsAsync() => await _executor.NoParamExecute<IEnumerable<IEXSymbolResponse>>("ref-data/iex/symbols", _pk);

        public async Task<IEnumerable<InternationalExchangeResponse>> InternationalExchangeAsync() => await _executor.NoParamExecute<IEnumerable<InternationalExchangeResponse>>("ref-data/exchanges", _pk);

        public async Task<IEnumerable<InternationalSymbolResponse>> InternationalExchangeSymbolsAsync(string exchange)
        {
            const string urlPattern = "ref-data/exchange/[exchange]/symbols";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", _pk);

            var pathNvc = new NameValueCollection
            {
                {"exchange", exchange}
            };

            return await _executor.ExecuteAsync<IEnumerable<InternationalSymbolResponse>>(urlPattern, pathNvc, qsb);
        }

        public async Task<IEnumerable<InternationalSymbolResponse>> InternationalRegionSymbolsAsync(string region)
        {
            const string urlPattern = "ref-data/region/[region]/symbols";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", _pk);

            var pathNvc = new NameValueCollection
            {
                {"region", region}
            };

            return await _executor.ExecuteAsync<IEnumerable<InternationalSymbolResponse>>(urlPattern, pathNvc, qsb);
        }

        public async Task<IEnumerable<MutualFundSymbolResponse>> MutualFundSymbolsAsync() => await _executor.NoParamExecute<IEnumerable<MutualFundSymbolResponse>>("ref-data/mutual-funds/symbols", _pk);

        public async Task<IEnumerable<OTCSymbolResponse>> OTCSymbolsAsync() => await _executor.NoParamExecute<IEnumerable<OTCSymbolResponse>>("ref-data/otc/symbols", _pk);

        public async Task<IEnumerable<USExchangeResponse>> USExchangeAsync() => await _executor.NoParamExecute<IEnumerable<USExchangeResponse>>("ref-data/market/us/exchanges", _pk);

        public async Task<IEnumerable<USHolidaysAndTradingDatesResponse>> USHolidaysAndTradingDatesAsync(DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null)
        {
            const string urlPattern = "ref-data/us/dates/[type]/[direction]/[last]/[startDate]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", _pk);

            var pathNvc = new NameValueCollection
            {
                {"type", type.ToString().ToLower()},
                {"direction", direction.ToString().ToLower()},
                {"last", last.ToString()},
                {"startDate", startDate == null ? DateTime.Now.ToString("yyyyMMdd") : ((DateTime) startDate).ToString("yyyyMMdd")}
            };

            return await _executor.ExecuteAsync<IEnumerable<USHolidaysAndTradingDatesResponse>>(urlPattern, pathNvc, qsb);
        }
    }
}