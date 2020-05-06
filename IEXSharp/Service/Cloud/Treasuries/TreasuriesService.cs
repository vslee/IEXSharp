using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.Treasuries.Response;
using IEXSharp.Model.Treasuries.Request;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VSLee.IEXSharp.Helper;

namespace IEXSharp.Service.V2.Options
{
	public class TreasuriesService : ITreasuriesService
	{
		private readonly ExecutorREST executor;

		public TreasuriesService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<decimal>> DataPointAsync(TreasuryRateSymbol symbol)
		{
			var returnValue = await executor.SymbolExecuteAsync<string>("data-points/market/[symbol]", symbol.GetDescription());
			if (returnValue.ErrorMessage != null)
				return new IEXResponse<decimal>() { ErrorMessage = returnValue.ErrorMessage };
			else
				return new IEXResponse<decimal>() { Data = decimal.Parse(returnValue.Data) };
		}

		public async Task<IEXResponse<IEnumerable<TreasuryResponse>>> TimeSeriesAsync(TreasuryRateSymbol symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<TreasuryResponse>>("time-series/treasury/[symbol]", symbol.GetDescription());
	}
}
