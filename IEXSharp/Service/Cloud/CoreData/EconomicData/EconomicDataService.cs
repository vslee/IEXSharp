using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.EconomicData.Request;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.CoreData.EconomicData
{
	public class EconomicDataService : IEconomicDataService
	{
		private readonly ExecutorREST executor;

		internal EconomicDataService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<decimal>> DataPointAsync(EconomicDataSymbol symbol)
		{
			var returnValue = await executor.SymbolExecuteAsync<string>("data-points/market/[symbol]", symbol.GetDescriptionFromEnum());
			if (returnValue.ErrorMessage != null)
			{
				return new IEXResponse<decimal> { ErrorMessage = returnValue.ErrorMessage };
			}

			return new IEXResponse<decimal> { Data = decimal.Parse(returnValue.Data) };
		}

		public async Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(EconomicDataTimeSeriesSymbol? symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<TimeSeriesResponse>>("time-series/economic/[symbol]", symbol.GetDescriptionFromEnum());
	}
}