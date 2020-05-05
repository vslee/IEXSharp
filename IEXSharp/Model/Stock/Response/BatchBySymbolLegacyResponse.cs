using VSLee.IEXSharp.Model.Shared.Response;
using System.Collections.Generic;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class BatchBySymbolLegacyResponse : BatchResponse
	{
		public List<NewsLegacy> news { get; set; }
	}
}