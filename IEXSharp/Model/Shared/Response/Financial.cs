using System;

namespace IEXSharp.Model.Shared.Response
{
	public class Financial
	{
		public long EBITDA { get; set; }
        public long accountsPayable { get; set; }
        public long? capitalSurplus { get; set; }
        public long? cashChange { get; set; }
        public long cashFlow { get; set; }
        public int cashFlowFinancing { get; set; }
        public long? changesInInventories { get; set; }
        public long? changesInReceivables { get; set; }
        public long commonStock { get; set; }
        public long costOfRevenue { get; set; }
        public string currency { get; set; }
        public long currentAssets { get; set; }
        public long currentCash { get; set; }
        public long currentDebt { get; set; }
        public long? currentLongTermDebt { get; set; }
        public long depreciation { get; set; }
        public long? dividendsPaid { get; set; }
        public long ebit { get; set; }
        public long? exchangeRateEffect { get; set; }
        public DateTime fiscalDate { get; set; }
        public int goodwill { get; set; }
        public long grossProfit { get; set; }
        public long incomeTax { get; set; }
        public int intangibleAssets { get; set; }
        public int interestIncome { get; set; }
        public long inventory { get; set; }
        public long? investingActivityOther { get; set; }
        public long? investments { get; set; }
        public long longTermDebt { get; set; }
        public long longTermInvestments { get; set; }
        public int minorityInterest { get; set; }
        public long? netBorrowings { get; set; }
        public long netIncome { get; set; }
        public long netIncomeBasic { get; set; }
        public long? netTangibleAssets { get; set; }
        public long operatingExpense { get; set; }
        public long operatingIncome { get; set; }
        public long? operatingRevenue { get; set; }
        public long otherAssets { get; set; }
        public long otherCurrentAssets { get; set; }
        public long? otherCurrentLiabilities { get; set; }
        public long otherIncomeExpenseNet { get; set; }
        public long? otherLiabilities { get; set; }
        public long pretaxIncome { get; set; }
        public long propertyPlantEquipment { get; set; }
        public long receivables { get; set; }
        public DateTime reportDate { get; set; }
        public long researchAndDevelopment { get; set; }
        public long retainedEarnings { get; set; }
        public long revenue { get; set; }
        public long sellingGeneralAndAdmin { get; set; }
        public long shareholderEquity { get; set; }
        public long shortTermDebt { get; set; }
        public long? shortTermInvestments { get; set; }
        public string symbol { get; set; }
        public long totalAssets { get; set; }
        public long totalCash { get; set; }
        public long totalDebt { get; set; }
        public long totalInvestingCashFlows { get; set; }
        public long totalLiabilities { get; set; }
        public long totalRevenue { get; set; }
        public long treasuryStock { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string subkey { get; set; }
        public long updated { get; set; }
	}
}