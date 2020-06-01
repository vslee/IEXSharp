using LaunchDarkly.EventSource;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace IEXSharp.Helper
{
	internal class ExecutorSSE : ExecutorBase
	{
		readonly string baseSSEURL;
		public ExecutorSSE(string baseSSEURL, string publishableToken, string secretToken)
			: base(publishableToken: publishableToken, secretToken: secretToken)
		{
			this.baseSSEURL = baseSSEURL;
		}

		public SSEClient<T> SubscribeToSSE<T>(string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb)
		{
			ValidateAndProcessParams(ref urlPattern, ref pathNVC, ref qsb);
			var url = $"{baseSSEURL}{urlPattern}{qsb.Build()}";
			return new SSEClient<T>(Configuration.Builder(new Uri(url)).Build());
		}

		public SSEClient<T> SymbolsSubscribeSSE<T>(string urlPattern, IEnumerable<string> symbols, bool forceUseSecretToken = false)
			where T : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(publishableToken) && !forceUseSecretToken)
			{
				qsb.Add("token", publishableToken);
			}

			if (!string.IsNullOrEmpty(secretToken) && forceUseSecretToken)
			{
				qsb.Add("token", secretToken);
			}

			qsb.Add("symbols", string.Join(",", symbols));

			var pathNvc = new NameValueCollection();

			return SubscribeToSSE<T>(urlPattern, pathNvc, qsb);
		}

		public SSEClient<T> SymbolsChannelsSubscribeSSE<T>(string urlPattern, IEnumerable<string> symbols, IEnumerable<string> channels, bool forceUseSecretToken = false)
			where T : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(publishableToken) && !forceUseSecretToken)
			{
				qsb.Add("token", publishableToken);
			}

			if (!string.IsNullOrEmpty(secretToken) && forceUseSecretToken)
			{
				qsb.Add("token", secretToken);
			}

			qsb.Add("symbols", string.Join(",", symbols));
			qsb.Add("channels", string.Join(",", channels));

			var pathNvc = new NameValueCollection();

			return SubscribeToSSE<T>(urlPattern, pathNvc, qsb);
		}
	}
}
