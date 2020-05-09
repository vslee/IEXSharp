using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.Commodities.Request;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.Commodities
{
	public class CommoditiesService : ICommoditiesService
	{
		private readonly ExecutorREST executor;

		public CommoditiesService(HttpClient client, string publishableToken, string secretToken, bool sign)
		{
			executor = new ExecutorREST(client, publishableToken, secretToken, sign);
		}

		public async Task<IEXResponse<decimal>> DataPointAsync(CommoditySymbol symbol)
		{
			var returnValue = await executor.SymbolExecuteAsync<string>("data-points/market/[symbol]", symbol.GetDescriptionFromEnum());
			if (returnValue.ErrorMessage != null)
			{
				return new IEXResponse<decimal> { ErrorMessage = returnValue.ErrorMessage };
			}

			return new IEXResponse<decimal> { Data = decimal.Parse(returnValue.Data) };
		}

		public async Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(CommoditySymbol symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<TimeSeriesResponse>>("time-series/energy/[symbol]", symbol.GetDescriptionFromEnum());
	}
}
