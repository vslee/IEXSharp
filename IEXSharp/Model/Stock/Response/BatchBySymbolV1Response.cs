using VSLee.IEXSharp.Model.Shared.Response;
using System.Collections.Generic;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class BatchBySymbolV1Response : BatchResponse
	{
		public List<NewsV1> news { get; set; }
	}
}