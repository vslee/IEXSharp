using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CeoCompensation.Response;

namespace IEXSharp.Service.Cloud.CeoCompensation
{
	public class CeoCompensationService : ICeoCompensationService
	{
		private readonly ExecutorREST executor;

		public CeoCompensationService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<CeoCompensationResponse>> CeoCompensationAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CeoCompensationResponse>("stock/[symbol]/ceo-compensation", symbol);
	}
}
