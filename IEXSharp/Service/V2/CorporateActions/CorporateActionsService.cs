using IEXSharp.Model;
using IEXSharp.Model.CoprorateActions.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.V2.CorporateActions
{
	public class CorporateActionsService : ICorporateActionsService
	{
		private HttpClient client;
		private string secretToken;
		private string publishableToken;
		private bool signRequest;

		public CorporateActionsService(HttpClient client, string secretToken, string publishableToken, bool signRequest)
		{
			this.client = client;
			this.secretToken = secretToken;
			this.publishableToken = publishableToken;
			this.signRequest = signRequest;
		}

		public Task<IEXResponse<IEnumerable<AdvancedDividendResponse>>> DividendsAsync()
		{
			throw new System.NotImplementedException();
		}
	}
}
