using System;
using System.Net.Http;
using IEXSharp.Service.V2.Account;
using IEXSharp.Service.V2.AlternativeData;
using IEXSharp.Service.V2.APISystemMetadata;
using IEXSharp.Service.V2.ForexCurrencies;
using IEXSharp.Service.V2.InvestorsExchangeData;
using IEXSharp.Service.V2.ReferenceData;
using IEXSharp.Service.V2.Stock;

namespace IEXSharp
{
    public class IEXRestV2Client : IDisposable
    {
        private readonly HttpClient _client;
        private readonly string _pk;
        private readonly string _sk;
        private readonly bool _sign;

        private IAccountService accountService;
        private IStockService stockService;
        private IAlternativeDataService alternativeDataService;
        private IReferenceDataService referenceDataService;
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

        public IReferenceDataService ReferenceData
        {
            get => referenceDataService ?? (referenceDataService = new ReferenceDataService(_client, _sk, _pk, _sign));
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

        public IEXRestV2Client(string pk, string sk, bool signRequest, bool sandBox)
        {
            _pk = pk;
            _sk = sk;
            _client = new HttpClient
            {
                BaseAddress = !sandBox
                    ? new Uri("https://cloud.iexapis.com/beta/")
                    : new Uri("https://sandbox.iexapis.com/beta/")
            };
            _client.DefaultRequestHeaders.Add("User-Agent", "zh-code.com IEX API V2 .Net Wrapper");
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