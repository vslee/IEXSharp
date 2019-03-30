using System;
using System.Security.Cryptography;
using System.Text;

namespace ZH.Code
{
    public class IEXSigner
    {
        private string _host;
        private string _sk;

        public IEXSigner()
        {
        }

        public IEXSigner(string host, string sk)
        {
            _host = host;
            _sk = sk;
        }

        public void SetHost(string host)
        {
            _host = host;
        }

        public void SetSecretToken(string sk)
        {
            _sk = sk;
        }

        public (string iexdate, string authorization_header) Sign(string pk, string method, string url, string queryString, string payload = "")
        {
            var now = DateTime.UtcNow;
            var iexdate = now.ToString("yyyyMMddTHHmmssZ");
            var datestamp = now.ToString("yyyyMMdd");
            var canonical_headers = $"host:{_host}\nx-iex-date:{iexdate}\n";
            var payload_hash = SHA256HexHashString(payload);
            var canonical_request = $"{method}\n{url}\n{queryString}\n{canonical_headers}\nhost;x-iex-date\n{payload_hash}";
            var credential_scope = $"{datestamp}/iex_request";
            var string_to_sign = $"IEX-HMAC-SHA256\n{iexdate}\n{credential_scope}\n{SHA256HexHashString(canonical_request)}";
            var signing_key = HMACSHA256HexHashString(HMACSHA256HexHashString(_sk, datestamp), "iex_request");
            var signature = HMACSHA256HexHashString(signing_key, string_to_sign);
            var authorization_header = $"IEX-HMAC-SHA256 Credential={pk}/{credential_scope}, SignedHeaders=host;x-iex-date, Signature={signature}";
            return (iexdate, authorization_header);
        }

        private string HMACSHA256HexHashString(string key, string StringIn)
        {
            string hashString;
            using (var hmacsha256 = new HMACSHA256(Encoding.Default.GetBytes(key)))
            {
                var hash = hmacsha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
                hashString = ToHex(hash, false);
            }
            return hashString;
        }

        private string SHA256HexHashString(string StringIn)
        {
            string hashString;
            using (var sha256 = SHA256Managed.Create())
            {
                var hash = sha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
                hashString = ToHex(hash, false);
            }
            return hashString;
        }

        private string ToHex(byte[] bytes, bool upperCase)
        {
            var result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
            }
            return result.ToString();
        }
    }
}