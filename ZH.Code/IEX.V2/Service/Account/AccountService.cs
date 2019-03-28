using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using ZH.Code.IEX.V2.Helper;
using ZH.Code.IEX.V2.Model.Account.Request;
using ZH.Code.IEX.V2.Model.Account.Response;

namespace ZH.Code.IEX.V2.Service.Account
{
    internal class AccountService : IAccountService
    {
        private string pk;
        private string sk;
        private Executor executor;

        public AccountService(HttpClient client, string pk, string sk)
        {
            this.pk = pk;
            this.sk = sk;
            executor = new Executor(client);
        }

        public async Task<MetadataResponse> MetadataAsync()
        {
            var urlPattern = "account/metadata";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.sk);

            var pathNVC = new NameValueCollection();

            return await executor.ExecuteAsync<MetadataResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<UsageResponse> UsageAsync(UsageType type)
        {
            var urlPattern = "account/usage/[type]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", this.sk);

            var pathNVC = new NameValueCollection();
            pathNVC.Add("type", type.ToString().ToLower());

            return await executor.ExecuteAsync<UsageResponse>(urlPattern, pathNVC, qsb);
        }

        public Task PayAsYouGoAsync(bool allow)
        {
            throw new NotImplementedException("Not implemented due to API failed");
        }
    }
}