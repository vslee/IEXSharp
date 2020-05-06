using System.Collections.Generic;

namespace IEXSharp.Model.StockPrices.Response
{
	public class HistoricalPriceDynamicResponse
	{
		public string range { get; set; }
		public List<HistoricalPriceResponse> data { get; set; }
	}
}