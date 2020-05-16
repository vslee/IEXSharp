using System.Collections.Generic;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class CashFlowsResponse
	{
		public string symbol { get; set; }
		public List<Cashflow> cashflow { get; set; }
	}
}