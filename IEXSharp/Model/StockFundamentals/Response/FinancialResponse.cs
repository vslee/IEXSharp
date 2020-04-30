using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Model.StockFundamentals.Response
{
	public class FinancialResponse
	{
		public string symbol { get; set; }
		public List<Financial> financials { get; set; }
	}
}