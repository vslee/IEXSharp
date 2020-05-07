using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.Treasuries.Request;
using IEXSharp.Model.Shared.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.Options
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
