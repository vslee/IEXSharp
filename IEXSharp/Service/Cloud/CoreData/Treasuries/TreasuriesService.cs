using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.Treasuries.Request;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.CoreData.Treasuries
{
	public class TreasuriesService : ITreasuriesService
	{
		private readonly ExecutorREST executor;

		internal TreasuriesService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<decimal>> DataPointAsync(TreasuryRateSymbol symbol)
		{
			var returnValue = await executor.SymbolExecuteAsync<string>("data-points/market/[symbol]", symbol.GetDescriptionFromEnum());
			if (returnValue.ErrorMessage != null)
				return new IEXResponse<decimal>() { ErrorMessage = returnValue.ErrorMessage };
			else
				return new IEXResponse<decimal>() { Data = decimal.Parse(returnValue.Data) };
		}

		public async Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(TreasuryRateSymbol symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<TimeSeriesResponse>>("time-series/treasury/[symbol]", symbol.GetDescriptionFromEnum());
	}
}
