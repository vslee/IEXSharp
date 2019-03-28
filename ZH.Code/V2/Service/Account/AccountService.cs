using ZH.Code.IEX.V2.Model.Account.Request;
using ZH.Code.IEX.V2.Model.Account.Response;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZH.Code.IEX.V2.Service.Account
{
    internal class AccountService : IAccountService
    {
        private HttpClient client;
        private string pk;
        private string sk;

        public AccountService(HttpClient client, string pk, string sk)
        {
            this.client = client;
            this.pk = pk;
            this.sk = sk;
        }

        public MetadataResponse Metadata()
        {
            MetadataResponse response;
            var content = string.Empty;
            using (var responseContent = this.client.GetAsync($"account/metadata?token={sk}").Result)
            {
                try
                {
                    content = responseContent.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<MetadataResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }

        public async Task<MetadataResponse> MetadataAsync()
        {
            MetadataResponse response;
            var content = string.Empty;
            using (var responseContent = await this.client.GetAsync($"account/metadata?token={sk}"))
            {
                try
                {
                    content = await responseContent.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<MetadataResponse>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }

        public UsageResponse Usage(UsageType type)
        {
            UsageResponse response;
            var content = string.Empty;
            string url = "account/usage";
            switch (type)
            {
                case UsageType.Messages:
                    url += "/messages";
                    using (var responseContent = this.client.GetAsync($"{url}?token={sk}").Result)
                    {
                        try
                        {
                            content = responseContent.Content.ReadAsStringAsync().Result;
                            Model.Account.Response.UsageResponseMessages messages =
                                JsonConvert.DeserializeObject<Model.Account.Response.UsageResponseMessages>(content);
                            response = new UsageResponse
                            {
                                messages = messages
                            };
                        }
                        catch (JsonException ex)
                        {
                            throw new JsonException(content, ex);
                        }
                    }
                    return response;

                case UsageType.Rules:
                    url += "/rules";
                    throw new NotImplementedException("Not implemented due to missing data structure");
                case UsageType.RuleRecords:
                    url += "/rule-records";
                    throw new NotImplementedException("Not implemented due to API restrictions");
                case UsageType.Alerts:
                    url += "/alerts";
                    throw new NotImplementedException("Not implemented due to API restrictions");
                case UsageType.AlertRecords:
                    url += "/alert-records";
                    throw new NotImplementedException("Not implemented due to API restrictions");
                default:
                    using (var responseContent = this.client.GetAsync($"{url}?token={sk}").Result)
                    {
                        try
                        {
                            content = responseContent.Content.ReadAsStringAsync().Result;
                            response = JsonConvert.DeserializeObject<UsageResponse>(content);
                        }
                        catch (JsonException ex)
                        {
                            throw new JsonException(content, ex);
                        }
                    }
                    return response;
            }
        }

        public async Task<UsageResponse> UsageAsync(UsageType type)
        {
            UsageResponse response;
            var content = string.Empty;
            var url = "account/usage";
            switch (type)
            {
                case UsageType.Messages:
                    url += "/messages";
                    using (var responseContent = await this.client.GetAsync($"{url}?token={sk}"))
                    {
                        try
                        {
                            content = await responseContent.Content.ReadAsStringAsync();
                            Model.Account.Response.UsageResponseMessages messages =
                                JsonConvert.DeserializeObject<Model.Account.Response.UsageResponseMessages>(content);
                            response = new UsageResponse
                            {
                                messages = messages
                            };
                        }
                        catch (JsonException ex)
                        {
                            throw new JsonException(content, ex);
                        }
                    }
                    return response;

                case UsageType.Rules:
                    url += "/rules";
                    throw new NotImplementedException("Not implemented due to missing data structure");
                case UsageType.RuleRecords:
                    url += "/rule-records";
                    throw new NotImplementedException("Not implemented due to API restrictions");
                case UsageType.Alerts:
                    url += "/alerts";
                    throw new NotImplementedException("Not implemented due to API restrictions");
                case UsageType.AlertRecords:
                    url += "/alert-records";
                    throw new NotImplementedException("Not implemented due to API restrictions");
                default:
                    using (var responseContent = await this.client.GetAsync($"{url}?token={sk}"))
                    {
                        try
                        {
                            content = await responseContent.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<UsageResponse>(content);
                        }
                        catch (JsonException ex)
                        {
                            throw new JsonException(content, ex);
                        }
                    }
                    return response;
            }
        }

        public void PayAsYouGo(bool allow)
        {
            throw new NotImplementedException("Not implemented due to API failed");
        }

        public Task PayAsYouGoAsync(bool allow)
        {
            throw new NotImplementedException("Not implemented due to API failed");
        }
    }
}