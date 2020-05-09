using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.Account.Request;
using IEXSharp.Model.Account.Response;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.Account
{
	internal class AccountService : IAccountService
	{
		private readonly ExecutorREST _executor;

		public AccountService(HttpClient client, string publishableToken, string secretToken, bool sign)
		{
			_executor = new ExecutorREST(client, publishableToken, secretToken, sign);
		}

		public async Task<IEXResponse<MetadataResponse>> MetadataAsync()
		{
			const string urlPattern = "account/metadata";

			var qsb = new QueryStringBuilder();

			var pathNVC = new NameValueCollection();

			return await _executor.ExecuteAsync<MetadataResponse>(urlPattern, pathNVC, qsb, forceUseSecretToken: true);
		}

		public async Task<IEXResponse<UsageResponse>> UsageAsync(UsageType type)
		{
			var urlPattern = $"account/usage/{(type != UsageType.All ? "[type]" : "")}";

			var qsb = new QueryStringBuilder();

			var pathNVC = new NameValueCollection();

			if (type != UsageType.All)
			{
				pathNVC["type"] = type.GetDescriptionFromEnum();
			}

			return await _executor.ExecuteAsync<UsageResponse>(urlPattern, pathNVC, qsb, forceUseSecretToken: true);
		}

		public Task PayAsYouGoAsync(bool allow)
		{
			throw new NotImplementedException("Not implemented due to API failed");
		}
	}
}