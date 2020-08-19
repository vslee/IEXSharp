using System;
using System.Collections.Specialized;
using System.Text.Json;

namespace IEXSharp.Helper
{
	internal class ExecutorBase
	{
		protected readonly string publishableToken;
		protected readonly string secretToken;
		static JsonSerializerOptions jsonSerializerOptions;

		protected ExecutorBase(string publishableToken, string secretToken)
		{
			this.publishableToken = publishableToken;
			this.secretToken = secretToken;
		}

		internal static JsonSerializerOptions JsonSerializerOptions
		{
			get
			{
				if (jsonSerializerOptions != null)
					return jsonSerializerOptions;
				else
				{
					jsonSerializerOptions = new JsonSerializerOptions
					{
						IgnoreNullValues = true,
						PropertyNameCaseInsensitive = true,
					};
					jsonSerializerOptions.Converters.Add(new DictionaryDatetimeTValueConverter());
					jsonSerializerOptions.Converters.Add(new Int32Converter());
					jsonSerializerOptions.Converters.Add(new Int64Converter());
					jsonSerializerOptions.Converters.Add(new DecimalConverter());
					jsonSerializerOptions.Converters.Add(new StringConverter());
					return jsonSerializerOptions;
				}
			}
			private set { }
		}

		protected static void ValidateAndProcessParams(ref string urlPattern, ref NameValueCollection pathNVC, ref QueryStringBuilder qsb)
		{
			if (string.IsNullOrWhiteSpace(urlPattern))
			{
				throw new ArgumentException("urlPattern cannot be null");
			}
			else if (pathNVC == null)
			{
				throw new ArgumentException("pathNVC cannot be null");
			}
			qsb = qsb ?? new QueryStringBuilder();

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
		}
	}
}
