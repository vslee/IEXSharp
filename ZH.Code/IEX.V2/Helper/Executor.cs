using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZH.Code.IEX.V2.Helper
{
    internal class Executor
    {
        private readonly HttpClient _client;

        public Executor(HttpClient client)
        {
            this._client = client;
        }

        public async Task<ReturnType> ExecuteAsync<ReturnType>(string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb) where ReturnType : class
        {
            ValidateParams(ref urlPattern, ref pathNVC, ref qsb);

            ReturnType response;
            var content = string.Empty;

            using (var responseContent = await this._client.GetAsync($"{urlPattern}{qsb.Build()}"))
            {
                try
                {
                    content = await responseContent.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<ReturnType>(content);
                }
                catch (JsonException ex)
                {
                    throw new JsonException(content, ex);
                }
            }
            return response;
        }

        public async Task<ReturnType> NoParamExecute<ReturnType>(string url, string token) where ReturnType : class
        {
            var qsb = new QueryStringBuilder();
            qsb.Add("token", token);

            var pathNvc = new NameValueCollection();

            return await ExecuteAsync<ReturnType>(url, pathNvc, qsb);
        }

        public async Task<ReturnType> SymbolExecuteAsync<ReturnType>(string urlPattern, string symbol, string token)
            where ReturnType : class
        {
            var qsb = new QueryStringBuilder();
            qsb.Add("token", token);

            var pathNvc = new NameValueCollection { { "symbol", symbol } };

            return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb);
        }

        public async Task<ReturnType> SymbolLastExecuteAsync<ReturnType>(string urlPattern, string symbol, int last, string token)
            where ReturnType : class
        {
            var qsb = new QueryStringBuilder();
            qsb.Add("token", token);

            var pathNvc = new NameValueCollection {{"symbol", symbol}, {"last", last.ToString()}};

            return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb);
        }

        public async Task<string> SymbolLastFieldExecuteAsync(string urlPattern, string symbol, string field, int last, string token)
        {
            var qsb = new QueryStringBuilder();
            qsb.Add("token", token);

            var pathNvc = new NameValueCollection {{"symbol", symbol}, {"last", last.ToString()}, {"field", field}};

            return await ExecuteAsync<string>(urlPattern, pathNvc, qsb);
        }

        private static void ValidateParams(ref string urlPattern, ref NameValueCollection pathNVC, ref QueryStringBuilder qsb)
        {
            if (string.IsNullOrWhiteSpace(urlPattern))
            {
                throw new ArgumentException("urlPattern cannot be null");
            }
            else if (pathNVC == null)
            {
                throw new ArgumentException("pathNVC cannot be null");
            }
            else if (qsb == null)
            {
                throw new ArgumentException("qsb cannot be null");
            }

            if (pathNVC.Count > 0)
            {
                foreach (string key in pathNVC.Keys)
                {
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        throw new ArgumentException("pathNVC cannot be null");
                    }
                    else if (string.IsNullOrWhiteSpace(pathNVC[key]))
                    {
                        throw new ArgumentException($"pathNVC {key} value cannot be null");
                    }
                    else if (urlPattern.IndexOf($"[{key}]") < 0)
                    {
                        throw new ArgumentException($"urlPattern doesn't contain key [{key}]");
                    }
                    else
                    {
                        urlPattern = urlPattern.Replace($"[{key}]", pathNVC[key]);
                    }
                }
            }
        }
    }
}