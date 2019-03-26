using IEX.V2.Helper;
using IEX.V2.Model.Stock.Requests;
using IEX.V2.Model.Stock.Response;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IEX.V2.Service.Stock
{
    internal class StockService : IStockService
    {
        private HttpClientHelper client;
        private string pk;
        private string sk;

        public StockService(HttpClientHelper client, string pk, string sk)
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
        /// <returns></returns>
        public BalanceSheetResponse BalanceSheet(string symbol, Period period, int last = 1)
        {
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
        /// <returns></returns>
        public async Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period, int last = 1)
        {
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
    }
}