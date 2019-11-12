using System;
using System.Security.Cryptography;
using System.Text;

namespace IEXSharp.Helper
{
	/// <summary>
	/// Sign request for IEX API V2
	/// Only available to Grow and Scale users
	/// usage:
	/// string host = "sandbox.iexapis.com"; //Sandbox host
	/// //string host = "cloud.iexapis.com" //Production host
	/// string pk = "PublishToken";
	/// string sk = "SecretToken";
	/// 
	/// IEXSigner.Signer signer = new IEXSigner.Signer(host, sk);
	/// 
	/// /*
	/// * If run separately
	/// IEXSigner.Signer signer = new IEXSigner.Signer();
	/// signer.SetHost(host);
	/// signer.SetSecretToken(sk);
	/// */
	/// 
	/// string method = "GET";
	/// string url = "/account/metadata"; // "/" is required at the beginning
	/// string queryString = "namea=1&nameb=2";
	/// string payload = "{\"test\":123,\"obj\":456}";
	/// 
	/// //For GET requests
	/// (string iexdate, string authorization_header) headers = signer.Sign(pk, method, url, queryString);
	/// 
	/// //For POST requests
	/// (string iexdate, string authorization_header) headers = signer.Sign(pk, method, url, queryString, payload);
	/// 
	/// </summary>
	internal class Signer
    {
        private string _host;
        private string _sk;

        public Signer()
        {
        }

        public Signer(string host, string sk)
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
