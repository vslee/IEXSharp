using System.Collections.Generic;
using IEXSharp.Model.CoreData.Stock.Response;

namespace IEXSharp.Model.CoreData.StockResearch.Response
{
	public class EstimatesResponse
	{
		public string symbol { get; set; }
		public List<Estimate> estimates { get; set; }
	}
}