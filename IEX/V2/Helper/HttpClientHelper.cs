using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IEX.V2.Helper
{
    internal class HttpClientHelper : IDisposable
    {
        internal HttpClient client;
        internal static string token;
        internal static string secret;

        public HttpClientHelper(string Token, string Secret)
        {
            token = Token;
            secret = Secret;
            this.client = new HttpClient()
            {
                BaseAddress = new Uri("https://cloud.iexapis.com/beta/")
            };
            this.client.DefaultRequestHeaders.Add("User-Agent", "zh-code IEX API V2 .Net Wrapper");
        }

        public async Task<HttpResponseMessage> GetAsync(string url, string queryString)
        {
            (string iexdate, string authorization_header) = await getAuth("GET", url, queryString);
            client.DefaultRequestHeaders.Remove("x-iex-date");
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.Add("x-iex-date", iexdate);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorization_header);
            return await client.GetAsync($"{url}?{queryString}");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, string queryString, object content)
        {
            (string iexdate, string authorization_header) = await getAuth("GET", url, queryString, JsonConvert.SerializeObject(content));
            client.DefaultRequestHeaders.Remove("x-iex-date");
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.Add("x-iex-date", iexdate);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorization_header);
            var httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            return await client.PostAsync($"{url}?{queryString}", httpContent);
        }

        private async Task<(string iexdate, string authorization_header)> getAuth(string method, string url, string queryString, string payload = "")
        {
            DateTime now = DateTime.UtcNow;
            string iexdate = now.ToString("yyyyMMddTHHmmssZ");
            var datestamp = now.ToString("yyyyMMdd");
            var canonical_headers = $"host:cloud.iexapis.com\nx-iex-date:{iexdate}\n";
            var payload_hash = SHA256HexHashString(payload);
            var canonical_request = $"{method}\n/{url}\n{queryString}\n{canonical_headers}\nhost;x-iex-date\n{payload_hash}";
            var credential_scope = $"{datestamp}/iex_request";
            var string_to_sign = $"IEX-HMAC-SHA256\n{iexdate}\n{credential_scope}\n{SHA256HexHashString(canonical_request)}";
            var signing_key = HMACSHA256HexHashString(HMACSHA256HexHashString(secret, datestamp), "iex_request");
            var signature = HMACSHA256HexHashString(signing_key, string_to_sign);
            string authorization_header = $"IEX-HMAC-SHA256 Credential={token}/{credential_scope}, SignedHeaders=host;x-iex-date, Signature={signature}";
            return (iexdate, authorization_header);
        }

        private static string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
            }

            return result.ToString();
        }

        private static string SHA256HexHashString(string StringIn)
        {
            string hashString;
            using (var sha256 = SHA256Managed.Create())
            {
                var hash = sha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
                hashString = ToHex(hash, false);
            }

            return hashString;
        }

        private static string HMACSHA256HexHashString(string key, string StringIn)
        {
            string hashString;
            using (var hmacsha256 = new HMACSHA256(Encoding.Default.GetBytes(key)))
            {
                var hash = hmacsha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
                hashString = ToHex(hash, false);
            }

            return hashString;
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