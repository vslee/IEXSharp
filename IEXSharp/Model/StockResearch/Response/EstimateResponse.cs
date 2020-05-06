using System.Collections.Generic;
using VSLee.IEXSharp.Model.Stock.Response;

namespace VSLee.IEXSharp.Model.StockResearch.Response
{
	public class EstimatesResponse
	{
		public string symbol { get; set; }
		public List<Estimate> estimates { get; set; }
	}
}