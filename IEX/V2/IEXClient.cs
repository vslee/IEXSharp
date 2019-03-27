using IEX.V2.Service.Account;
using IEX.V2.Service.Stock;
using System;
using System.Net.Http;

namespace IEX.V2
{
    public class IEXClient : IDisposable
    {
        private HttpClient client;
        private string pk;
        private string sk;

        private IAccountService accountService;
        private IStockService stockService;

        public IAccountService Account
        {
            get
            {
                if (this.accountService == null)
                {
                    this.accountService = new AccountService(this.client, this.pk, this.sk);
                }
                return this.accountService;
            }
        }

        public IStockService Stock
        {
            get
            {
                if (this.stockService == null)
                {
                    this.stockService = new StockService(this.client, this.pk, this.sk);
                }
                return this.stockService;
            }
        }

        public IEXClient(string pk, string sk, bool sandBox)
        {
            this.pk = pk;
            this.sk = sk;
            this.client = new HttpClient();
            if (!sandBox)
            {
                client.BaseAddress = new Uri("https://cloud.iexapis.com/beta/");
            }
            else
            {
                client.BaseAddress = new Uri("https://sandbox.iexapis.com/beta/");
            }
            this.client.DefaultRequestHeaders.Add("User-Agent", "zh-code IEX API V2 .Net Wrapper");
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.client.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}