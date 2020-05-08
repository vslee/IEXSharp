using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.Batch.Request;
using IEXSharp.Model.Batch.Response;

namespace IEXSharp.Service.Cloud.Batch
{
	public interface IBatchService
	{

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="types"></param>
		/// <param name="range"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<BatchResponse>> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <param name="types"></param>
		/// <param name="range"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, BatchResponse>>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1);
	}
}