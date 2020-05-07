using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.Options.Request;
using IEXSharp.Model.Options.Response;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.Options
{
	public class OptionsService : IOptionsService
	{
		private readonly ExecutorREST executor;

		public OptionsService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<IEnumerable<string>>> OptionsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<string>>("stock/[symbol]/options", symbol);

		public async Task<IEXResponse<IEnumerable<OptionResponse>>> OptionsAsync(string symbol, string expiration)
		{
			const string urlPattern = "stock/[symbol]/options/[expiration]";

			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "expiration", expiration } };
			
			return await executor.ExecuteAsync<IEnumerable<OptionResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<OptionResponse>>> OptionsAsync(string symbol, string expiration, OptionSide optionSide)
		{
			const string urlPattern = "stock/[symbol]/options/[expiration]/[optionSide]";

			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "expiration", expiration }, { "optionSide", optionSide.GetDescriptionFromEnum() } };

			return await executor.ExecuteAsync<IEnumerable<OptionResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}
