using IEX.V2.Helper;
using IEX.V2.Model.Stock.Request;
using IEX.V2.Model.Stock.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

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

        #region Balance Sheet

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public BalanceSheetResponse BalanceSheet(string symbol, Period period, int last = 1)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            BalanceSheetResponse response;
            var content = string.Empty;
            var qs = string.Empty;
            switch (period)
            {
                case Period.Quarter:
                    qs = $"token={pk}&period=quarter";
                    break;

                case Period.Annual:
                    qs = $"token={pk}&period=annual";
                    break;
            }

            using (var responseContent = this.client.GetAsync($"stock/{symbol}/balance-sheet/{last}?{qs}").Result)
            {
                try
                {
                    content = responseContent.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<BalanceSheetResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
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
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            BalanceSheetResponse response;
            var content = string.Empty;
            var qs = string.Empty;

            switch (period)
            {
                case Period.Quarter:
                    qs = $"token={pk}&period=quarter";
                    break;

                case Period.Annual:
                    qs = $"token={pk}&period=annual";
                    break;
            }

            using (var responseContent = await this.client.GetAsync($"stock/{symbol}/balance-sheet/{last}?{qs}"))
            {
                try
                {
                    content = await responseContent.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<BalanceSheetResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="field"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public string BalanceSheetField(string symbol, Period period, string field, int last = 1)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            if (string.IsNullOrWhiteSpace(field))
            {
                throw new ArgumentNullException("Field property cannout be null");
            }
            else
            {
                var content = string.Empty;
                var qs = string.Empty;
                switch (period)
                {
                    case Period.Quarter:
                        qs = $"token={pk}&period=quarter";
                        break;

                    case Period.Annual:
                        qs = $"token={pk}&period=annual";
                        break;
                }

                using (var responseContent = this.client.GetAsync($"stock/{symbol}/balance-sheet/{last}/{field}?{qs}").Result)
                {
                    try
                    {
                        content = responseContent.Content.ReadAsStringAsync().Result;
                    }
                    catch (JsonException ex)
                    {
                        throw new JsonException(content, ex);
                    }
                }
                return content;
            }
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
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            else if (string.IsNullOrWhiteSpace(field))
            {
                throw new ArgumentNullException("Field cannout be null");
            }
            else
            {
                var content = string.Empty;
                var qs = string.Empty;

                switch (period)
                {
                    case Period.Quarter:
                        qs = $"token={pk}&period=quarter";
                        break;

                    case Period.Annual:
                        qs = $"token={pk}&period=annual";
                        break;
                }

                using (var responseContent = await this.client.GetAsync($"stock/{symbol}/balance-sheet/{last}/{field}?{qs}"))
                {
                    try
                    {
                        content = await responseContent.Content.ReadAsStringAsync();
                    }
                    catch (JsonException ex)
                    {
                        throw new JsonException(content, ex);
                    }
                }
                return content;
            }
        }

        #endregion Balance Sheet

        #region Batch Request
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="types"></param>
        /// <param name="range"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public BatchBySymbolResponse BatchBySymbol(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            if (types?.Count() < 1 || string.IsNullOrWhiteSpace(symbol))
            {
                return null;
            }
            var qsBuilder = new QueryStringBuilder();
            var qsType = new List<string>();
            var content = string.Empty;
            var response = new BatchBySymbolResponse();
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
            qsBuilder.Add("types", string.Join(",", qsType));
            if (!string.IsNullOrWhiteSpace(range))
            {
                qsBuilder.Add("range", range);
            }
            qsBuilder.Add("last", last);
            qsBuilder.Add("token", this.pk);


            using (var responseContent = this.client.GetAsync($"stock/{symbol}/batch{qsBuilder.Build()}").Result)
            {
                try
                {
                    content = responseContent.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<BatchBySymbolResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
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
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            else if (types?.Count() < 1)
            {
                return null;
            }
            var qsBuilder = new QueryStringBuilder();
            var qsType = new List<string>();
            var content = string.Empty;
            var response = new BatchBySymbolResponse();
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
            qsBuilder.Add("types", string.Join(",", qsType));
            if (!string.IsNullOrWhiteSpace(range))
            {
                qsBuilder.Add("range", range);
            }
            qsBuilder.Add("last", last);
            qsBuilder.Add("token", this.pk);


            using (var responseContent = await this.client.GetAsync($"stock/{symbol}/batch{qsBuilder.Build()}"))
            {
                try
                {
                    content = await responseContent.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<BatchBySymbolResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }
        
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="types"></param>
        /// <param name="range"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public Dictionary<string, BatchBySymbolResponse> BatchByMarket(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1)
        {
            if (types?.Count() < 1 || symbols?.Count() < 1)
            {
                return null;
            }
            var qsBuilder = new QueryStringBuilder();
            var qsType = new List<string>();
            var content = string.Empty;
            var response = new Dictionary<string, BatchBySymbolResponse>();
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
            qsBuilder.Add("symbols", string.Join(",", symbols));
            qsBuilder.Add("types", string.Join(",", qsType));
            if (!string.IsNullOrWhiteSpace(range))
            {
                qsBuilder.Add("range", range);
            }
            qsBuilder.Add("last", last);
            qsBuilder.Add("token", this.pk);


            using (var responseContent = this.client.GetAsync($"stock/market/batch{qsBuilder.Build()}").Result)
            {
                try
                {
                    content = responseContent.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<Dictionary<string, BatchBySymbolResponse>>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
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

            if (types?.Count() < 1 || symbols?.Count() < 1)
            {
                return null;
            }
            var qsBuilder = new QueryStringBuilder();
            var qsType = new List<string>();
            var content = string.Empty;
            var response = new Dictionary<string, BatchBySymbolResponse>();
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
            qsBuilder.Add("symbols", string.Join(",", symbols));
            qsBuilder.Add("types", string.Join(",", qsType));
            if (!string.IsNullOrWhiteSpace(range))
            {
                qsBuilder.Add("range", range);
            }
            qsBuilder.Add("last", last);
            qsBuilder.Add("token", this.pk);


            using (var responseContent = await this.client.GetAsync($"stock/market/batch{qsBuilder.Build()}"))
            {
                try
                {
                    content = await responseContent.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Dictionary<string, BatchBySymbolResponse>>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }
        #endregion

        #region Book
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#book"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public BookResponse Book(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            BookResponse response;
            var content = string.Empty;
            using (var responseContent = this.client.GetAsync($"stock/{symbol}/book?token={this.pk}").Result)
            {
                try
                {
                    content = responseContent.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<BookResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#book"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<BookResponse> BookAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            BookResponse response;
            var content = string.Empty;
            using (var responseContent = await this.client.GetAsync($"stock/{symbol}/book?token={this.pk}"))
            {
                try
                {
                    content = await responseContent.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<BookResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }
        #endregion

        #region Cash Flow
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public CashFlowResponse CashFlow(string symbol, Period period, int last = 1)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            CashFlowResponse response;
            var content = string.Empty;
            var qs = string.Empty;
            switch (period)
            {
                case Period.Quarter:
                    qs = $"token={pk}&period=quarter";
                    break;

                case Period.Annual:
                    qs = $"token={pk}&period=annual";
                    break;
            }

            using (var responseContent = this.client.GetAsync($"stock/{symbol}/cash-flow/{last}?{qs}").Result)
            {
                try
                {
                    content = responseContent.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<CashFlowResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="last"></param>
        public async Task<CashFlowResponse> CashFlowAsync(string symbol, Period period, int last = 1)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            CashFlowResponse response;
            var content = string.Empty;
            var qs = string.Empty;
            switch (period)
            {
                case Period.Quarter:
                    qs = $"token={pk}&period=quarter";
                    break;

                case Period.Annual:
                    qs = $"token={pk}&period=annual";
                    break;
            }

            using (var responseContent = await this.client.GetAsync($"stock/{symbol}/cash-flow/{last}?{qs}"))
            {
                try
                {
                    content = responseContent.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<CashFlowResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="last"></param>
        public string CashFlowField(string symbol, Period period, string field, int last = 1)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            else if (string.IsNullOrWhiteSpace(field))
            {
                throw new ArgumentNullException("Field property cannout be null");
            }
            else
            {
                var content = string.Empty;
                var qs = string.Empty;
                switch (period)
                {
                    case Period.Quarter:
                        qs = $"token={pk}&period=quarter";
                        break;

                    case Period.Annual:
                        qs = $"token={pk}&period=annual";
                        break;
                }

                using (var responseContent = this.client.GetAsync($"stock/{symbol}/cash-flow/{last}/{field}?{qs}").Result)
                {
                    try
                    {
                        content = responseContent.Content.ReadAsStringAsync().Result;
                    }
                    catch (JsonException ex)
                    {
                        throw new JsonException(content, ex);
                    }
                }
                return content;
            }
        }

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="last"></param>
        public async Task<string> CashFlowFieldAsync(string symbol, Period period, string field, int last = 1)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be null");
            }
            else if (string.IsNullOrWhiteSpace(field))
            {
                throw new ArgumentNullException("Field property cannout be null");
            }
            else
            {
                var content = string.Empty;
                var qs = string.Empty;
                switch (period)
                {
                    case Period.Quarter:
                        qs = $"token={pk}&period=quarter";
                        break;

                    case Period.Annual:
                        qs = $"token={pk}&period=annual";
                        break;
                }

                using (var responseContent = await this.client.GetAsync($"stock/{symbol}/cash-flow/{last}/{field}?{qs}"))
                {
                    try
                    {
                        content = await responseContent.Content.ReadAsStringAsync();
                    }
                    catch (JsonException ex)
                    {
                        throw new JsonException(content, ex);
                    }
                }
                return content;
            }
        }
        #endregion
    }
}