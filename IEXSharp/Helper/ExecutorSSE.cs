using LaunchDarkly.EventSource;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace IEXSharp.Helper
{
	internal class ExecutorSSE : ExecutorBase
	{
		readonly string baseSSEURL;
		public ExecutorSSE(string baseSSEURL, string sk, string pk) : base(publishableToken: pk, sk)
		{
			this.baseSSEURL = baseSSEURL;
		}

		public SSEClient<T> SubscribeToSSE<T>(string urlPattern, NameValueCollection pathNVC, QueryStringBuilder qsb)
		{
			ValidateAndProcessParams(ref urlPattern, ref pathNVC, ref qsb);
			var url = $"{baseSSEURL}{urlPattern}{qsb.Build()}";
			return new SSEClient<T>(Configuration.Builder(new Uri(url)).Build());
		}

		public SSEClient<T> SymbolsSubscribeSSE<T>(string urlPattern, IEnumerable<string> symbols, string token)
			where T : class
		{
			var qsb = new QueryStringBuilder();
			if (!string.IsNullOrEmpty(token))
			{
				qsb.Add("token", token);
			}
			qsb.Add("symbols", string.Join(",", symbols));

			var pathNvc = new NameValueCollection();

			return SubscribeToSSE<T>(urlPattern, pathNvc, qsb);
		}
	}
}
