using IEXSharp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using System.Text.Json;

namespace IEXSharp.Helper
{
	internal class ExecutorREST : ExecutorBase
	{
		private readonly HttpClient client;
		private readonly AsyncRetryPolicy<HttpResponseMessage> exponentialBackOffPolicy;

		private readonly Signer signer;
		private readonly bool sign;

		public ExecutorREST(HttpClient client, string publishableToken, string secretToken, bool sign)
			: base(publishableToken: publishableToken, secretToken: secretToken)
		{
			this.client = client;
			exponentialBackOffPolicy = ExponentialBackOffPolicy();

			if (sign)
			{
				signer = new Signer(client.BaseAddress.Host, secretToken);
			}
			this.sign = sign;
		}

		public async Task<IEXResponse<ReturnType>> ExecuteAsync<ReturnType>(
			string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb, bool forceUseSecretToken = false)
		{
			ValidateAndProcessParams(ref urlPattern, ref pathNVC, ref qsb);

			if (!string.IsNullOrEmpty(publishableToken) && !forceUseSecretToken)
			{
				qsb.Add("token", publishableToken);
			}

			if (!string.IsNullOrEmpty(secretToken) && forceUseSecretToken)
			{
				qsb.Add("token", secretToken);
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

			using (var responseContent = await exponentialBackOffPolicy.ExecuteAsync(() => client.GetAsync($"{urlPattern}{qsb.Build()}")))
			{
				try
				{
					content = await responseContent.Content.ReadAsStringAsync();
					if (responseContent.StatusCode == HttpStatusCode.OK)
					{
						Debug.WriteLine("Successful Request");
						// Successful Request
						// The logic that follows is included to handle the edge case of pulling
						// dividend or split information in the cases where the DividendRange or
						// SplitRange are set to "Next". When dividends and splits do not exist,
						// the IEXCloud API returns an empty array for all other types of
						// DividendRange and SplitRange values, but in the case of "Next", it
						// returns an empty object (i.e., "{}"). As such, this case must be handled
						// separately without breaking existing functionality.
						if (typeof(IEnumerable).IsAssignableFrom(typeof(ReturnType))
							// Must exclude desired return types of string from this conditional because
							// strings are also assignable from IEnumerable (i.e., IEnumerable<char>)
							&& typeof(ReturnType) != typeof(string)
							// Dictionaries will also be assignable from IEnumerable but it is expected
							// that their JSON representation would begin with "{" instead of "["
							&& !typeof(IDictionary).IsAssignableFrom(typeof(ReturnType))
							&& content[0] != '[')
						{ // if expecting an array but receive a single item instead, create a new List with that single item
							content = '[' + content + ']';
						}
						return new IEXResponse<ReturnType>()
						{
							Data = JsonSerializer.Deserialize<ReturnType>(content, JsonSerializerOptions)
						};
					}
					else
					{ // Failed Request
						return new IEXResponse<ReturnType> { ErrorMessage = $"{responseContent.StatusCode} - {content}" };
					}
				}
				catch (JsonException ex)
				{
					throw new JsonException(content, ex);
				}
			}
		}

		public async Task<IEXResponse<ReturnType>> NoParamExecute<ReturnType>(string url) where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			var pathNVC = new NameValueCollection();

			return await ExecuteAsync<ReturnType>(url, pathNVC, qsb).ConfigureAwait(false);
		}

		public async Task<IEXResponse<ReturnType>> SymbolExecuteAsync<ReturnType>(string urlPattern, string symbol)
		{
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb).ConfigureAwait(false);
		}

		public async Task<IEXResponse<ReturnType>> SymbolsExecuteAsync<ReturnType>(string urlPattern, IEnumerable<string> symbols)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", string.Join(",", symbols));

			var pathNvc = new NameValueCollection();

			return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb).ConfigureAwait(false);
		}

		public async Task<IEXResponse<ReturnType>> SymbolLastExecuteAsync<ReturnType>(string urlPattern, string symbol, int last)
			where ReturnType : class
		{
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await ExecuteAsync<ReturnType>(urlPattern, pathNvc, qsb).ConfigureAwait(false);
		}

		public async Task<IEXResponse<string>> SymbolLastFieldExecuteAsync(string urlPattern, string symbol, string field, int last)
		{
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await ExecuteAsync<string>(urlPattern, pathNvc, qsb).ConfigureAwait(false);
		}

		/// <summary>
		/// Creates an 'Exponential BackOff' strategy that helps with TooManyRequests faults (Http Code = 429) when communicating
		/// with the IEXCloud Service.
		/// </summary>
		/// <returns></returns>
		private static AsyncRetryPolicy<HttpResponseMessage> ExponentialBackOffPolicy()
		{
			var random = new Random();

			// Define our waitAndRetry policy: retry n times with an exponential back-off in case the IEXCloud API throttles us for too many requests.
			var waitAndRetryPolicy = Policy
				.HandleResult<HttpResponseMessage>(e => e.StatusCode == HttpStatusCode.ServiceUnavailable ||
				                                        e.StatusCode == (System.Net.HttpStatusCode) 429)
				.WaitAndRetryAsync(10, // Retry 10 times with a delay between retries before ultimately giving up
					attempt => TimeSpan.FromMilliseconds(250 * Math.Pow(2, attempt) * (1 + random.NextDouble())), // Use Exponential Back off with some randomness to better distribute calls
					(exception, calculatedWaitDuration) => { Debug.WriteLine($"IEXCloud API is throttling our requests. Automatically delaying for {calculatedWaitDuration.TotalMilliseconds}ms"); }
				);

			return waitAndRetryPolicy;
		}
	}
}