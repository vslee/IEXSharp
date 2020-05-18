using System;

namespace IEXSharp.Model.CoreData.StockResearch.Response
{
	public class AdvancedStatsResponse : KeyStatsResponse
	{
		public decimal beta { get; set; }
		public long totalCash { get; set; }
		public long currentDebt { get; set; }
		public long revenue { get; set; }
		public long grossProfit { get; set; }
		public long totalRevenue { get; set; }
		public long ebitda { get; set; }
		public decimal revenuePerShare { get; set; }
		public decimal revenuePerEmployee { get; set; }
		public decimal debtToEquity { get; set; }
		public decimal profitMargin { get; set; }
		public long enterpriseValue { get; set; }
		public decimal enterpriseValueToRevenue { get; set; }
		public decimal priceToSales { get; set; }
		public decimal priceToBook { get; set; }
		public decimal forwardPERatio { get; set; }
		public decimal pegRatio { get; set; }
		public decimal peHigh { get; set; }
		public decimal peLow { get; set; }
		public DateTime? week52highDate { get; set; }
		public DateTime? week52lowDate { get; set; }
		public decimal putCallRatio { get; set; }
	}
}