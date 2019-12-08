using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace VSLee.IEXSharp.Helper
{
	internal class ExecutorREST : ExecutorBase
	{
		private readonly HttpClient client;
		private readonly Signer signer;
		private readonly bool sign;
		private readonly JsonSerializerSettings jsonSerializerSettings;

		public ExecutorREST(HttpClient client, string sk, string pk, bool sign) : base(pk: pk)
		{
			this.client = client;
			if (sign)
			{
				signer = new Signer(client.BaseAddress.Host, sk);
			}
			this.sign = sign;
			jsonSerializerSettings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
		}

		public async Task<ReturnType> ExecuteAsync<ReturnType>(string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb)
			where ReturnType : class
		{
			ValidateAndProcessParams(ref urlPattern, ref pathNVC, ref qsb);

			var content = string.Empty;

			if (sign)
			{
				client.DefaultRequestHeaders.Remove("x-iex-date");
				client.DefaultRequestHeaders.Remove("Authorization");

				(string iexdate, string authorization_header) headers = signer.Sign(pk, "GET", urlPattern, qsb.Build());
				client.DefaultRequestHeaders.TryAddWithoutValidation("x-iex-date", headers.iexdate);
				client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", headers.authorization_header);
			}

			using (var responseContent = await client.GetAsync($"{urlPattern}{qsb.Build()}"))
			{
				try
				{
					content = await responseContent.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ReturnType>(content, jsonSerializerSettings);
				}
				catch (JsonException ex)
				{
					throw new JsonException(content, ex);
				}
			}
		}

		public async Task<ReturnType> ExecuteAsync<ReturnType>(string urlPattern, NameValueCollection pathNVC, string token)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(token))
			{
				qsb.Add("token", token);
			}
			return await ExecuteAsync<ReturnType>(urlPattern, pathNVC, qsb);
		}

		public async Task<ReturnType> NoParamExecute<ReturnType>(string url, string token) where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(token))
			{
				qsb.Add("token", token);
			}

			var pathNVC = new NameValueCollection();

			return await ExecuteAsync<ReturnType>(url, pathNVC, qsb);
		}

		public async Task<ReturnType> SymbolExecuteAsync<ReturnType>(string urlPattern, string symbol, string token)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(token))
			{
				qsb.Add("token", token);
			}

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb);
		}

		public async Task<ReturnType> SymbolsExecuteAsync<ReturnType>(string urlPattern, IEnumerable<string> symbols, string token)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(token))
			{
				qsb.Add("token", token);
			}
			qsb.Add("symbols", string.Join(",", symbols));

			var pathNvc = new NameValueCollection();

			return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb);
		}

		public async Task<ReturnType> SymbolLastExecuteAsync<ReturnType>(string urlPattern, string symbol, int last, string token)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(token))
			{
				qsb.Add("token", token);
			}

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb);
		}

		public async Task<string> SymbolLastFieldExecuteAsync(string urlPattern, string symbol, string field, int last, string token)
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(token))
			{
				qsb.Add("token", token);
			}

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}
	}
}