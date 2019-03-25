using IEX.V2.Helper;
using IEX.V2.Service.Account;
using System;

namespace IEX.V2
{
    public class IEXClient : IDisposable
    {
        private HttpClientHelper client;
        private string token;

        private IAccountService accountService;

        public IAccountService Account
        {
            get
            {
                if (this.accountService == null)
                {
                    this.accountService = new AccountService(this.client, this.token);
                }
                return this.accountService;
            }
        }

        public IEXClient(string token, string secret)
        {
            this.token = token;
            this.client = new HttpClientHelper(token, secret);
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