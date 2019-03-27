using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEX.V2.Helper
{
    internal class Executor<ReturnType> where ReturnType : class
    {
        private HttpClient client;
        private string pk;
        private string sk;

        public Executor(HttpClient client, string pk, string sk)
        {
            this.client = client;
            this.pk = pk;
            this.sk = sk;
        }

        public async Task<ReturnType> ExecuteAsync(string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb)
        {
            #region validation

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

            #endregion validation

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
    }

}