using IEXSharp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

		public ExecutorREST(HttpClient client, string secretToken, string publishableToken, bool sign) : base(publishableToken: publishableToken)
		{
			this.client = client;
			if (sign)
			{
				signer = new Signer(client.BaseAddress.Host, secretToken);
			}
			this.sign = sign;
			jsonSerializerSettings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
		}

		public async Task<ReturnType> ExecuteAsyncLegacy<ReturnType>(string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb)
			where ReturnType : class
		{
			ValidateAndProcessParams(ref urlPattern, ref pathNVC, ref qsb);

			if (!string.IsNullOrEmpty(publishableToken))
			{
				qsb.Add("token", publishableToken);
			}

			var content = string.Empty;

			if (sign)
			{
				client.DefaultRequestHeaders.Remove("x-iex-date");
				client.DefaultRequestHeaders.Remove("Authorization");

				(string iexdate, string authorization_header) headers = signer.Sign(publishableToken, "GET", urlPattern, qsb.Build());
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

		public async Task<IEXResponse<ReturnType>> ExecuteAsync<ReturnType>(string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb)
			where ReturnType : class
		{
			ValidateAndProcessParams(ref urlPattern, ref pathNVC, ref qsb);

			if (!string.IsNullOrEmpty(publishableToken))
			{
				qsb.Add("token", publishableToken);
			}

			var content = string.Empty;

			if (sign)
			{
				client.DefaultRequestHeaders.Remove("x-iex-date");
				client.DefaultRequestHeaders.Remove("Authorization");

				(string iexdate, string authorization_header) headers = signer.Sign(publishableToken, "GET", urlPattern, qsb.Build());
				client.DefaultRequestHeaders.TryAddWithoutValidation("x-iex-date", headers.iexdate);
				client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", headers.authorization_header);
			}

			using (var responseContent = await client.GetAsync($"{urlPattern}{qsb.Build()}"))
			{
				try
				{
					content = await responseContent.Content.ReadAsStringAsync();
					if (content.Length > 7 && content.Substring(startIndex: 0, length: 8) == "{\"error\"")
					{ // {"error":"child \"token\" fails because [\"token\" must be a string]"}
						var token = JToken.Parse(content);
						return new IEXResponse<ReturnType>() { ErrorMessage = token["error"].ToString() };
					}
					else if (content == "Forbidden")
					{ // "Forbidden"
						return new IEXResponse<ReturnType>() { ErrorMessage = content };
					}
					else return new IEXResponse<ReturnType>() { Data =
						JsonConvert.DeserializeObject<ReturnType>(content, jsonSerializerSettings) };
				}
				catch (JsonException ex)
				{
					throw new JsonException(content, ex);
				}
			}
		}

		public async Task<ReturnType> NoParamExecute<ReturnType>(string url, string token) where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(token))
			{
				qsb.Add("token", token);
			}

			var pathNVC = new NameValueCollection();

			return await ExecuteAsyncLegacy<ReturnType>(url, pathNVC, qsb);
		}

		public async Task<ReturnType> SymbolExecuteAsync<ReturnType>(string urlPattern, string symbol, string token)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await ExecuteAsyncLegacy<ReturnType>(urlPattern, pathNvc, qsb);
		}

		public async Task<ReturnType> SymbolsExecuteAsync<ReturnType>(string urlPattern, IEnumerable<string> symbols, string token)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", string.Join(",", symbols));

			var pathNvc = new NameValueCollection();

			return await ExecuteAsyncLegacy<ReturnType>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<ReturnType>> SymbolLastExecuteAsync<ReturnType>(string urlPattern, string symbol, int last)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> SymbolLastFieldExecuteAsync(string urlPattern, string symbol, string field, int last)
		{
			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}
	}
}