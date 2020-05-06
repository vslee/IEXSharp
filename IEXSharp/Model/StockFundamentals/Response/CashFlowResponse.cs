using System.Collections.Generic;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.StockFundamentals.Response
{
	public class CashFlowResponse
	{
		public string symbol { get; set; }
		public List<Cashflow> cashflow { get; set; }
	}
}