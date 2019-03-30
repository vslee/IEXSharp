using System;
using System.Net.Http;
using ZH.Code.IEX.V2.Service.Account;
using ZH.Code.IEX.V2.Service.AlternativeData;
using ZH.Code.IEX.V2.Service.APISystemMetadata;
using ZH.Code.IEX.V2.Service.ForexCurrencies;
using ZH.Code.IEX.V2.Service.InvestorsExchangeData;
using ZH.Code.IEX.V2.Service.Stock;
using ZH.Code.IEX.V2.Service.Symbols;

namespace ZH.Code.IEX.V2
{
    public class IEXClient : IDisposable
    {
        private readonly HttpClient _client;
        private readonly string _pk;
        private readonly string _sk;
        private readonly bool _sign;

        private IAccountService accountService;
        private IStockService stockService;
        private IAlternativeDataService alternativeDataService;
        private ISymbolService symbolService;
        private IForexCurrenciesService forexCurrenciesService;
        private IInvestorsExchangeDataService investorsExchangeDataService;
        private IAPISystemMetadataService apiSystemMetadataService;

        public IAccountService Account
        {
            get =>
                accountService ??
                (accountService = new AccountService(_client, _sk, _pk, _sign));
        }

        public IStockService Stock
        {
            get => stockService ?? (stockService = new StockService(_client, _sk, _pk, _sign));
        }

        public IAlternativeDataService AlternativeData
        {
            get => alternativeDataService ?? (alternativeDataService = new AlternativeDataService(_client, _sk, _pk, _sign));
        }

        public ISymbolService Symbol
        {
            get => symbolService ?? (symbolService = new SymbolService(_client, _sk, _pk, _sign));
        }

        public IForexCurrenciesService ForexCurrencies
        {
            get => forexCurrenciesService ?? (forexCurrenciesService = new ForexCurrenciesService(_client, _sk, _pk, _sign));
        }

        public IInvestorsExchangeDataService InvestorsExchangeData
        {
            get => investorsExchangeDataService ?? (investorsExchangeDataService = new InvestorsExchangeDataService(_client, _sk, _pk, _sign));
        }

        public IAPISystemMetadataService ApiSystemMetadata
        {
            get => apiSystemMetadataService ?? (apiSystemMetadataService = new APISystemMetadata(_client, _sk, _pk, _sign));
        }

        public IEXClient(string pk, string sk, bool signRequest, bool sandBox)
        {
            _pk = pk;
            _sk = sk;
            _client = new HttpClient
            {
                BaseAddress = !sandBox
                    ? new Uri("https://cloud.iexapis.com/beta/")
                    : new Uri("https://sandbox.iexapis.com/beta/")
            };
            _client.DefaultRequestHeaders.Add("User-Agent", "zh-code IEX API V2 .Net Wrapper");
            _sign = signRequest;
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _client.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}