using System.Collections.Generic;
using IEXSharp.Model.Stock.Response;

namespace IEXSharp.Model.StockResearch.Response
{
	public class EstimatesResponse
	{
		public string symbol { get; set; }
		public List<Estimate> estimates { get; set; }
	}
}