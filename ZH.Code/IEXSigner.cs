using System;
using System.Security.Cryptography;
using System.Text;

namespace ZH.Code
{
    public static class IEXSigner
    {
        private static string _host;
        private static string _pk;
        private static string _sk;
        public static void Init(string host, string pk, string sk)
        {
            _host = host;
            _pk = pk;
            _sk = sk;
        }

        public static void SetHost(string host)
        {
            _host = host;
        }

        public static void SetPublishToken(string pk)
        {
            _pk = pk;
        }

        public static void SetSecretToken(string sk)
        {
            _sk = sk;
        }
        public static (string iexdate, string authorization_header) Sign(string method, string url, string queryString, string payload = "")
        {
            DateTime now = DateTime.UtcNow;
            string iexdate = now.ToString("yyyyMMddTHHmmssZ");
            var datestamp = now.ToString("yyyyMMdd");
            var canonical_headers = $"host:{_host}\nx-iex-date:{iexdate}\n";
            var payload_hash = SHA256HexHashString(payload);
            var canonical_request = $"{method}\n{url}\n{queryString}\n{canonical_headers}\nhost;x-iex-date\n{payload_hash}";
            var credential_scope = $"{datestamp}/iex_request";
            var string_to_sign = $"IEX-HMAC-SHA256\n{iexdate}\n{credential_scope}\n{SHA256HexHashString(canonical_request)}";
            var signing_key = HMACSHA256HexHashString(HMACSHA256HexHashString(_sk, datestamp), "iex_request");
            var signature = HMACSHA256HexHashString(signing_key, string_to_sign);
            string authorization_header = $"IEX-HMAC-SHA256 Credential={_pk}/{credential_scope}, SignedHeaders=host;x-iex-date, Signature={signature}";
            return (iexdate, authorization_header);
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
        private static string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
            }
            return result.ToString();
        }
    }
}