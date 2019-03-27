using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEX.V2.Helper
{
    internal class Executor
    {
        private HttpClient client;
        private string pk;
        private string sk;

        public Executor(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ReturnType> ExecuteAsync<ReturnType>(string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb) where ReturnType : class
        {
            ValidateParams(ref urlPattern, ref pathNVC, ref qsb);

            ReturnType response;
            var content = string.Empty;

            using (var responseContent = await this.client.GetAsync($"{urlPattern}{qsb.Build()}"))
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