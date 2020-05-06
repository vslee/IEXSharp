using IEXSharp.Model;
using System.Net.Http;
using System.Threading.Tasks;
using VSLee.IEXSharp.Helper;
using IEXSharp.Model.CeoCompensation.Response;

namespace IEXSharp.Service.V2.Options
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
