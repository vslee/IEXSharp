using System;
using System.Collections.Generic;

namespace IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class IncomeStatementResponse
	{
		public string symbol { get; set; }
		public List<Income> income { get; set; }
	}

	public class Income
	{
		public DateTime? reportDate { get; set; }
		public DateTime? fiscalDate { get; set; }
		public string currency { get; set; }
		public decimal? totalRevenue { get; set; }
		public decimal? costOfRevenue { get; set; }
		public decimal? grossProfit { get; set; }
		public decimal? researchAndDevelopment { get; set; }
		public decimal? sellingGeneralAndAdmin { get; set; }
		public decimal? operatingExpense { get; set; }
		public decimal? operatingIncome { get; set; }
		public decimal? otherIncomeExpenseNet { get; set; }
		public decimal? ebit { get; set; }
		public decimal? interestIncome { get; set; }
		public decimal? pretaxIncome { get; set; }
		public decimal? incomeTax { get; set; }
		public decimal? minorityInterest { get; set; }
		public decimal? netIncome { get; set; }
		public decimal? netIncomeBasic { get; set; }
	}
}