using System;

namespace IEXSharp.Model.Shared.Response
{
	public class Cashflow
	{
		public DateTime reportDate { get; set; }
		public DateTime fiscalDate { get; set; }
		public string currency { get; set; }
		public long netIncome { get; set; }
		public long depreciation { get; set; }
		public long changesInReceivables { get; set; }
		public long changesInInventories { get; set; }
		public long cashChange { get; set; }
		public long cashFlow { get; set; }
		public long capitalExpenditures { get; set; }
		public long investments { get; set; }
		public long investingActivityOther { get; set; }
		public long totalInvestingCashFlows { get; set; }
		public long dividendsPaid { get; set; }
		public long netBorrowings { get; set; }
		public long otherFinancingCashFlows { get; set; }
		public long cashFlowFinancing { get; set; }
		public long? exchangeRateEffect { get; set; }
	}
}