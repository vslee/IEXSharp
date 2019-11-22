using System.Collections.Generic;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class EstimateResponse
	{
		public string symbol { get; set; }
		public List<Estimate> estimates { get; set; }
	}
}