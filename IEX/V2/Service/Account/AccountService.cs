using IEX.V2.Helper;
using IEX.V2.Model.Account;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IEX.V2.Service.Account
{
    internal class AccountService : IAccountService
    {
        private HttpClientHelper client;
        private string token;

        public AccountService(HttpClientHelper client, string token)
        {
            this.client = client;
            this.token = token;
        }

        public MetadataResponse Metadata()
        {
            MetadataResponse response;
            var content = string.Empty;
            using (var responseContent = this.client.GetAsync("account/metadata", $"token={token}").Result)
            {
                content = responseContent.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<MetadataResponse>(content);
            }
            return response;
        }

        public async Task<MetadataResponse> MetadataAsync()
        {
            MetadataResponse response;
            var content = string.Empty;
            using (var responseContent = await this.client.GetAsync("account/metadata", $"token={token}"))
            {
                content = await responseContent.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<MetadataResponse>(content);
            }
            return response;
        }
    }
}