using ZH.Code.IEX.V2.Helper;
using ZH.Code.IEX.V2.Model.Shared.Response;
using ZH.Code.IEX.V2.Model.Stock.Request;
using ZH.Code.IEX.V2.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZH.Code.IEX.V2.Service.Stock
{
    internal class StockService : IStockService
    {
        private string pk;
        private string sk;
        private Executor executor;

        public StockService(HttpClient client, string pk, string sk)
        {
            this.pk = pk;
            this.sk = sk;
            executor = new Executor(client);
        }

        public async Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period, int last = 1)
        {
            var urlPattern = "stock/[symbol]/balance-sheet/[last]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            qsb.Add("period", period.ToString().ToLower());

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());

            return await executor.ExecuteAsync<BalanceSheetResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<string> BalanceSheetFieldAsync(string symbol, Period period, string field, int last = 1)
        {
            var urlPattern = "stock/[symbol]/balance-sheet/[last]/[field]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            qsb.Add("period", period.ToString().ToLower());

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());
            pathNVC.Add("field", field);

            return await executor.ExecuteAsync<string>(urlPattern, pathNVC, qsb);
        }

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

            return await executor.ExecuteAsync<BatchBySymbolResponse>(urlPattern, pathNVC, qsb);
        }

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

            return await executor.ExecuteAsync<Dictionary<string, BatchBySymbolResponse>>(urlPattern, pathNVC, qsb);
        }

        public async Task<BookResponse> BookAsync(string symbol)
        {
            var urlPattern = "stock/[symbol]/book";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);

            return await executor.ExecuteAsync<BookResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<CashFlowResponse> CashFlowAsync(string symbol, Period period, int last = 1)
        {
            var urlPattern = "stock/[symbol]/cash-flow/[last]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            qsb.Add("period", period.ToString().ToLower());

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());

            return await executor.ExecuteAsync<CashFlowResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<string> CashFlowFieldAsync(string symbol, Period period, string field, int last = 1)
        {
            var urlPattern = "stock/[symbol]/cash-flow/[last]/[field]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);
            qsb.Add("period", period.ToString().ToLower());

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());
            pathNVC.Add("field", field);

            return await executor.ExecuteAsync<string>(urlPattern, pathNVC, qsb);
        }

        public async Task<IEnumerable<Quote>> CollectionsAsync(CollectionType collection, string collectionName)
        {
            var urlPattern = "stock/market/collection/[collectionType]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("collectionType", collection.ToString().ToLower());

            return await executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNVC, qsb);
        }

        public async Task<CompanyResponse> CompanyAsync(string symbol)
        {
            var urlPattern = "stock/[symbol]/company";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);

            return await executor.ExecuteAsync<CompanyResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<DelayedQuoteResponse> DelayedQuoteAsync(string symbol)
        {
            var urlPattern = "stock/[symbol]/delayed-quote";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);

            return await executor.ExecuteAsync<DelayedQuoteResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<IEnumerable<DividendResponse>> DividendAsync(string symbol, DividendRange range)
        {
            var urlPattern = "stock/[symbol]/dividends/[range]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("range", range.ToString().ToLower().Replace("_", ""));

            return await executor.ExecuteAsync<IEnumerable<DividendResponse>>(urlPattern, pathNVC, qsb);
        }

        public async Task<EarningResponse> EarningAsync(string symbol, int last = 1)
        {
            var urlPattern = "stock/[symbol]/earnings/[last]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());

            return await executor.ExecuteAsync<EarningResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<string> EarningFieldAsync(string symbol, string field, int last = 1)
        {
            var urlPattern = "stock/[symbol]/earnings/[last]/[field]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());
            pathNVC.Add("field", field);

            return await executor.ExecuteAsync<string>(urlPattern, pathNVC, qsb);
        }

        public async Task<Dictionary<string, EarningTodayResponse>> EarningTodayAsync()
        {
            var urlPattern = "stock/market/today-earnings";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();

            return await executor.ExecuteAsync<Dictionary<string, EarningTodayResponse>>(urlPattern, pathNVC, qsb);
        }

        public async Task<IEnumerable<EffectiveSpreadResponse>> EffectiveSpreadAsync(string symbol)
        {
            var urlPattern = "stock/[symbol]/effective-spread";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);

            return await executor.ExecuteAsync<IEnumerable<EffectiveSpreadResponse>>(urlPattern, pathNVC, qsb);
        }

        public async Task<EstimateResponse> EstimateAsync(string symbol, int last = 1)
        {
            var urlPattern = "stock/[symbol]/estimates/[last]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());

            return await executor.ExecuteAsync<EstimateResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<string> EstimateFieldAsync(string symbol, string field, int last = 1)
        {
            var urlPattern = "stock/[symbol]/estimates/[last]/[field]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());
            pathNVC.Add("field", field);

            return await executor.ExecuteAsync<string>(urlPattern, pathNVC, qsb);
        }

        public async Task<FinancialResponse> FinancialAsync(string symbol, int last = 1)
        {
            var urlPattern = "stock/[symbol]/financials/[last]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());

            return await executor.ExecuteAsync<FinancialResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<string> FinancialFieldAsync(string symbol, string field, int last = 1)
        {
            var urlPattern = "stock/[symbol]/financials/[last]/[field]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);
            pathNVC.Add("last", last.ToString());
            pathNVC.Add("field", field);

            return await executor.ExecuteAsync<string>(urlPattern, pathNVC, qsb);
        }

        public async Task<FundOwnershipResponse> FundOwnershipAsync(string symbol)
        {
            var urlPattern = "stock/[symbol]/fund-ownership";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.pk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("symbol", symbol);

            return await executor.ExecuteAsync<FundOwnershipResponse>(urlPattern, pathNVC, qsb);
        }
    }
}