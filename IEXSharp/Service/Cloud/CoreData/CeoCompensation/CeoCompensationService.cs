using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.CeoCompensation.Response;

namespace IEXSharp.Service.Cloud.CoreData.CeoCompensation
{
	public class CeoCompensationService : ICeoCompensationService
	{
		private readonly ExecutorREST executor;

		internal CeoCompensationService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<CeoCompensationResponse>> CeoCompensationAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CeoCompensationResponse>("stock/[symbol]/ceo-compensation", symbol);
	}
}
