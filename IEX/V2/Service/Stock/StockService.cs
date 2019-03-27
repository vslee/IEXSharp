using IEX.V2.Helper;
using IEX.V2.Model.Stock.Request;
using IEX.V2.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEX.V2.Service.Stock
{
    internal class StockService : IStockService
    {
        private HttpClient client;
        private string pk;
        private string sk;

        public StockService(HttpClient client, string pk, string sk)
        {
            this.client = client;
            this.pk = pk;
            this.sk = sk;
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public async Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period, int last = 1)
        {
            var urlPattern = "stock/[symbol]/balance-sheet/[last]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            switch (period)
            {
                case Period.Quarter:
                    qsb.Add("period", "quarter");
                    break;

                case Period.Annual:
                    qsb.Add("period", "annual");
                    break;
            }

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());

            Executor<BalanceSheetResponse> executor = new Executor<BalanceSheetResponse>(this.client, this.pk, this.sk);

            return await executor.ExecuteAsync(urlPattern, pathNVC, qsb);
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="field"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public async Task<string> BalanceSheetFieldAsync(string symbol, Period period, string field, int last = 1)
        {
            var urlPattern = "stock/[symbol]/balance-sheet/[last]/[field]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            switch (period)
            {
                case Period.Quarter:
                    qsb.Add("period", "quarter");
                    break;

                case Period.Annual:
                    qsb.Add("period", "annual");
                    break;
            }

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());
            pathNVC.Add("field", field);

            Executor executor = new Executor(this.client, this.pk, this.sk);

            return await executor.ExecuteAsync(urlPattern, pathNVC, qsb);
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="types"></param>
        /// <param name="range"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public async Task<BatchBySymbolResponse> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1)
        {
            if (types?.Count() < 1)
            {
                throw new ArgumentNullException("batchTypes cannot be null");
            }

            var urlPattern = "stock/[symbol]/batch";

            var qsType = new List<string>();
            foreach (BatchType x in types)
            {
                switch (x)
                {
                    case BatchType.Quote:
                        qsType.Add("quote");
                        break;

                    case BatchType.News:
                        qsType.Add("news");
                        break;

                    case BatchType.Chart:
                        qsType.Add("chart");
                        break;
                }
            }
            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            qsb.Add("types", string.Join(",", qsType));
            if (!string.IsNullOrWhiteSpace(range))
            {
                qsb.Add("range", range);
            }
            qsb.Add("last", last);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);

            Executor<BatchBySymbolResponse> executor = new Executor<BatchBySymbolResponse>(this.client, this.pk, this.sk);

            return await executor.ExecuteAsync(urlPattern, pathNVC, qsb);
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="types"></param>
        /// <param name="range"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, BatchBySymbolResponse>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1)
        {
            if (types?.Count() < 1)
            {
                throw new ArgumentNullException("batchTypes cannot be null");
            }
            else if (symbols?.Count() < 1)
            {
                throw new ArgumentNullException("symbols cannot be null");
            }

            var urlPattern = "stock/market/batch";

            var qsType = new List<string>();
            foreach (BatchType x in types)
            {
                switch (x)
                {
                    case BatchType.Quote:
                        qsType.Add("quote");
                        break;

                    case BatchType.News:
                        qsType.Add("news");
                        break;

                    case BatchType.Chart:
                        qsType.Add("chart");
                        break;
                }
            }
            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            qsb.Add("symbols", string.Join(",", symbols));
            qsb.Add("types", string.Join(",", qsType));
            if (!string.IsNullOrWhiteSpace(range))
            {
                qsb.Add("range", range);
            }
            qsb.Add("last", last);

            var pathNVC = new NameValueCollection();

            Executor<Dictionary<string, BatchBySymbolResponse>> executor = new Executor<Dictionary<string, BatchBySymbolResponse>>(this.client, this.pk, this.sk);

            return await executor.ExecuteAsync(urlPattern, pathNVC, qsb);
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#book"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<BookResponse> BookAsync(string symbol)
        {
            var urlPattern = "stock/[symbol]/book";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);

            Executor<BookResponse> executor = new Executor<BookResponse>(this.client, this.pk, this.sk);

            return await executor.ExecuteAsync(urlPattern, pathNVC, qsb);
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="last"></param>
        public async Task<CashFlowResponse> CashFlowAsync(string symbol, Period period, int last = 1)
        {
            var urlPattern = "stock/[symbol]/cash-flow/[last]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            switch (period)
            {
                case Period.Quarter:
                    qsb.Add("period", "quarter");
                    break;

                case Period.Annual:
                    qsb.Add("period", "annual");
                    break;
            }

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());

            Executor<CashFlowResponse> executor = new Executor<CashFlowResponse>(this.client, this.pk, this.sk);

            return await executor.ExecuteAsync(urlPattern, pathNVC, qsb);
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="field"></param>
        /// <param name="last"></param>
        public async Task<string> CashFlowFieldAsync(string symbol, Period period, string field, int last = 1)
        {
            var urlPattern = "stock/[symbol]/cash-flow/[last]/[field]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            switch (period)
            {
                case Period.Quarter:
                    qsb.Add("period", "quarter");
                    break;

                case Period.Annual:
                    qsb.Add("period", "annual");
                    break;
            }

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());
            pathNVC.Add("field", field);

            Executor executor = new Executor(this.client, this.pk, this.sk);

            return await executor.ExecuteAsync(urlPattern, pathNVC, qsb);
        }

        #region Collections - Not implemented

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#collections"/>
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public object Collections(CollectionType collection, string collectionName)
        {
            throw new NotImplementedException("Not implemented due to missing data structure");
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#collections"/>
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="collectionName"></param>
        public async Task<object> CollectionsAsync(CollectionType collection, string collectionName)
        {
            throw new NotImplementedException("Not implemented due to missing data structure");
        }

        #endregion Collections - Not implemented
    }
}