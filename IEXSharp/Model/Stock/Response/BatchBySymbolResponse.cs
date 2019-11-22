using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class BatchBySymbolResponse
	{
		public Quote quote { get; set; }
		public List<News> news { get; set; }
		public List<Chart> chart { get; set; }
	}
}